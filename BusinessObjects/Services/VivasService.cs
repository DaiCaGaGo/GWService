using BusinessObjects.Supports;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Services
{
    public static class VivasService
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string _cookies = String.Empty;

        public static async Task<int> SendSMS_APIAsync(string url, string username, string password, string requestId, string senderName, string phone, string message, string sentTime)
        {
            try
            {
                IDictionary<string, object> sms = new Dictionary<string, object>() {
                    { "reqid", requestId },
                    { "username", username },
                    { "password", password},
                    { "brandname", senderName },
                    { "textmsg", message },
                    { "sendtime", sentTime},
                    { "isunicode", 0 },
                    { "listmsisdn", phone }
                };

                using (HttpClient http = new HttpClient())
                {
                    HttpRequestMessage httpRequest = new HttpRequestMessage(HttpMethod.Post, url);
                    string body = JsonConvert.SerializeObject(sms);
                    logger.Info(AppConst.A("SendSMS_APIAsync", body));
                    httpRequest.Content = new StringContent(body, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await http.SendAsync(httpRequest);

                    if (response != null)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        logger.Info(AppConst.A("SendSMS_APIAsync", url, result));

                        Dictionary<string, dynamic> dict = CommonUtil.ConvertJsonToObject(result);
                        if (dict != null) return Convert.ToInt32(dict["code"]);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("SendSMS_APIAsync", url, username, password, requestId, senderName, phone, message, sentTime, ex));
            }

            return AppConst.SYS_ERR_UNKNOW;
        }


        public static int SendSMS_CSKH(string url, string username, string password, string requestId, string senderName, string phone, string message, string sendTime)
        {
            int ErrCode = AppConst.SYS_ERR_UNKNOW;

            string inputchecksum = String.Format("username={0}&password={1}&brandname={2}&sendtime={3}&msgid={4}&msg={5}&msisdn={6}&sharekey={7}",
                    username, CommonUtil.ShaHash(SHA1.Create(), password),
                    senderName, sendTime, requestId, message, phone, "654321");

            string alsms = message.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;");

            var dataSendSms = String.Format("<RQST><REQID>{0}</REQID><BRANDNAME>{1}</BRANDNAME><TEXTMSG>{2}</TEXTMSG><SENDTIME>{3}</SENDTIME><TYPE>{4}</TYPE><DESTINATION><MSGID>{0}</MSGID><MSISDN>{5}</MSISDN><CHECKSUM>{6}</CHECKSUM></DESTINATION></RQST>",
                                                requestId, senderName.Replace("&", "&amp;"), WebUtility.HtmlEncode(alsms), sendTime, "1", phone, CommonUtil.Md5Hash(MD5.Create(), inputchecksum));

            string respone = (new WebRequest(url, "POST", dataSendSms, _cookies)).GetResponse();
            ErrCode = GetStringResultFromCode(respone);

            if (ErrCode == 20)
            {
                string dataLogIn = String.Format("<RQST><USERNAME>{0}</USERNAME><PASSWORD>{1}</PASSWORD></RQST>", username, CommonUtil.ShaHash(SHA1.Create(), password));
                WebRequest webRequest = new WebRequest("http://123.30.23.179:9080/SMSBNAPI/login", "POST", dataLogIn);
                string responeLogIn = webRequest.GetResponseCookie();
                int statusLogIn = GetStringResultFromCode(responeLogIn);
                if (statusLogIn == AppConst.SYS_ERR_OK)
                {
                    _cookies = webRequest._header;
                }

                dataSendSms = String.Format("<RQST><REQID>{0}</REQID><BRANDNAME>{1}</BRANDNAME><TEXTMSG>{2}</TEXTMSG><SENDTIME>{3}</SENDTIME><TYPE>{4}</TYPE><DESTINATION><MSGID>{0}</MSGID><MSISDN>{5}</MSISDN><CHECKSUM>{6}</CHECKSUM></DESTINATION></RQST>",
                                                requestId, senderName.Replace("&", "&amp;"), alsms, sendTime, "1", phone, inputchecksum);

                string responeReTry = (new WebRequest(url, "POST", dataSendSms, _cookies)).GetResponse();
                return GetStringResultFromCode(responeReTry);
            }

            return AppConst.SYS_ERR_UNKNOW;
        }

        public static int SendSMS_QC(string url, string username, string password, string requestId, string senderName, string phone, string resms, string sendTime)
        {
            int ErrCode = AppConst.SYS_ERR_UNKNOW;

            string inputchecksum = String.Format("username={0}&password={1}&brandname={2}&sendtime={3}&msgid={4}&msg={5}&msisdn={6}&sharekey={7}",
                    username, CommonUtil.ShaHash(SHA1.Create(), password),
                    senderName, sendTime, requestId, resms, phone, "654321");

            string alsms = resms.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("'", "&apos;");

            var dataSendSms = String.Format("<RQST><REQID>{0}</REQID><BRANDNAME>{1}</BRANDNAME><TEXTMSG>{2}</TEXTMSG><SENDTIME>{3}</SENDTIME><TYPE>{4}</TYPE><DESTINATION><MSGID>{0}</MSGID><MSISDN>{5}</MSISDN><CHECKSUM>{6}</CHECKSUM></DESTINATION></RQST>",
                                                requestId, senderName.Replace("&", "&amp;"), WebUtility.HtmlEncode(alsms), sendTime, "2", phone, CommonUtil.Md5Hash(MD5.Create(), inputchecksum));

            string respone = (new WebRequest(url, "POST", dataSendSms, _cookies)).GetResponse();
            ErrCode = GetStringResultFromCode(respone);

            if (ErrCode == 20)
            {
                string dataLogIn = String.Format("<RQST><USERNAME>{0}</USERNAME><PASSWORD>{1}</PASSWORD></RQST>", username, CommonUtil.ShaHash(SHA1.Create(), password));
                WebRequest webRequest = new WebRequest("http://123.30.23.179:9080/SMSBNAPI/login", "POST", dataLogIn);
                string responeLogIn = webRequest.GetResponseCookie();
                int statusLogIn = GetStringResultFromCode(responeLogIn);
                if (statusLogIn == AppConst.SYS_ERR_OK)
                {
                    _cookies = webRequest._header;
                }

                dataSendSms = String.Format("<RQST><REQID>{0}</REQID><BRANDNAME>{1}</BRANDNAME><TEXTMSG>{2}</TEXTMSG><SENDTIME>{3}</SENDTIME><TYPE>{4}</TYPE><DESTINATION><MSGID>{0}</MSGID><MSISDN>{5}</MSISDN><CHECKSUM>{6}</CHECKSUM></DESTINATION></RQST>",
                                                requestId, senderName.Replace("&", "&amp;"), alsms, sendTime, "2", phone, inputchecksum);

                string responeReTry = (new WebRequest(url, "POST", dataSendSms, _cookies)).GetResponse();
                return GetStringResultFromCode(responeReTry);
            }

            return AppConst.SYS_ERR_UNKNOW;
        }

        private static int GetStringResultFromCode(string xml)
        {
            if (xml.Contains("<STATUS>"))
            {
                int start = xml.IndexOf("<STATUS>", StringComparison.Ordinal) + 8;
                int end = xml.IndexOf("</STATUS>", StringComparison.Ordinal);
                return Convert.ToInt32(xml.Substring(start, end - start));
            }

            return AppConst.SYS_ERR_UNKNOW;
        }
    }

    public class WebRequest
    {
        private readonly System.Net.WebRequest _request;
        private Stream _dataStream;
        private string _status;
        public string _header;

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public WebRequest(string url)
        {
            _request = System.Net.WebRequest.Create(url);
        }

        public WebRequest(string url, string method)
            : this(url)
        {
            if (method.Equals("GET") || method.Equals("POST"))
            {
                _request.Method = method;
            }
            else
                throw new Exception("invalid method type");
        }

        public WebRequest(string url, string method, string data)
            : this(url, method)
        {
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            _request.ContentType = "application/xml";
            _request.ContentLength = byteArray.Length;
            _dataStream = _request.GetRequestStream();
            _dataStream.Write(byteArray, 0, byteArray.Length);
            _dataStream.Close();
        }

        public WebRequest(string url, string method, string data, string setcookies)
            : this(url, method)
        {
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            _request.ContentType = "application/x-www-form-urlencoded";
            _request.Headers.Add("Cookie", setcookies);
            _request.ContentLength = byteArray.Length;
            _dataStream = _request.GetRequestStream();
            _dataStream.Write(byteArray, 0, byteArray.Length);
            _dataStream.Close();
        }

        public string GetResponse()
        {
            WebResponse response = _request.GetResponse();
            this.Status = ((HttpWebResponse)response).StatusDescription;
            _dataStream = response.GetResponseStream();
            if (_dataStream != null)
            {
                StreamReader reader = new StreamReader(_dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                if (_dataStream != null) _dataStream.Close();
                response.Close();
                return responseFromServer;
            }

            return "";
        }

        public string GetResponseCookie()
        {
            WebResponse response = _request.GetResponse();
            this.Status = ((HttpWebResponse)response).StatusDescription;
            _dataStream = response.GetResponseStream();
            _header = response.Headers["Set-Cookie"];
            if (_dataStream != null)
            {
                StreamReader reader = new StreamReader(_dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                _dataStream.Close();
                response.Close();
                return responseFromServer;
            }

            return "";
        }
    }
}
