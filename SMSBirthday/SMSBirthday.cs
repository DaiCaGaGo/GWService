using BusinessObjects.Models;
using BusinessObjects.Repositorys;
using BusinessObjects.Supports;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace SMSBirthday
{
    public partial class SMSBirthday : ServiceBase
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SMSBirthday()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            logger.Info(AppConst.A("OnStart", "Start service SMSBirthday"));
            IList<CustomerModel> listSms = (new CustomerRepository()).GetSmsBirthdayCustomerAsync().Result;
            logger.Info(AppConst.A("GetListCustomer", listSms.Count));
            IList<SysVarModel> listKey = (new SysVarRepository()).GetKeyWorkCSKH().Result;
            if (listSms.Count > 0)
            {
                for (int i = 0; i < listSms.Count; i++)
                {
                    String content = listSms[i].SMS_SEND;
                    content = CommonUtil.chuyenTiengVietKhongDau(content);
                    String phone = listSms[i].PHONE;
                    phone = CommonUtil.AddPhone84(phone);
                    string telco = CommonUtil.getLoaiNhaMang(phone);
                    int count = CommonUtil.countNumberSms(content);

                    #region check keyword
                    SysVarModel sysVarModel = listKey.FirstOrDefault(sysVar => sysVar.VAR_NAME == telco);
                    var checkKeyword = 0;
                    if (sysVarModel != null)
                    {
                        var arrKey = sysVarModel.VAR_VALUE.Split(';');
                        foreach (var key in arrKey)
                        {
                            var key_compare = key.ToLower();
                            var content_compare = content.ToLower();
                            if (key_compare != "" && key_compare != null && content.Contains(key_compare)) checkKeyword++;
                        }
                    }
                    #endregion

                    if (checkKeyword == 0 && !string.IsNullOrEmpty(telco) && !string.IsNullOrEmpty(content))
                    {
                        SmsBirthdayModel detail = new SmsBirthdayModel();
                        detail.ACCOUNT_ID = listSms[i].ACCOUNT_ID;
                        detail.SENDER_NAME = listSms[i].SENDER_NAME;
                        detail.SMS_CONTENT = content;
                        detail.SMS_COUNT = count;
                        detail.PHONE = phone;
                        detail.TELCO = telco;
                        detail.SCHEDULE_TIME = DateTime.Now.Year + "" + listSms[i].MONTH_SEND + "" + listSms[i].DAY_SEND + "" + listSms[i].HOUR_SEND;
                        detail.GROUP_ID = listSms[i].GROUP_ID;
                        (new SmsBirthdayRepository()).InsertSmsBirthday(detail).Wait();
                        logger.Info(AppConst.A("InsertSmsBirthday", phone, content, DateTime.Now.Year + "" + listSms[i].MONTH_SEND + "" + listSms[i].DAY_SEND));
                    }
                }
            }

            IList<SmsBirthdayModel> listSmsWaiting = (new SmsBirthdayRepository()).GetSmsBirthdayWaiting().Result;
            for (int i = 0; i < listSmsWaiting.Count; i++)
            {
                String content = listSmsWaiting[i].SMS_CONTENT;
                content = CommonUtil.chuyenTiengVietKhongDau(content);
                String phone = listSmsWaiting[i].PHONE;
                phone = CommonUtil.AddPhone84(phone);
                string telco = CommonUtil.getLoaiNhaMang(phone);
                int count = CommonUtil.countNumberSms(content);

                if (!string.IsNullOrEmpty(listSmsWaiting[i].GROUP_ID.ToString()))
                {
                    SmsModel sms = new SmsModel();
                    sms.ACCOUNT_ID = listSmsWaiting[i].ACCOUNT_ID;
                    sms.SENDER_NAME = listSmsWaiting[i].SENDER_NAME;
                    sms.PARTNER_NAME = listSmsWaiting[i].PARTNER_NAME;
                    sms.SMS_CONTENT = content;
                    sms.SMS_TYPE = "CSKH";
                    sms.PHONE = phone;
                    sms.SMS_COUNT = count;
                    sms.TELCO = telco;
                    sms.SCHEDULE_TIME = listSmsWaiting[i].SCHEDULE_TIME;
                    sms.VIA = "SMS_BIRTHDAY";
                    (new SmsRepository()).InsertSmsBirthday(sms).Wait();
                    logger.Info(AppConst.A("InsertSms", listSmsWaiting[i].SENDER_NAME, phone, content, listSmsWaiting[i].SCHEDULE_TIME));
                }
            }
        }

        protected override void OnStop()
        {
            logger.Info(AppConst.A("OnStop", "Stop service SMSBirthday"));
        }
    }
}
