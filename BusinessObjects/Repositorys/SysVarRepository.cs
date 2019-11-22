using BusinessObjects.Models;
using BusinessObjects.Supports;
using DataAccessLayer;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.Repositorys
{
    public class SysVarRepository
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<IList<SysVarModel>> GetKeyWorkCSKH()
        {
            try
            {
                IDictionary<string, object> result = await (new DatabaseHelper()).GetSysVarAsync("pks_sysvar.pr_get_sysvar_by_group", "KEYWORDS_CSKH");
                int v_ErrCode = Convert.ToInt32(result[AppConst.ERR_CODE]);
                if (v_ErrCode == AppConst.SYS_ERR_OK)
                {
                    string json = JsonConvert.SerializeObject(result[AppConst.DATA], Formatting.Indented);
                    IList<SysVarModel> listKey = JsonConvert.DeserializeObject<IList<SysVarModel>>(json);
                    return listKey;
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetKeyWorkCSKH", ex);
            }

            return null;
        }
    }
}
