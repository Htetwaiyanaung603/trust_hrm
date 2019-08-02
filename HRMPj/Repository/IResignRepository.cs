using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IResignRepository
    {
        Task Save(Resign ot);
        Task Update(Resign ot);
        Task Delete(Resign ot);
        List<Resign> GetResignList();
        List<Resign> GetDetail();
        Resign GetEdit(long? id);
        List<Resign> GetDelete();
        Resign GetDeleteList(long id);
        bool GetExit(long id);
        List<EmployeeInfo> GetEmployeeListByDesignationId(long designationId);
        List<EmployeeInfo> GetEmpListById(long branchId, long departmentId, long designationId,long empId);
        List<Resign> RetrieveResignList();
        void UpdateStatus(long ResignId, string status);
        

    }
}
