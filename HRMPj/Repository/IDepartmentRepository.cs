using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IDepartmentRepository
    {
        Task Save(Department b);
        List<Department> GetDepartmentListByBranch();
        List<Department> GetDepartmentListByBranchs(long branchId);
        List<Department> GetDepartmentList();
        Department GetDepartment(long? Id);
        Task Update(Department s);
        Department GetDelete(long id);
        Task Delete(Department sa);
        bool GetExit(long id);
    }
}
