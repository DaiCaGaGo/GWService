using BusinessObjects.Models;
using BusinessObjects.Supports;
using DataAccessLayer;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessObjects.Repositorys
{
    public class SmsBirthdayRepository
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DatabaseHelper database = new DatabaseHelper();
        public void InsertListSmsBirthday(IList<SmsBirthdayModel> listSms)
        {
            try
            {
                using (SemaphoreSlim semaphore = new SemaphoreSlim(AppConfig.WORKER_COUNT))
                {
                    List<Task> tasks = new List<Task>();

                    foreach (var sms in listSms)
                    {
                        semaphore.Wait();

                        Task task = Task.Run(async () =>
                        {
                            try
                            {
                                await this.database.InsertSmsBirthdayAsync(AppConfig.API_PUT_SMS_SEEN, new object[] { sms.ACCOUNT_ID, sms.SENDER_NAME, sms.SMS_CONTENT, sms.SMS_COUNT, sms.PHONE, sms.TELCO, sms.SCHEDULE_TIME, sms.CREATE_USER });
                            }
                            finally
                            {
                                semaphore.Release();
                            }
                        });

                        tasks.Add(task);
                    }

                    Task.WhenAll(tasks).Wait();
                }
            }
            catch (Exception ex)
            {
                logger.Error("InsertListSmsBirthday", ex);
            }
        }

        public async Task InsertSmsBirthday(SmsBirthdayModel sms)
        {
            try
            {
                await this.database.InsertSmsBirthdayAsync(AppConfig.API_PUT_SMS_BIRTHDAY, new object[] { sms.ACCOUNT_ID, sms.SENDER_NAME, sms.SMS_CONTENT, sms.SMS_COUNT, sms.PHONE, sms.TELCO, sms.SCHEDULE_TIME, sms.CREATE_USER, sms.GROUP_ID });
            }
            catch (Exception ex)
            {
                logger.Error("InsertSmsBirthday", ex);
            }
        }

        public async Task<IList<SmsBirthdayModel>> GetSmsBirthdayWaiting()
        {
            try
            {
                IDictionary<string, object> result = await (new DatabaseHelper()).GetSmsBirthdayCustomerAsync("pks_sms_birthday.pr_get_sms_birthday_wait");
                int v_ErrCode = Convert.ToInt32(result[AppConst.ERR_CODE]);
                if (v_ErrCode == AppConst.SYS_ERR_OK)
                {
                    string json = JsonConvert.SerializeObject(result[AppConst.DATA], Formatting.Indented);
                    IList<SmsBirthdayModel> smsList = JsonConvert.DeserializeObject<IList<SmsBirthdayModel>>(json);
                    logger.Info(AppConst.A("GetSmsBirthdayWaiting", json));
                    return smsList;
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetSmsBirthdayWaiting", ex);
            }

            return null;
        }
    }
}
