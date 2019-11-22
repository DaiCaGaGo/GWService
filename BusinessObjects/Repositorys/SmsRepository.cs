using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Supports;
using DataAccessLayer;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessObjects.Repositorys
{
    public class SmsRepository : ISmsRepository
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DatabaseHelper database = new DatabaseHelper();

        public async Task<IList<SmsModel>> GetSmsListAsync(int count, string smsType)
        {
            try
            {
                IDictionary<string, object> result = await this.database.GetSMSAsync(smsType.Equals(AppConst.CSKH) ? AppConfig.API_GET_SMS_CSKH : AppConfig.API_GET_SMS_QC, count);
                int v_ErrCode = Convert.ToInt32(result[AppConst.ERR_CODE]);

                if (v_ErrCode == AppConst.SYS_ERR_OK)
                {
                    string json = JsonConvert.SerializeObject(result[AppConst.DATA], Formatting.Indented);
                    IList<SmsModel> smsList = JsonConvert.DeserializeObject<IList<SmsModel>>(json);
                    return smsList;
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetSmsListAsync", ex);
            }

            return null;
        }

        public void UpdateStatusSMS(IList<SmsModel> listSms)
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
                                await this.database.UpdateStatusSMSAsync(AppConfig.API_PUT_SMS_SEEN, new object[] { sms.ID });
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
                logger.Error("UpdateStatusSMS", ex);
            }
        }

        public async Task UpdateSMSSuccessAsync(SmsModel sms)
        {
            if (sms.SMS_TYPE.Equals(AppConst.CSKH)) await this.database.UpdateSMSSuccessAsync(AppConfig.API_PUT_SMS_SUCCESS, sms.ID.ToString(), sms.SMS_TYPE, sms.ERR_CODE_PARTNER.ToString(), sms.RECEIVE_RESULT);
            else await this.database.UpdateSMSSuccessAsync(AppConfig.API_PUT_SMS_SUCCESS, sms.CAMPAIGN_ID, sms.SMS_TYPE, sms.ERR_CODE_PARTNER.ToString(), sms.RECEIVE_RESULT);
        }

        public async Task UpdateSMSErrorAsync(SmsModel sms)
        {
            if (sms.SMS_TYPE.Equals(AppConst.CSKH)) await this.database.UpdateSMSErrorAsync(AppConfig.API_PUT_SMS_ERROR, sms.ID, sms.SMS_TYPE, sms.PARTNER_NAME, sms.ERR_CODE_PARTNER.ToString());
            else await this.database.UpdateSMSErrorAsync(AppConfig.API_PUT_SMS_ERROR, Convert.ToInt64(sms.CAMPAIGN_ID), sms.SMS_TYPE, sms.PARTNER_NAME, sms.ERR_CODE_PARTNER.ToString());
        }

        public async Task InsertSmsBirthday(SmsModel sms)
        {
            await this.database.InsertSmsAsync("pks_sms.pr_post_sms", sms.ACCOUNT_ID, sms.SENDER_NAME, sms.SMS_TYPE, sms.SMS_CONTENT, sms.PARTNER_NAME, sms.SMS_COUNT, sms.PHONE, sms.TELCO, sms.SCHEDULE_TIME, "", 0, 0, "sfsd", sms.VIA);
            //await this.database.InsertSmsAsync("pks_sms.pr_post_sms", 100000480, "EUNSO", "CSKH", "TEST", "VNPT", 1, "84393158247", "VIETTEL", "201910300800", "", 0, 0, "sfsd", "SMS_BIRTHDAY");
        }
    }
}
