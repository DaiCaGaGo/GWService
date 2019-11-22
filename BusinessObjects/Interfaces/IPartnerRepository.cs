using BusinessObjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessObjects.Interfaces
{
    interface IPartnerRepository
    {
        Task<IList<PartnerErrCodeModel>> GetPartnerErrCodeAsync();
    }
}
