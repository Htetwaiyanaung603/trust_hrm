using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IDesignationRepository
    {
        Task Save(Designation b);
        List<Designation> GetDesignationListByDepartment();
        List<Designation> GetDesignationList();
        Designation GetDesignation(long? Id);
        Task Update(Designation s);
        Designation GetDelete(long id);
        Task Delete(Designation sa);
        bool GetExit(long id);
        List<Designation> GetDesignationListByDepartmentId(long departmentId);
    }
}
