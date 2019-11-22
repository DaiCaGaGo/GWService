using BusinessObjects.Supports;
using DataAccessLayer;
using OperatorGateway.Supports;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessObjects.Repositorys
{
    public class PhoneChangeTelcoRepository
    {
        public void UpdateGateway(IDictionary<String, PhoneChangeTelcoModel> dictPhoneChangeTelco)
        {
            Parallel.ForEach(dictPhoneChangeTelco.Values, new ParallelOptions { MaxDegreeOfParallelism = AppConfig.WORKER_COUNT }, async phoneChangeTelco =>
            {
                string telco = String.Empty;
                switch (phoneChangeTelco.TELCO)
                {
                    case "01":
                        telco = "VMS";
                        break;
                    case "02":
                        telco = "GPC";
                        break;
                    case "04":
                        telco = "VIETTEL";
                        break;
                    case "05":
                        telco = "VNM";
                        break;
                    case "07":
                        telco = "GTEL";
                        break;
                    case "08":
                        telco = "DDMBLE";
                        break;
                    default:
                        telco = "";
                        break;
                }

                await (new DatabaseHelper()).InsertPhoneChangeTelcoGatewayAsync(phoneChangeTelco.PHONE, telco);
            });
        }

        public void UpdateEdu(IDictionary<String, PhoneChangeTelcoModel> dictPhoneChangeTelco)
        {
            Parallel.ForEach(dictPhoneChangeTelco.Values, new ParallelOptions { MaxDegreeOfParallelism = AppConfig.WORKER_COUNT }, async phoneChangeTelco =>
            {
                string telco = String.Empty;
                switch (phoneChangeTelco.TELCO)
                {
                    case "01":
                        telco = "MobiFone";
                        break;
                    case "02":
                        telco = "VinaPhone";
                        break;
                    case "04":
                        telco = "Viettel";
                        break;
                    case "05":
                        telco = "VietnamMobile";
                        break;
                    case "07":
                        telco = "Gmobile";
                        break;
                    case "08":
                        telco = "DDMBLE";
                        break;
                    default:
                        telco = "";
                        break;
                }

                string phone = phoneChangeTelco.PHONE.Substring(2, phoneChangeTelco.PHONE.Length - 2);

                await (new DatabaseHelper()).InsertPhoneChangeTelcoEduAsync(phone, telco, phoneChangeTelco.ID_PROCESS);
            });
        }

        public void UpdateRedis(IDictionary<String, PhoneChangeTelcoModel> dictPhoneChangeTelco)
        {
            Parallel.ForEach(dictPhoneChangeTelco.Values, new ParallelOptions { MaxDegreeOfParallelism = AppConfig.WORKER_COUNT }, phoneChangeTelco =>
            {
                string telco = String.Empty;
                switch (phoneChangeTelco.TELCO)
                {
                    case "01":
                        telco = "VMS";
                        break;
                    case "02":
                        telco = "GPC";
                        break;
                    case "04":
                        telco = "VIETTEL";
                        break;
                    case "05":
                        telco = "VNM";
                        break;
                    case "07":
                        telco = "GTEL";
                        break;
                    case "08":
                        telco = "DDMBLE";
                        break;
                    default:
                        telco = "";
                        break;
                }

                RedisHelper.Set(String.Format("PHONE_CHANGE_TELCO:{0}", phoneChangeTelco.PHONE), telco);
            });
        }
    }
}
