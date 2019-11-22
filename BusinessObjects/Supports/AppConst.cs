using System.Text;

namespace BusinessObjects.Supports
{
    public class AppConst
    {
        public const int SYS_ERR_OK = 0;
        public const int SYS_ERR_UNKNOW = -1;
        public const int SYS_ERR_EXCEPTION = -2;

        public const string SYS_MSG_OK = "Success";
        public const string SYS_MSG_UNKNOW = "Lỗi chưa được định nghĩa";
        public const string SYS_MSG_EXCEPTION = "Lỗi hệ thống";

        /// <summary>
        /// Template return json
        /// </summary>
        public const string ERR_CODE = "err_code";
        public const string ERR_CODE_PARTNER = "err_code_partner";
        public const string ERR_MESSAGE = "err_message";
        public const string DATA = "data";
        public const string RECEIVE_RESULT = "receive_result";

        /// <summary>
        /// Template return store
        /// </summary>
        public const string P_ERR_CODE = "p_err_code";
        public const string P_ERR_MESSAGE = "p_err_message";
        public const string P_REFCURSOR = "p_refcursor";

        /// <summary>
        /// Partner name
        /// </summary>
        public const string PARTNER_SOUTH = "SOUTH";
        public const string PARTNER_SOUTH_AMS = "SOUTH_AMS";
        public const string PARTNER_INCOM = "INCOM";
        public const string PARTNER_VNPT = "VNPT";
        public const string PARTNER_IRIS = "IRIS";
        public const string PARTNER_VIVAS = "VIVAS";
        public const string PARTNER_VIVASAMS_AMS = "VIVAS_AMS";
        public const string PARTNER_VIETGUYS = "VIETGUYS";
        public const string PARTNER_VIETGUYS_AMS = "VIETGUYS_AMS";
        public const string PARTNER_VHT = "VHT";
        public const string PARTNER_NEO = "NEO";
        public const string PARTNER_VMG = "VMG";
        public const string PARTNER_VMG_AMS = "VMG_AMS";
        public const string PARTNER_MFS = "MFS";
        public const string PARTNER_VIETTEL = "VIETTEL";

        public const string SMPP = "SMPP";
        public const string API = "API";
        public const string CSKH = "CSKH";
        public const string QC = "QC";
        public const int LIMIT_QC = 50000;


        /// <summary>
        /// Telco
        /// </summary>
        public const string GPC = "GPC";
        public const string VNM = "VNM";
        public const string VMS = "VMS";
        public const string GTEL = "GTEL";
        public const string SFONE = "SFONE";
        public const string VIETTEL = "VIETTEL";
        public const string DDMOBILE = "DDMBLE";

        public static string A(string logString, params object[] logParams)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(logString).Append(".:");
            foreach (object s in logParams)
            {
                sb.Append(" [").Append(s).Append("]");
            }
            return sb.ToString();
        }
    }
}
