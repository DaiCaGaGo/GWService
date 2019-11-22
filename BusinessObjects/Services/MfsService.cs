using BusinessObjects.Supports;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Services
{
    public class MfsService
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<int> SendSMSAsync(string url, string user, string password, string phone, string message, string tranId, string brandName, string dataEncode, string sendTime)
        {
            string result = String.Empty;

            try
            {
                IDictionary<string, string> smsCSKH = new Dictionary<string, string>() {
                    { "phone", phone },
                    { "mess", message },
                    { "user", user},
                    { "pass", password },
                    { "tranId", tranId },
                    { "brandName", brandName },
                    { "dataEncode", dataEncode },
                    { "sendTime", sendTime }
                };

                HttpResponseMessage response = await CallAPIAsync(url, JsonConvert.SerializeObject(smsCSKH));

                if (response != null)
                {
                    result = await response.Content.ReadAsStringAsync();
                    logger.Info(AppConst.A("SendSMS_CSKHAsync", url, tranId, result));

                    Dictionary<string, dynamic> dict = CommonUtil.ConvertJsonToObject(result);
                    if (dict != null && "1".Equals(dict["code"]))
                    {
                        return AppConst.SYS_ERR_OK;
                    }
                    else if (dict != null && !"0".Equals(dict["code"]))
                    {
                        return Convert.ToInt32(dict["code"]);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("SendSMS_CSKHAsync", url, tranId, result, ex));
            }

            return AppConst.SYS_ERR_UNKNOW;
        }

        private async Task<HttpResponseMessage> CallAPIAsync(string url, string content)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
                    httpRequest.Content = new StringContent(content, Encoding.UTF8, "application/json");
                    return await http.SendAsync(httpRequest);
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("CallAPIAsync", url, content, ex));
                return null;
            }
        }
    }
}
