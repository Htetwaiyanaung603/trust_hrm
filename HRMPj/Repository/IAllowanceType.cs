using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IAllowanceType
    {
        Task Save(AllowanceType c);
        List<AllowanceType> GetAllowanceList();
        Task<List<AllowanceTypeViewModel>> GetAllowanceViewModelList();
        List<AllowanceType> GetList(long? id);
        AllowanceType GetAllowance(long? Id);
        Task Update(AllowanceType s);
        AllowanceType GetDelete(long id);
        Task Delete(AllowanceType sa);
        bool GetExit(long id);
    }
}
