using Dapper;
using DataAccessLayer.Supports;
using log4net;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DatabaseHelper
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private Stopwatch stopWatch = new Stopwatch();

        /// <summary>
        /// Get sms pending
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> GetSMSAsync(string storedName, int countSms)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;
            object result = new object();

            var dynamicParam = new OracleDynamicParameters();
            dynamicParam.Add("p_refcursor", OracleDbType.RefCursor, ParameterDirection.Output, null);
            dynamicParam.Add("p_count", OracleDbType.Int32, ParameterDirection.Input, countSms);
            dynamicParam.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);
            dynamicParam.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    result = await SqlMapper.QueryAsync(dbConnection, storedName, param: dynamicParam, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParam.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                    resultReturn.Add(DALConst.DATA, result);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                resultReturn.Add(DALConst.DATA, result);
                logger.Error(DALConst.A("GetSMSAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("GetSMSAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        public async Task<IDictionary<string, object>> UpdateStatusSMSAsync(string storedName, object[] keyValues = null)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;
            object result = new object();

            var dynamicParam = new OracleDynamicParameters();
            dynamicParam.Add("p_id", OracleDbType.Long, ParameterDirection.Input, keyValues[0]);
            dynamicParam.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);
            dynamicParam.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    result = await SqlMapper.QueryAsync(dbConnection, storedName, param: dynamicParam, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParam.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                    resultReturn.Add(DALConst.DATA, result);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                resultReturn.Add(DALConst.DATA, result);
                logger.Error(DALConst.A("ExecBOFunctionAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("ExecBOFunctionAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        public async Task<IDictionary<string, object>> UpdateSMSSuccessAsync(string storedName, string idSms, string smsType, string errorCodePartner,string receiveResult)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;

            OracleDynamicParameters dynamicParams = new OracleDynamicParameters();
            dynamicParams.Add("p_id", OracleDbType.Varchar2, ParameterDirection.Input, idSms);
            dynamicParams.Add("p_sms_type", OracleDbType.Varchar2, ParameterDirection.Input, smsType);
            dynamicParams.Add("p_receive_result", OracleDbType.Varchar2, ParameterDirection.Input, receiveResult);
            dynamicParams.Add("p_partner_err_code", OracleDbType.Varchar2, ParameterDirection.Input, errorCodePartner);
            dynamicParams.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);
            dynamicParams.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    await dbConnection.ExecuteAsync(storedName, param: dynamicParams, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParams.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                logger.Error(DALConst.A("UpdateSMSSentAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("UpdateSMSSentAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        public async Task<IDictionary<string, object>> UpdateSMSErrorAsync(string storedName, long idSms, string smsType, string partnerName, string errorCode)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;

            OracleDynamicParameters dynamicParams = new OracleDynamicParameters();
            dynamicParams.Add("p_id", OracleDbType.Long, ParameterDirection.Input, idSms);
            dynamicParams.Add("p_sms_type", OracleDbType.Varchar2, ParameterDirection.Input, smsType);
            dynamicParams.Add("p_partner_name", OracleDbType.Varchar2, ParameterDirection.Input, partnerName);
            dynamicParams.Add("p_partner_err_code", OracleDbType.Varchar2, ParameterDirection.Input, errorCode);
            dynamicParams.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);
            dynamicParams.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    await dbConnection.ExecuteAsync(storedName, param: dynamicParams, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParams.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                logger.Error(DALConst.A("UpdateSMSSentAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("UpdateSMSSentAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        /// <summary>
        /// Get all error code partner
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> GetPartnerErrCodeAsync(string storedName)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;
            object result = new object();

            var dynamicParam = new OracleDynamicParameters();
            dynamicParam.Add("p_refcursor", OracleDbType.RefCursor, ParameterDirection.Output, null);
            dynamicParam.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 10);
            dynamicParam.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 50);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    result = await SqlMapper.QueryAsync(dbConnection, storedName, param: dynamicParam, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParam.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                    resultReturn.Add(DALConst.DATA, result);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                resultReturn.Add(DALConst.DATA, result);
                logger.Error(DALConst.A("GetPartnerErrCodeAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("GetPartnerErrCodeAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        /// <summary>
        /// Insert phone change telco Edu
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> InsertPhoneChangeTelcoEduAsync(string phone, string telco, string idProcess)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string storedName = "pks_phone_change_telco.pr_post_phone_change_telco";

            try
            {
                OracleDynamicParameters dynamicParams = new OracleDynamicParameters();
                dynamicParams.Add("p_phone", OracleDbType.Varchar2, ParameterDirection.Input, phone);
                dynamicParams.Add("p_telco", OracleDbType.Varchar2, ParameterDirection.Input, telco);
                dynamicParams.Add("p_id_process", OracleDbType.Varchar2, ParameterDirection.Input, idProcess);
                dynamicParams.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 10);

                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION_EDU))
                {
                    await dbConnection.ExecuteAsync(storedName, param: dynamicParams, commandType: CommandType.StoredProcedure);
                    string ErrCode = dynamicParams.oracleParameters[3].Value.ToString();
                    resultReturn.Add(DALConst.ERR_CODE, ErrCode);
                    if (!ErrCode.Equals("0"))
                        logger.Error(DALConst.A("InsertPhoneChangeTelcoAsync", storedName, phone, telco, idProcess, ErrCode));
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, "-1");
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                logger.Error(DALConst.A("InsertPhoneChangeTelcoEduAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("InsertPhoneChangeTelcoEduAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        /// <summary>
        /// Insert phone change telco Gateway
        /// </summary>
        /// <param name="storedName"></param>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<IDictionary<string, object>> InsertPhoneChangeTelcoGatewayAsync(string phone, string telco)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string storedName = "pks_phone_change_telco.pr_post_phone_change_telco";

            try
            {
                OracleDynamicParameters dynamicParams = new OracleDynamicParameters();
                dynamicParams.Add("p_refcursor", OracleDbType.RefCursor, ParameterDirection.Output, null);
                dynamicParams.Add("p_phone", OracleDbType.Varchar2, ParameterDirection.Input, phone);
                dynamicParams.Add("p_telco", OracleDbType.Varchar2, ParameterDirection.Input, telco);
                dynamicParams.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 10);
                dynamicParams.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 50);

                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    await dbConnection.ExecuteAsync(storedName, param: dynamicParams, commandType: CommandType.StoredProcedure);
                    string ErrCode = dynamicParams.oracleParameters[3].Value.ToString();
                    resultReturn.Add(DALConst.ERR_CODE, ErrCode);
                    if (!ErrCode.Equals("0"))
                        logger.Error(DALConst.A("InsertPhoneChangeTelcoGatewayAsync", storedName, phone, telco, ErrCode));
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, "-1");
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                logger.Error(DALConst.A("InsertPhoneChangeTelcoGatewayAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("InsertPhoneChangeTelcoGatewayAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        public async Task<IDictionary<string, object>> GetSmsBirthdayCustomerAsync(string storedName)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;
            object result = new object();

            var dynamicParam = new OracleDynamicParameters();
            dynamicParam.Add("p_refcursor", OracleDbType.RefCursor, ParameterDirection.Output, null);
            dynamicParam.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);
            dynamicParam.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    result = await SqlMapper.QueryAsync(dbConnection, storedName, param: dynamicParam, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParam.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                    resultReturn.Add(DALConst.DATA, result);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                resultReturn.Add(DALConst.DATA, result);
                logger.Error(DALConst.A("GetSmsBirthdayCustomerAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("GetSmsBirthdayCustomerAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        public async Task<IDictionary<string, object>> GetSysVarAsync(string storedName, string varGroup)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;
            object result = new object();

            var dynamicParam = new OracleDynamicParameters();
            dynamicParam.Add("p_refcursor", OracleDbType.RefCursor, ParameterDirection.Output, null);
            dynamicParam.Add("p_var_group", OracleDbType.Varchar2, ParameterDirection.Input, varGroup, 50);
            dynamicParam.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);
            dynamicParam.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    result = await SqlMapper.QueryAsync(dbConnection, storedName, param: dynamicParam, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParam.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                    resultReturn.Add(DALConst.DATA, result);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                resultReturn.Add(DALConst.DATA, result);
                logger.Error(DALConst.A("GetSysVar", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("GetSysVar.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        public async Task<IDictionary<string, object>> InsertSmsBirthdayAsync(string storedName, object[] keyValues = null)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;
            object result = new object();

            var dynamicParam = new OracleDynamicParameters();
            dynamicParam.Add("p_ACCOUNT_ID", OracleDbType.Long, ParameterDirection.Input, keyValues[0]);
            dynamicParam.Add("p_SENDER_NAME", OracleDbType.Varchar2, ParameterDirection.Input, keyValues[1], 11);
            dynamicParam.Add("p_SMS_CONTENT", OracleDbType.Varchar2, ParameterDirection.Input, keyValues[2], 712);
            dynamicParam.Add("p_SMS_COUNT", OracleDbType.Int16, ParameterDirection.Input, keyValues[3]);
            dynamicParam.Add("p_PHONE", OracleDbType.Varchar2, ParameterDirection.Input, keyValues[4], 20);
            dynamicParam.Add("p_TELCO", OracleDbType.Varchar2, ParameterDirection.Input, keyValues[5], 25);
            dynamicParam.Add("p_SCHEDULE_TIME", OracleDbType.Varchar2, ParameterDirection.Input, keyValues[6], 20);
            dynamicParam.Add("p_CREATE_USER", OracleDbType.Varchar2, ParameterDirection.Input, keyValues[7], 20);
            dynamicParam.Add("p_group_id", OracleDbType.Long, ParameterDirection.Input, keyValues[8]);
            dynamicParam.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);
            dynamicParam.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    result = await SqlMapper.QueryAsync(dbConnection, storedName, param: dynamicParam, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParam.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                    resultReturn.Add(DALConst.DATA, result);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                resultReturn.Add(DALConst.DATA, result);
                logger.Error(DALConst.A("InsertSmsBirthdayAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("InsertSmsBirthdayAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }

        public async Task<IDictionary<string, object>> InsertSmsAsync(string storedName, long accountID, string senderName, string sms_type, string smsContent, string partnerName, int smsCount, string phone, string telco, string scheduleTime, string order_name, long? campaign_id, int? is_schedule, string client_sms_id, string via)
        {
            if (logger.IsDebugEnabled)
            {
                stopWatch.Restart();
                stopWatch.Start();
            }

            IDictionary<string, object> resultReturn = new Dictionary<string, object>();
            string v_ErrCode = String.Empty;
            string v_ErrMessage = String.Empty;

            OracleDynamicParameters dynamicParams = new OracleDynamicParameters();
            dynamicParams.Add("p_refcursor", OracleDbType.RefCursor, ParameterDirection.Output, null);
            dynamicParams.Add("p_account_id", OracleDbType.Long, ParameterDirection.Input, accountID);
            dynamicParams.Add("p_sender_name", OracleDbType.Varchar2, ParameterDirection.Input, senderName, 11);
            dynamicParams.Add("p_sms_type", OracleDbType.Varchar2, ParameterDirection.Input, sms_type, 11);
            dynamicParams.Add("p_sms_content", OracleDbType.Varchar2, ParameterDirection.Input, smsContent, 712);
            dynamicParams.Add("p_partner_name", OracleDbType.Varchar2, ParameterDirection.Input, partnerName, 25);
            dynamicParams.Add("p_sms_count", OracleDbType.Int16, ParameterDirection.Input, smsCount);
            dynamicParams.Add("p_phone", OracleDbType.Varchar2, ParameterDirection.Input, phone, 20);
            dynamicParams.Add("p_telco", OracleDbType.Varchar2, ParameterDirection.Input, telco, 20);
            dynamicParams.Add("p_schedule_time", OracleDbType.Varchar2, ParameterDirection.Input, scheduleTime, 20);
            dynamicParams.Add("p_order_name", OracleDbType.Varchar2, ParameterDirection.Input, order_name, 100);
            dynamicParams.Add("p_campaign_id", OracleDbType.Int64, ParameterDirection.Input, campaign_id);
            dynamicParams.Add("p_is_schedule", OracleDbType.Int16, ParameterDirection.Input, is_schedule);
            dynamicParams.Add("p_client_sms_id", OracleDbType.Varchar2, ParameterDirection.Input, client_sms_id);
            dynamicParams.Add("p_via", OracleDbType.Varchar2, ParameterDirection.Input, via, 50);
            dynamicParams.Add("p_err_code", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);
            dynamicParams.Add("p_err_message", OracleDbType.Varchar2, ParameterDirection.Output, null, 100);

            try
            {
                using (IDbConnection dbConnection = new OracleConnection(DALConst.ORACLE_CONNECTION))
                {
                    dbConnection.Open();

                    await dbConnection.ExecuteAsync(storedName, param: dynamicParams, commandType: CommandType.StoredProcedure);

                    foreach (var parameter in dynamicParams.oracleParameters)
                    {
                        if (parameter.Direction == ParameterDirection.Output || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            switch (parameter.ParameterName)
                            {
                                case DALConst.P_ERR_CODE:
                                    if (parameter.Value != DBNull.Value)
                                        v_ErrCode = (parameter.Value.ToString() == DALConst.VALUE_NULL) ? DALConst.SYS_ERR_EXCEPTION : parameter.Value.ToString();
                                    break;
                                case DALConst.P_ERR_MESSAGE:
                                    v_ErrMessage = parameter.Value.ToString();
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    resultReturn.Add(DALConst.ERR_CODE, v_ErrCode);
                    resultReturn.Add(DALConst.ERR_MESSAGE, v_ErrMessage);
                }
            }
            catch (Exception ex)
            {
                resultReturn.Add(DALConst.ERR_CODE, DALConst.SYS_ERR_EXCEPTION);
                resultReturn.Add(DALConst.ERR_MESSAGE, ex);
                logger.Error(DALConst.A("InsertSmsAsync", storedName, ex));
            }

            if (logger.IsDebugEnabled)
            {
                stopWatch.Stop();
                logger.Info(DALConst.A("InsertSmsAsync.:Stopwatch", storedName, stopWatch.ElapsedMilliseconds));
            }

            return resultReturn;
        }
    }
}
