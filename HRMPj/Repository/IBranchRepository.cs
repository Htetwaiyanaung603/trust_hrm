using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IBranchRepository
    {
        Task SaveCompany(Branch b);
        List<Branch> GetBranchListByCompany();
        List<Branch> GetBranchList();
        Branch GetBranch(long? Id);
        Task Update(Branch s);
        Branch GetDelete(long id);
        Task Delete(Branch sa);
        bool GetExit(long id);
        
    }
}
