using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessObjects.Interfaces
{
    public interface ISmsRepository
    {
        Task<IList<SmsModel>> GetSmsListAsync(int count, string smsType);
        void UpdateStatusSMS(IList<SmsModel> listSms);
        Task UpdateSMSSuccessAsync(SmsModel sms);
        Task UpdateSMSErrorAsync(SmsModel sms);
    }
}
