using BusinessObjects.Interfaces;
using BusinessObjects.Models;
using BusinessObjects.Supports;
using DataAccessLayer;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessObjects.Repositorys
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<IList<PartnerErrCodeModel>> GetPartnerErrCodeAsync()
        {
            DatabaseHelper database = new DatabaseHelper();

            try
            {
                IDictionary<string, object> result = await database.GetPartnerErrCodeAsync(AppConfig.API_GET_ERRCODE_PARTNER);
                int v_ErrCode = Convert.ToInt32(result[AppConst.ERR_CODE]);

                if (v_ErrCode == AppConst.SYS_ERR_OK)
                {
                    string json = JsonConvert.SerializeObject(result[AppConst.DATA], Formatting.Indented);
                    IList<PartnerErrCodeModel> errCodeList = JsonConvert.DeserializeObject<IList<PartnerErrCodeModel>>(json);
                    return errCodeList;
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetPartnerErrCodeAsync", ex);
            }

            return null;
        }
    }
}
