using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
    public interface IAllowanceDetailRepository
    {
        Task Save(AllowanceDetail b);
        List<AllowanceDetail> GetAllowanceDetailListBy();
        List<AllowanceDetail> GetAllowanceDetailList();
        AllowanceDetail GetAllowanceDetail(long? Id);
        Task Update(AllowanceDetail s);
        AllowanceDetail GetDelete(long id);
        Task Delete(AllowanceDetail sa);
        bool GetExit(long id);
    }
}
