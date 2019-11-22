using System;
using System.Configuration;
using System.Text;

namespace DataAccessLayer.Supports
{
    public class DALConst
    {
        internal static string ORACLE_CONNECTION = GetValueConfig("ORACLE.CONNECTION");
        internal static string ORACLE_CONNECTION_EDU = GetValueConfig("ORACLE.CONNECTION.EDU");
        internal static string REDIS_CONNECTION = GetValueConfig("REDIS.CONNECTION");

        internal const string SYS_ERR_UNKNOW = "-1";
        internal const string SYS_ERR_EXCEPTION = "-2";
        internal const string VALUE_NULL = "null";
        internal const string P_ERR_CODE = "p_err_code";
        internal const string P_ERR_MESSAGE = "p_err_message";
        internal const string P_REFCURSOR = "p_refcursor";

        internal const string ERR_CODE = "err_code";
        internal const string ERR_MESSAGE = "err_message";
        internal const string DATA = "data";

        internal const int LENGTH_ERR_CODE = 20;
        internal const int LENGTH_ERR_MESSAGE = 225;

        internal const string QUERY_SELECT_PACKAGE = "select distinct PACKAGE_NAME from USER_ARGUMENTS where PACKAGE_NAME is not null order by PACKAGE_NAME";
        internal const string QUERY_SELECT_FUNCTION = "select distinct OBJECT_NAME from USER_ARGUMENTS where PACKAGE_NAME = '{0}'";
        internal const string QUERY_SELECT_ARGUMENT = "select ARGUMENT_NAME, POSITION, DATA_TYPE, IN_OUT from USER_ARGUMENTS where OBJECT_NAME = '{0}' order by POSITION";

        internal static string A(string logString, params object[] logParams)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(logString).Append(".:");
            foreach (object s in logParams)
            {
                sb.Append(" [").Append(s).Append("]");
            }
            return sb.ToString();
        }

        internal static string GetValueConfig(string key)
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
                return String.Empty;
            }
        }
    }
}
