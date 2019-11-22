using BusinessObjects.Models;
using BusinessObjects.Services;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessObjects.Supports
{
    public class SendHelper
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void SendSMS_API_CSKH(RabbitHelper rabbitHelper, SmsModel sms)
        {
            string resultPartner = String.Empty;
            int ErrCode = AppConst.SYS_ERR_UNKNOW;
            int ErrCodePartner = AppConst.SYS_ERR_UNKNOW;
            string ErrMessage = String.Empty;

            switch (sms.PARTNER_NAME)
            {
                case AppConst.PARTNER_SOUTH:
                    ErrCodePartner = (new SouthService()).SendSMS_CSKHAsync(sms.URL_HTTP_1_CSKH, sms.HTTP_PASS_CSKH, sms.ID.ToString(), sms.SENDER_NAME, sms.PHONE, sms.SMS_CONTENT).Result;
                    ErrCode = ErrCodePartner;
                    break;
                case AppConst.PARTNER_INCOM:
                    ErrCodePartner = (new IncomService(sms.URL_HTTP_1_CSKH)).SendSMS(sms.HTTP_USER_CSKH, sms.HTTP_PASS_CSKH, sms.PHONE, sms.SMS_CONTENT, sms.SENDER_NAME, String.Empty, "0", "0", "1", "1", "0", "0");
                    ErrCode = ErrCodePartner;
                    break;
                case AppConst.PARTNER_VNPT:
                    ErrCodePartner = (new VnptService(sms.URL_HTTP_1_CSKH)).uploadSMS(sms.HTTP_USER_CSKH, sms.HTTP_PASS_CSKH, sms.SENDER_NAME, sms.PHONE, "0", "2", sms.SMS_CONTENT);
                    ErrCode = ErrCodePartner;
                    break;
                case AppConst.PARTNER_VMG:
                    ErrCodePartner = (new VmgService(sms.URL_HTTP_1_CSKH)).BulkSendSms(sms.PHONE, sms.SENDER_NAME, sms.SMS_CONTENT, DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), sms.HTTP_USER_CSKH, sms.HTTP_PASS_CSKH).error_code;
                    ErrCode = ErrCodePartner;
                    break;
                case AppConst.PARTNER_VIVAS:
                    ErrCodePartner = VivasService.SendSMS_APIAsync(sms.URL_HTTP_1_CSKH, sms.HTTP_USER_CSKH, sms.HTTP_PASS_CSKH, sms.ID.ToString(), sms.SENDER_NAME, sms.PHONE, sms.SMS_CONTENT, sms.SCHEDULE_TIME).Result;
                    ErrCode = ErrCodePartner;
                    break;
                case AppConst.PARTNER_MFS:
                    ErrCodePartner = (new MfsService()).SendSMSAsync(sms.URL_HTTP_1_CSKH, sms.HTTP_USER_CSKH, sms.HTTP_PASS_CSKH, sms.PHONE, sms.SMS_CONTENT, sms.ID.ToString(), sms.SENDER_NAME, "0", String.Empty).Result;
                    ErrCode = ErrCodePartner;
                    break;
                case AppConst.PARTNER_VHT:
                    bool isResult;
                    (new VhtService(sms.URL_HTTP_1_CSKH)).sendSmsReport(sms.HTTP_PASS_CSKH, sms.HTTP_USER_CSKH, sms.PHONE, sms.SENDER_NAME, sms.SMS_CONTENT, sms.ID.ToString(), out ErrCodePartner, out isResult);
                    if (isResult) ErrCode = AppConst.SYS_ERR_OK;
                    else ErrCode = AppConst.SYS_ERR_EXCEPTION;
                    break;
                case AppConst.PARTNER_VIETTEL:
                    result res = (new ViettelService(sms.URL_HTTP_1_CSKH)).wsCpMt(sms.HTTP_USER_CSKH, sms.HTTP_PASS_CSKH, sms.SENDER_NAME, sms.ID.ToString(), sms.PHONE, sms.PHONE, sms.SENDER_NAME, "bulksms", sms.SMS_CONTENT, "0");
                    if (res.result1.Equals("1")) ErrCode = AppConst.SYS_ERR_OK;
                    else ErrCode = AppConst.SYS_ERR_EXCEPTION;
                    ErrCodePartner = Convert.ToInt32(res.result1);
                    break;
                case AppConst.PARTNER_VIETGUYS:
                    resultPartner = (new VietguysService(sms.URL_HTTP_1_CSKH)).send(new SmsInfo()
                    {
                        account = sms.HTTP_USER_CSKH,
                        passcode = sms.HTTP_PASS_CSKH,
                        service_id = sms.SENDER_NAME,
                        phone = sms.PHONE,
                        sms = sms.SMS_CONTENT,
                        transactionid = sms.ID.ToString()
                    });
                    if (!String.IsNullOrEmpty(resultPartner))
                    {
                        ErrCodePartner = Convert.ToInt32(resultPartner);
                        if (ErrCodePartner == sms.ID) ErrCode = AppConst.SYS_ERR_OK;
                        else ErrCode = ErrCodePartner;
                    }
                    else
                    {
                        ErrCode = AppConst.SYS_ERR_UNKNOW;
                    }

                    ErrCode = ErrCodePartner;
                    break;
                case AppConst.PARTNER_IRIS:
                    resultPartner = (new IrisService(sms.URL_HTTP_1_CSKH)).SendSMS(sms.HTTP_USER_CSKH, sms.HTTP_PASS_CSKH, sms.ID.ToString(), sms.SENDER_NAME, sms.PHONE, sms.SMS_CONTENT);
                    if (resultPartner.Contains("<ERRCODE>0</ERRCODE>"))
                    {
                        ErrCode = AppConst.SYS_ERR_OK;
                    }
                    else
                    {
                        ErrCode = 1;
                    }
                    break;
                case AppConst.PARTNER_NEO:
                    resultPartner = (new NeoService(sms.URL_HTTP_1_CSKH)).insertSMS(sms.HTTP_USER_CSKH, sms.HTTP_PASS_CSKH, sms.PHONE, sms.SMS_CONTENT, 1, false, sms.SENDER_NAME, 0, false, sms.ID.ToString());
                    if (!String.IsNullOrEmpty(resultPartner))
                    {
                        string[] listResult = resultPartner.Split('|');
                        ErrCodePartner = Convert.ToInt32(listResult[0]);
                        ErrCode = ErrCodePartner;
                        ErrMessage = (listResult.Length > 1) ? listResult[1] : String.Empty;
                    }
                    else
                    {
                        ErrCode = AppConst.SYS_ERR_UNKNOW;
                    }
                    break;
                default:
                    break;
            }

            sms.ERR_CODE_PARTNER = ErrCodePartner;
            if (ErrCode == AppConst.SYS_ERR_OK)
            {
                sms.ERR_CODE = ErrCode;
                sms.RECEIVE_RESULT = ErrMessage;
                rabbitHelper.PublishMessage(AppConfig.QUEUE_SUCCESS, JsonConvert.SerializeObject(sms));
            }
            else
            {
                sms.ERR_CODE = ErrCode;
                sms.RECEIVE_RESULT = ErrMessage;
                rabbitHelper.PublishMessage(AppConfig.QUEUE_ERROR, JsonConvert.SerializeObject(sms));
            }
        }

        public static void SendSMS_API_QC(RabbitHelper rabbitHelper, IList<SmsModel> listSms)
        {
            int ErrCode = AppConst.SYS_ERR_UNKNOW;
            int ErrCodePartner = AppConst.SYS_ERR_UNKNOW;
            string ReceiveResult = String.Empty;

            try
            {
                string result = String.Empty;
                string[] listPhone = new string[listSms.Count];
                string url = listSms[0].URL_HTTP_1_QC;
                string username = listSms[0].HTTP_USER_QC;
                string password = listSms[0].HTTP_PASS_QC;
                string partner = listSms[0].PARTNER_NAME;
                string sender = listSms[0].SENDER_NAME;
                string content = listSms[0].SMS_CONTENT;
                string sentTime = listSms[0].SCHEDULE_TIME;

                foreach (var item in listSms.Select((value, index) => new { Value = value, Index = index }))
                {
                    listPhone[item.Index] = item.Value.PHONE;
                }

                switch (partner)
                {
                    case AppConst.PARTNER_SOUTH_AMS:
                        IDictionary<string, object> resultData = (new SouthService()).SendSMS_QCAsync(url, password, sender, content, listPhone, CommonUtil.FormatDatetimeToString(sentTime, "yyyyMMddHHmmss", "yyyy/MM/dd HH:mm")).Result;
                        logger.Info(AppConst.A("SendSMS_API_QC SOUTH_AMS", JsonConvert.SerializeObject(resultData, Formatting.Indented)));
                        ErrCodePartner = Convert.ToInt32(resultData[AppConst.ERR_CODE_PARTNER]);
                        ErrCode = Convert.ToInt32(resultData[AppConst.ERR_CODE]);
                        ReceiveResult = resultData[AppConst.RECEIVE_RESULT].ToString();
                        break;
                    case AppConst.PARTNER_VMG_AMS:
                        sentTime = CommonUtil.FormatDatetimeToString(sentTime, "yyyyMMddHHmmss", "dd/MM/yyyy HH:mm");
                        ApiAdsReturn apiAdsReturn = (new VmgService(url)).AdsSendSms(listPhone, sender, content, sentTime, username, password);
                        logger.Info(AppConst.A("SendSMS_API_QC VMG_AMS", sender, content, sentTime, username, password, JsonConvert.SerializeObject(apiAdsReturn, Formatting.Indented)));
                        if (apiAdsReturn != null)
                        {
                            ErrCodePartner = apiAdsReturn.error_code;
                            ErrCode = ErrCodePartner;
                            ReceiveResult = CommonUtil.FormatDatetimeToString(sentTime, "dd/MM/yyyy HH:mm", "dd-MM-yyyy");
                        }
                        else
                        {
                            ErrCode = AppConst.SYS_ERR_UNKNOW;
                            ReceiveResult = "Error call WebService";
                        }
                        break;
                    case AppConst.PARTNER_VIETGUYS_AMS:
                        string resultDataVietguys = (new VietguysService(url)).SendSMS_QCAsync(username, password, sender, content, String.Join(",", listPhone), CommonUtil.FormatDatetimeToString(sentTime, "yyyyMMddHHmmss", "yyyy-mm-dd"), CommonUtil.FormatDatetimeToString(sentTime, "yyyyMMddHHmmss", "HH:mm")).Result;
                        if (!(new string[] { "1", "2", "3" }).Contains(resultDataVietguys))
                        {
                            ErrCode = AppConst.SYS_ERR_OK;
                            ReceiveResult = resultDataVietguys;
                        }
                        else ErrCodePartner = ErrCode = Convert.ToInt32(resultDataVietguys);
                        break;
                    default:
                        break;
                }

                logger.Info(AppConst.A("SendSMS_API_QC", ErrCode, ErrCodePartner, ReceiveResult));

                SmsModel sms = new SmsModel()
                {
                    SMS_TYPE = AppConst.QC,
                    URL_HTTP_1_CSKH = url,
                    HTTP_USER_CSKH = username,
                    HTTP_PASS_CSKH = password,
                    PARTNER_NAME = partner,
                    SENDER_NAME = sender,
                    SMS_CONTENT = content,
                    SCHEDULE_TIME = listSms[0].SCHEDULE_TIME,
                    CAMPAIGN_ID = listSms[0].CAMPAIGN_ID,
                    ERR_CODE_PARTNER = ErrCodePartner,
                    RECEIVE_RESULT = ReceiveResult
                };

                if (ErrCode == AppConst.SYS_ERR_OK)
                {
                    sms.ERR_CODE = ErrCode;
                    sms.RECEIVE_RESULT = ReceiveResult;
                    rabbitHelper.PublishMessage(AppConfig.QUEUE_SUCCESS, JsonConvert.SerializeObject(sms));
                }
                else
                {
                    sms.ERR_CODE = ErrCode;
                    sms.RECEIVE_RESULT = ReceiveResult;
                    rabbitHelper.PublishMessage(AppConfig.QUEUE_ERROR, JsonConvert.SerializeObject(sms));
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("SendSMS_API_QC", ErrCode, ErrCodePartner, ReceiveResult, ex));
            }
        }

        public static void SendSMS_SMPP(RabbitHelper rabbitHelper, SmsModel sms)
        {
            string ErrorMessage = String.Empty;
            int ErrorCode = SmppHelper.SendSMS(sms);

            if (ErrorCode == AppConst.SYS_ERR_OK)
            {
                sms.ERR_CODE = ErrorCode;
                sms.RECEIVE_RESULT = ErrorMessage;
                rabbitHelper.PublishMessage(AppConfig.QUEUE_SUCCESS, JsonConvert.SerializeObject(sms));
            }
            else
            {
                sms.ERR_CODE = ErrorCode;
                sms.RECEIVE_RESULT = ErrorMessage;
                rabbitHelper.PublishMessage(AppConfig.QUEUE_ERROR, JsonConvert.SerializeObject(sms));
            }
        }
    }
}
