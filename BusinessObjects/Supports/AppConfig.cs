using log4net;
using System;
using System.Configuration;

namespace BusinessObjects.Supports
{
    public class AppConfig
    {
        private static readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Connection string
        /// </summary>
        public static string ORACLE_CONNECTION = GetValueConfig("ORACLE.CONNECTION");
        public static string ORACLE_CONNECTION_EDU = GetValueConfig("ORACLE.CONNECTION.EDU");
        public static string RABBIT_CONNECTION = GetValueConfig("RABBIT.CONNECTION");
        public static string REDIS_CONNECTION = GetValueConfig("REDIS.CONNECTION");


        /// <summary>
        /// Partner information
        /// </summary>
        public static string PARTNER_NAME = String.IsNullOrEmpty(GetValueConfig("PARTNER.NAME")) ? "EMTY" : GetValueConfig("PARTNER.NAME");
        public static string PARTNER_QUEUE_TEMP = "partner_{0}_queue";
        public static string PARTNER_QUEUE = String.Format(PARTNER_QUEUE_TEMP, PARTNER_NAME.ToLower());

        /// <summary>
        /// Worker config
        /// </summary>
        public static int WORKER_COUNT = String.IsNullOrEmpty(GetValueConfig("WORKER.COUNT")) ? 1 : Convert.ToInt32(ConfigurationManager.AppSettings["WORKER.COUNT"]);
        public static int WORKER_TASK_COUNT = String.IsNullOrEmpty(GetValueConfig("WORKER.TASK.COUNT")) ? 1 : Convert.ToInt32(ConfigurationManager.AppSettings["WORKER.TASK.COUNT"]);

        public static string SERVICE_MONITOR = GetValueConfig("SERVICE.MONITOR");

        /// <summary>
        /// Queue name
        /// </summary>
        public static string QUEUE_SUCCESS = "global_success_queue";
        public static string QUEUE_ERROR = "global_error_queue";
        public static string QUEUE_PARTNER_SOUTH = "partner_south_queue";
        public static string QUEUE_PARTNER_INCOM = "partner_incom_queue";
        public static string QUEUE_PARTNER_NEO = "partner_neo_queue";
        public static string QUEUE_PARTNER_VMG = "partner_vmg_queue";
        public static string QUEUE_PARTNER_VIETGUYS = "partner_vietguys_queue";
        public static string QUEUE_PARTNER_VNPT = "partner_vnpt_queue";
        public static string QUEUE_PARTNER_VIVAS = "partner_vivas_queue";
        public static string QUEUE_PARTNER_VHT = "partner_vht_queue";
        public static string QUEUE_PARTNER_IRIS = "partner_iris_queue";
        public static string QUEUE_PARTNER_MFS = "partner_mfs_queue";
        public static string QUEUE_PARTNER_VIETTEL = "partner_viettel_queue";
        public static string QUEUE_PARTNER_VIVAS_AMS = "partner_vivas_ams_queue";
        public static string QUEUE_PARTNER_SOUTH_AMS = "partner_south_ams_queue";
        public static string QUEUE_PARTNER_VMG_AMS = "partner_vmg_ams_queue";
        public static string QUEUE_PARTNER_VIETGUYS_AMS = "partner_vietguys_ams_queue";

        /// <summary>
        /// Stored and query from database
        /// </summary>
        public const string QUERY_SELECT_SMS = "select * from SMS";
        public const string QUERY_SELECT_CAMPAIGN = "select * from CAMPAIGN";
        public static string API_GET_SMS_CSKH = "PKS_PROCESS_SMS.PR_GET_SMS_CSKH";
        public static string API_GET_SMS_QC = "PKS_PROCESS_SMS.PR_GET_SMS_QC";
        public static string API_PUT_SMS_SEEN = "PKS_PROCESS_SMS.PR_PUT_SMS_SEEN";
        public static string API_PUT_SMS_SUCCESS = "PKS_PROCESS_SMS.PR_PUT_SMS_SUCCESS";
        public static string API_PUT_SMS_ERROR = "PKS_PROCESS_SMS.PR_PUT_SMS_ERROR";

        public static string API_GET_ERRCODE_PARTNER = "PKS_PARTNERERRCODE.PR_GET_PARTNERERRCODES";

        public static string API_PUT_SMS_BIRTHDAY = "pks_sms_birthday.pr_post_sms_birthday";

        public static string[] ListTelco = { "01", "02", "04", "05", "07", "08" };

        private static string GetValueConfig(string key)
        {
            try
            {
                if (ConfigurationManager.AppSettings[key] != null)
                {
                    return ConfigurationManager.AppSettings[key].ToString();
                }
                else
                {
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
                logger.Error(AppConst.A("GetValueConfig", key, ex));
                return String.Empty;
            }
        }
    }
}
