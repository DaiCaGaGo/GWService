using BusinessObjects.Models;
using BusinessObjects.Supports;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Services
{
    public class SouthService
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<int> SendSMS_CSKHAsync(string url, string auth, string tranId, string from, string to, string text)
        {
            string result = String.Empty;

            try
            {
                IDictionary<string, string> smsCSKH = new Dictionary<string, string>() {
                    { "tranId", tranId },
                    { "from", from },
                    { "to", to},
                    { "text", text },
                    { "dlr", "1" }
                };

                HttpResponseMessage response = await CallAPIAsync(url, auth, JsonConvert.SerializeObject(smsCSKH));

                if (response != null)
                {
                    result = await response.Content.ReadAsStringAsync();
                    logger.Info(AppConst.A("SendSMS_CSKHAsync", url, auth, tranId, from, to, text, result));

                    Dictionary<string, dynamic> dict = CommonUtil.ConvertJsonToObject(result);
                    if (dict != null && "1".Equals(dict["Status"]))
                    {
                        return AppConst.SYS_ERR_OK;
                    }
                    else if (dict != null && !"0".Equals(dict["Status"]))
                    {
                        return Convert.ToInt32(dict["Status"]);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("SendSMS_CSKHAsync", url, auth, tranId, from, to, text, result, ex));
            }

            return AppConst.SYS_ERR_UNKNOW;
        }

        public async Task<IDictionary<string, object>> SendSMS_QCAsync(string url, string auth, string sender, string msg, string[] listPhone, string sentDate)
        {
            IDictionary<string, object> resultData = new Dictionary<string, object>();
            resultData.Add(AppConst.ERR_CODE, AppConst.SYS_MSG_EXCEPTION);
            resultData.Add(AppConst.ERR_CODE_PARTNER, String.Empty);
            resultData.Add(AppConst.RECEIVE_RESULT, AppConst.SYS_MSG_EXCEPTION);

            try
            {
                IDictionary<string, object> smsQC = new Dictionary<string, object>() {
                    { "Sender", sender },
                    { "Msg", msg },
                    { "ListPhone", listPhone },
                    { "SentDate", sentDate }
                };

                HttpResponseMessage response = await CallAPIAsync(url, auth, JsonConvert.SerializeObject(smsQC));

                if (response != null)
                {
                    string message = await response.Content.ReadAsStringAsync();
                    // {"Status":"1","Code":null,"Description":null,"CampaignId":"4609afe7-e80c-4b55-905a-1f3b3d4f6ddd"}
                    logger.Info(AppConst.A("SendSMS_QCAsync", url, auth, sender, msg, message));

                    if (!String.IsNullOrEmpty(message))
                    {
                        SouthReceiveQCModel southReceiveQC = JsonConvert.DeserializeObject<SouthReceiveQCModel>(message);

                        if (southReceiveQC.Status.Equals("1"))
                        {
                            resultData[AppConst.ERR_CODE] = AppConst.SYS_ERR_OK;
                            resultData[AppConst.ERR_CODE_PARTNER] = southReceiveQC.Status;
                            resultData[AppConst.RECEIVE_RESULT] = southReceiveQC.CampaignId;
                        }
                        else if (!southReceiveQC.Status.Equals("0"))
                        {
                            resultData[AppConst.ERR_CODE] = AppConst.SYS_ERR_UNKNOW;
                            resultData[AppConst.ERR_CODE_PARTNER] = southReceiveQC.Status;
                            resultData[AppConst.RECEIVE_RESULT] = message;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("SendSMS_QCAsync", url, auth, sender, msg, sentDate, ex));
                resultData[AppConst.ERR_CODE] = AppConst.SYS_MSG_EXCEPTION;
                resultData[AppConst.ERR_CODE_PARTNER] = String.Empty;
                resultData[AppConst.RECEIVE_RESULT] = AppConst.SYS_MSG_EXCEPTION;
            }

            return resultData;
        }

        private async Task<HttpResponseMessage> CallAPIAsync(string url, string auth, string content)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
                    httpRequest.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    httpRequest.Headers.Authorization = new AuthenticationHeaderValue("Basic", auth);
                    httpRequest.Content = new StringContent(content, Encoding.UTF8, "application/json");
                    return await http.SendAsync(httpRequest);
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("CallAPIAsync", url, auth, content, ex));
                return null;
            }
        }
    }
}
