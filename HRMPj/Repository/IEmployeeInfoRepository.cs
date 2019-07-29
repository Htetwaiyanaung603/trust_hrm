using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IEmployeeInfoRepository
    {
        Task Save(EmployeeInfo ot);
        Task Update(EmployeeInfo ot);
        Task Delete(EmployeeInfo ot);
        List<EmployeeInfo> GetEmployeeInfoList();
        List<EmployeeInfo> GetDetail();
        EmployeeInfo GetEdit(long? id);
        List<EmployeeInfo> GetDelete();
        EmployeeInfo GetDeleteList(long id);
        bool GetExit(long id);
        List<EmployeeInfo> GetEmployeeListByBranchAndDepartmentId(long branchId,long departmentId);

    }
}
