using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace BusinessObjects.Supports
{
    public class CommonUtil
    {
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly string[] VietnameseSigns = new string[] { "aAeEoOuUiIdDyY", "áàạảãâấầậẩẫăắằặẳẵ", "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", "éèẹẻẽêếềệểễ", "ÉÈẸẺẼÊẾỀỆỂỄ", "óòọỏõôốồộổỗơớờợởỡ", "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", "úùụủũưứừựửữ", "ÚÙỤỦŨƯỨỪỰỬỮ", "íìịỉĩ", "ÍÌỊỈĨ", "đ", "Đ", "ýỳỵỷỹ", "ÝỲỴỶỸ" };

        public static Dictionary<string, dynamic> ConvertJsonToObject(string json)
        {
            try
            {
                if (!String.IsNullOrEmpty(ReplaceJson(json)))
                {
                    return JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(ReplaceJson(json));
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                logger.Error(AppConst.A("ConvertJsonToObject", json, e.ToString()));
                return null;
            }
        }

        public static string ReplaceJson(string jsonString)
        {
            if (jsonString.StartsWith("[") || jsonString.EndsWith("]"))
            {
                string stringResult = jsonString.Replace("[", "").Replace("]", "");
                return stringResult;
            }
            return jsonString;
        }

        public static void RunTasks(IList<Task> tasks, int maxTask, CancellationTokenSource cancelToken)
        {
            try
            {
                IList<Task> runningTasks = new List<Task>();
                foreach (Task currentTask in tasks)
                {
                    currentTask.Start();
                    runningTasks.Add(currentTask);
                    if (runningTasks.Where(x => x.Status == TaskStatus.Running).Count() >= ((maxTask < 1) ? 1 : maxTask))
                        Task.WaitAny(runningTasks.ToArray(), cancelToken.Token);
                }
                Task.WaitAll(runningTasks.ToArray(), cancelToken.Token);
            }
            catch (Exception ex)
            {
                logger.Error("RunTasks", ex);
            }
        }

        public static void RunThreads(IList<Thread> threads, int maxThread)
        {
            for (int i = 0; i < threads.Count; i = i + maxThread)
            {
                for (int k = i; k < (i + maxThread); k++)
                    if (k < threads.Count)
                        threads[k].Start();
                for (int k = i; k < (i + maxThread); k++)
                    if (k < threads.Count)
                        threads[k].Join();
            }
        }

        public static string Md5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }

        public static string ShaHash(SHA1 shahash1, string input)
        {
            byte[] data = shahash1.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Convert.ToBase64String(data);
        }

        /// <summary>
        /// Format datetime theo template
        /// </summary>
        /// <param name="input">Dữ liệu đầu vào</param>
        /// <param name="templateIn">Template format dữ liệu đầu vào</param>
        /// <param name="templateOut">Template format dữ liệu return</param>
        /// <returns>Dữ liệu theo template</returns>
        public static string FormatDatetimeToString(string input, string templateIn, string templateOut = "YYYY/MM/DD HH:mm")
        {
            try
            {
                if (!String.IsNullOrEmpty(input))
                {
                    if (!String.IsNullOrEmpty(templateIn))
                    {
                        DateTime dateTime = DateTime.ParseExact(input, templateIn, CultureInfo.InvariantCulture, DateTimeStyles.None);
                        return dateTime.ToString(templateOut);
                    }
                    else
                    {
                        DateTime dateTime;
                        DateTime.TryParse(input, out dateTime);
                        return dateTime.ToString(templateOut);
                    }
                }
                else return String.Empty;
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("ConvertToDateTime", input, templateIn, templateOut, ex));
                return String.Empty;
            }
        }

        public static string AddPhone84(string Phone)
        {
            try
            {
                #region check 10 số đầu 0
                if (Phone.IndexOf("84") != 0 && Phone.Length == 10)
                    return "84" + Phone.Substring(1, Phone.Length - 1);
                #endregion
                #region check 11 số đầu 0
                else if (Phone.Length == 11 && Phone.IndexOf("0") == 0)
                {
                    #region check mạng viettel
                    if (Phone.IndexOf("0162") == 0 || Phone.IndexOf("0163") == 0 || Phone.IndexOf("0164") == 0 ||
                        Phone.IndexOf("0165") == 0 || Phone.IndexOf("0166") == 0 || Phone.IndexOf("0167") == 0 ||
                        Phone.IndexOf("0168") == 0 || Phone.IndexOf("0169") == 0)
                        return "843" + Phone.Substring(3, Phone.Length - 3);
                    #endregion
                    #region check mạng mobifone
                    else if (Phone.IndexOf("0120") == 0) return "8470" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0121") == 0) return "8479" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0122") == 0) return "8477" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0126") == 0) return "8476" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0128") == 0) return "8478" + Phone.Substring(4, Phone.Length - 4);
                    #endregion
                    #region check mạng vinaphone
                    else if (Phone.IndexOf("0123") == 0) return "8483" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0124") == 0) return "8484" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0125") == 0) return "8485" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0127") == 0) return "8481" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0129") == 0) return "8482" + Phone.Substring(4, Phone.Length - 4);
                    #endregion
                    #region check mạng vietnamMobile
                    else if (Phone.IndexOf("0186") == 0) return "8456" + Phone.Substring(4, Phone.Length - 4);
                    else if (Phone.IndexOf("0188") == 0) return "8458" + Phone.Substring(4, Phone.Length - 4);
                    #endregion
                    #region check mạng GMobile
                    else if (Phone.IndexOf("0199") == 0) return "8459" + Phone.Substring(4, Phone.Length - 4);
                    #endregion
                    else return Phone;
                }
                #endregion
                #region check 11 số đầu 84
                else if (Phone.Length == 12 && Phone.IndexOf("84") == 0)
                {
                    #region check mạng viettel
                    if (Phone.IndexOf("84162") == 0 || Phone.IndexOf("84163") == 0 || Phone.IndexOf("84164") == 0 ||
                        Phone.IndexOf("84165") == 0 || Phone.IndexOf("84166") == 0 || Phone.IndexOf("84167") == 0 ||
                        Phone.IndexOf("84168") == 0 || Phone.IndexOf("84169") == 0)
                        return "843" + Phone.Substring(4, Phone.Length - 4);
                    #endregion
                    #region check mạng mobifone
                    else if (Phone.IndexOf("84120") == 0) return "8470" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84121") == 0) return "8479" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84122") == 0) return "8477" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84126") == 0) return "8476" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84128") == 0) return "8478" + Phone.Substring(5, Phone.Length - 5);
                    #endregion
                    #region check mạng vinaphone
                    else if (Phone.IndexOf("84123") == 0) return "8483" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84124") == 0) return "8484" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84125") == 0) return "8485" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84127") == 0) return "8481" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84129") == 0) return "8482" + Phone.Substring(5, Phone.Length - 5);
                    #endregion
                    #region check mạng vietnamMobile
                    else if (Phone.IndexOf("84186") == 0) return "8456" + Phone.Substring(5, Phone.Length - 5);
                    else if (Phone.IndexOf("84188") == 0) return "8458" + Phone.Substring(5, Phone.Length - 5);
                    #endregion
                    #region check mạng GMobile
                    else if (Phone.IndexOf("84199") == 0) return "8459" + Phone.Substring(5, Phone.Length - 5);
                    #endregion
                    else return Phone;
                }
                #endregion
                else if (Phone.Length == 9)
                    return "84" + Phone;
                return Phone;
            }
            catch { return Phone; }
        }

        public static string getLoaiNhaMang(string phone)
        {
            try
            {
                if (!string.IsNullOrEmpty(phone))
                {
                    //phone = AddPhone84(phone);
                    //if (!String.IsNullOrEmpty(phone))
                    //{
                    //    string telco = RedisCache.Get(String.Format("PHONE_CHANGE_TELCO:{0}", phone));
                    //    if (!String.IsNullOrEmpty(telco))
                    //    {
                    //        return telco;
                    //    }
                    //}

                    string a = String.Empty;
                    string b = String.Empty;

                    if (phone.Length > 5)
                    {
                        if (phone.IndexOf("84") == 0)
                        {
                            a = "0" + phone.Substring(2, 2);
                            b = "0" + phone.Substring(2, 3);
                        }
                        else
                        {
                            a = phone.Substring(0, 3);
                            b = phone.Substring(0, 4);
                        }
                    }
                    if (phone.IndexOf("84") == 0)
                    {
                        if (phone.Length == 11) phone = "0" + phone.Substring(0, 9);
                        if (phone.Length == 12) phone = "0" + phone.Substring(0, 10);
                    }

                    List<string> lst_viettel = new List<string> { "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039" };
                    List<string> lst_mobi = new List<string> { "089", "090", "093", "070", "079", "077", "076", "078" };
                    List<string> lst_vina = new List<string> { "088", "091", "094", "083", "084", "085", "081", "082" };
                    List<string> lst_vnMobile = new List<string> { "092", "052", "056", "058" };
                    List<string> lst_gMobile = new List<string> { "099", "059" };

                    if (phone.Length != 10)
                        return String.Empty;
                    if (lst_viettel.Contains(a) || lst_viettel.Contains(b))
                        return AppConst.VIETTEL;
                    if (lst_mobi.Contains(a) || lst_mobi.Contains(b))
                        return AppConst.VMS;
                    if (lst_vina.Contains(a) || lst_vina.Contains(b))
                        return AppConst.GPC;
                    if (lst_vnMobile.Contains(a) || lst_vnMobile.Contains(b))
                        return AppConst.VNM;
                    if (lst_gMobile.Contains(a) || lst_gMobile.Contains(b))
                        return AppConst.GTEL;

                    return String.Empty;
                }
                else
                {
                    logger.Info(AppConst.A("OnStop", "Số điện thoại rỗng"));
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                logger.Info(AppConst.A("OnStop", ex));
                return String.Empty;
            }
        }
        public static string chuyenTiengVietKhongDau(string str)
        {
            //Tiến hành thay thế , lọc bỏ dấu cho chuỗi
            if (str == null || str == "") return "";
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            str = RemoveSpecialCharacters(str);
            str = RemoveDiacritics(str);
            return str;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            str = str.Replace("“", "\"");
            str = str.Replace("”", "\"");
            return Regex.Replace(str, "[@#$%^&*]", "", RegexOptions.Compiled);
        }

        public static string RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return text;

            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

        public static int countNumberSms(string sms_content)
        {
            if (sms_content == "" || sms_content == null) return 0;
            if (sms_content.Length < 161) return 1;
            else if (sms_content.Length > 160 && sms_content.Length < 307) return 2;
            else if (sms_content.Length > 306 && sms_content.Length < 460) return 3;
            else return 0;
        }
    }
}
