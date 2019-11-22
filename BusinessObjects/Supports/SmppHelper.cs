using BusinessObjects.Models;
using Inetlab.SMPP;
using Inetlab.SMPP.Common;
using Inetlab.SMPP.PDU;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;

namespace BusinessObjects.Supports
{
    public class SmppHelper
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static SmppClient smppClient;

        public static void Initialize()
        {
            smppClient = new SmppClient();
            smppClient.Timeout = 4000;
            smppClient.NeedEnquireLink = true;
            smppClient.EnquireInterval = 5;
            smppClient.SendSpeedLimit = 50;
            smppClient.RaiseEventsInMainThread = true;
        }

        public static bool ConnectSMPP(IList<SmppModel> listSMPP)
        {
            try
            {
                if (smppClient == null)
                {
                    Initialize();
                }

                if (smppClient.Status == ConnectionStatus.Closed)
                {
                    foreach (var smpp in listSMPP)
                    {
                        logger.Info(AppConst.A("ConnectSMPP", "Start connect!", smpp.HOST_NAME, smpp.PORT, smpp.SYSTEM_ID, smpp.PASSWORD));

                        if (!String.IsNullOrEmpty(smpp.HOST_NAME) && !String.IsNullOrEmpty(smpp.SYSTEM_ID))
                        {
                            smppClient.AddrTon = smpp.ADDR_TON;
                            smppClient.AddrNpi = smpp.ADDR_NPI;
                            smppClient.SystemType = String.Empty;
                            smppClient.EnabledSslProtocols = SslProtocols.None;

                            if (smppClient.Connect(smpp.HOST_NAME, smpp.PORT))
                            {
                                var bindResp = smppClient.Bind(smpp.SYSTEM_ID, smpp.PASSWORD, ConnectionMode.Transmitter);
                                if (bindResp.Status == CommandStatus.ESME_ROK)
                                {
                                    logger.Info(AppConst.A("ConnectSMPP", "Connected!", bindResp.Status));
                                    return true;
                                }
                                else
                                {
                                    logger.Error(AppConst.A("ConnectSMPP", "Username or password invalid!", bindResp.Status));
                                }
                            }
                            else
                            {
                                logger.Error(AppConst.A("ConnectSMPP", "Connect fail!"));
                            }
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("ConnectSMPP", listSMPP.Count, ex));
            }

            return false;
        }

        public static int SendSMS(SmsModel sms)
        {
            bool IsConnected = SmppHelper.smppClient.Connected;

            if (!IsConnected)
            {
                IList<SmppModel> listSMPP = new List<SmppModel>();

                if (!String.IsNullOrEmpty(sms.SMPP_IP_1))
                {
                    listSMPP.Add(new SmppModel()
                    {
                        HOST_NAME = sms.SMPP_IP_1,
                        PORT = String.IsNullOrEmpty(sms.SMPP_PORT_1) ? 0 : Convert.ToInt32(sms.SMPP_PORT_1),
                        ADDR_TON = Convert.ToByte("1"),
                        ADDR_NPI = Convert.ToByte("1"),
                        SYSTEM_ID = sms.SMPP_USER,
                        PASSWORD = sms.SMPP_PASS
                    });
                }

                if (!String.IsNullOrEmpty(sms.SMPP_IP_2))
                {
                    listSMPP.Add(new SmppModel()
                    {
                        HOST_NAME = sms.SMPP_IP_2,
                        PORT = String.IsNullOrEmpty(sms.SMPP_PORT_2) ? 0 : Convert.ToInt32(sms.SMPP_PORT_2),
                        ADDR_TON = Convert.ToByte("1"),
                        ADDR_NPI = Convert.ToByte("1"),
                        SYSTEM_ID = sms.SMPP_USER,
                        PASSWORD = sms.SMPP_PASS
                    });
                }

                IsConnected = SmppHelper.ConnectSMPP(listSMPP);
            }

            if (IsConnected && SmppHelper.smppClient.Connected)
            {
                IList<SubmitSmResp> response = SmppHelper.smppClient.Submit(
                    SMS.ForSubmit()
                    .From(sms.SENDER_NAME.Trim())
                    .To(sms.PHONE.Trim()).Coding(DataCodings.Default)
                    .Text(sms.SMS_CONTENT.Trim())
                    .DeliveryReceipt());

                if (response.All(x => x.Status == CommandStatus.ESME_ROK))
                {
                    logger.Info(AppConst.A("SendSMS_SMPP", sms.SENDER_NAME, sms.PHONE, sms.SMS_CONTENT, response[0].Status, response[0].MessageId, response[0].Request));
                    return AppConst.SYS_ERR_OK;
                }
                else
                {
                    logger.Info(AppConst.A("SendSMS_SMPP", response[0].MessageId, response[0].Request));
                    return (int)response[0].Status;
                }
            }
            else
            {
                logger.Info(AppConst.A("SendSMS_SMPP", "Connect SMPP fail!", "Switch send SMS to API"));
                return AppConst.SYS_ERR_EXCEPTION;
            }
        }
    }
}
