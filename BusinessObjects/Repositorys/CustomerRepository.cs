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
    public class CustomerRepository
    {
        private readonly ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public async Task<IList<CustomerModel>> GetSmsBirthdayCustomerAsync()
        {
            try
            {
                IDictionary<string, object> result = await (new DatabaseHelper()).GetSmsBirthdayCustomerAsync("pks_customer.pr_get_customer_sms_birthday");
                int v_ErrCode = Convert.ToInt32(result[AppConst.ERR_CODE]);
                if (v_ErrCode == AppConst.SYS_ERR_OK)
                {
                    string json = JsonConvert.SerializeObject(result[AppConst.DATA], Formatting.Indented);
                    IList<CustomerModel> smsList = JsonConvert.DeserializeObject<IList<CustomerModel>>(json);
                    //logger.Info(AppConst.A("GetSmsBirthdayCustomerAsync", json));
                    return smsList;
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetSmsBirthdayCustomerAsync", ex);
            }

            return null;
        }
    }
}
