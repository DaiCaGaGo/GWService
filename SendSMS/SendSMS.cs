using BusinessObjects.Models;
using BusinessObjects.Supports;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Threading.Tasks;

namespace SendSMS
{
    public partial class SendSMS : ServiceBase
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        private IList<RabbitHelper> listRabbitWorker = new List<RabbitHelper>();
        private int Worker;

        public SendSMS()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                logger.Info("OnStart Start!");
                SmppHelper.Initialize();

                foreach (int i in Enumerable.Range(0, AppConfig.WORKER_COUNT))
                {
                    Task.Run(() => StartWorker(), this.cancelToken.Token);
                }
            }
            catch (Exception ex)
            {
                logger.Error("OnStart", ex);
            }
        }

        /// <summary>
        /// Initialize new Worker
        /// </summary>
        private void StartWorker()
        {
            RabbitHelper rabbitWorker = new RabbitHelper();
            rabbitWorker.Initialize();
            rabbitWorker.Worker = this.Worker++;
            rabbitWorker.ReceiveEvent += ReceivedHandlerCallback;
            rabbitWorker.ReceiveMessage(AppConfig.PARTNER_QUEUE);
            this.listRabbitWorker.Add(rabbitWorker);
            logger.Info(AppConst.A("StartWorker", rabbitWorker.Worker, AppConfig.PARTNER_QUEUE, "Started listener!"));
        }

        /// <summary>
        /// Event listener receive message from queue
        /// </summary>
        /// <param name="message">message receive</param>
        /// <param name="worker">worker receive</param>
        private void ReceivedHandlerCallback(string message, int worker)
        {
            try
            {
                logger.Info(AppConst.A("ReceivedHandlerCallback Deliver", worker, message));

                if (!String.IsNullOrEmpty(message))
                {
                    IList<SmsModel> listSms = JsonConvert.DeserializeObject<IList<SmsModel>>(message);
                    if (listSms[0].SMS_TYPE.Equals(AppConst.CSKH))
                    {
                        ProcessSMS_CSKH(listSms, AppConfig.WORKER_TASK_COUNT, worker).Wait();
                    }
                    else
                    {
                        SendHelper.SendSMS_API_QC(this.listRabbitWorker[worker], listSms);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("ReceivedHandlerCallback", ex));
            }
        }

        /// <summary>
        /// Run and limit tasks concurrency
        /// </summary>
        /// <param name="listSms"></param>
        /// <param name="maxConcurrency"></param>
        /// <param name="worker"></param>
        private async Task ProcessSMS_CSKH(IList<SmsModel> listSms, int maxConcurrency = 1, int worker = 0)
        {
            using (SemaphoreSlim semaphore = new SemaphoreSlim(maxConcurrency))
            {
                List<Task> tasks = new List<Task>();

                foreach (var sms in listSms)
                {
                    await semaphore.WaitAsync();

                    Task task = Task.Run(() =>
                    {
                        try
                        {
                            if (sms.SENDBY.Equals(AppConst.API))
                            {
                                SendHelper.SendSMS_API_CSKH(this.listRabbitWorker[worker], sms);
                            }
                            else if (sms.SENDBY.Equals(AppConst.SMPP))
                            {
                                SendHelper.SendSMS_SMPP(this.listRabbitWorker[worker], sms);
                            }
                            else
                            {
                                sms.ERR_CODE = AppConst.SYS_ERR_EXCEPTION;
                                sms.RECEIVE_RESULT = "SMS Anonymous!";
                                this.listRabbitWorker[worker].PublishMessage(AppConfig.QUEUE_ERROR, JsonConvert.SerializeObject(sms));
                                logger.Error(AppConst.A("ProcessSMS", sms.ID, sms.RECEIVE_RESULT));
                            }
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    tasks.Add(task);
                }

                await Task.WhenAll(tasks);
            }
        }

        protected override void OnStop()
        {
            try
            {
                foreach (var rabbitWorker in this.listRabbitWorker)
                {
                    rabbitWorker.StopEventReceiveSMS();
                    rabbitWorker.ReceiveEvent -= ReceivedHandlerCallback;
                }

                if (this.cancelToken != null)
                    this.cancelToken.Cancel();

                this.cancelToken = null;
                this.listRabbitWorker = null;
            }
            catch (Exception ex)
            {
                logger.Error("OnStop", ex);
            }

            logger.Info("Stoped application !");
        }
    }
}
