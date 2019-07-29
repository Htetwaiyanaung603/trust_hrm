using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface ILeaveTypeRepository
    {
        Task<List<LeaveTypeViewModel>> GetIndex();
        List<LeaveType> GetLeaveTypeList();
        Task Save(LeaveType l);
        LeaveType GetEdit(long? Id);
        Task Update(LeaveType ll);
        List<LeaveType> GetDeleteList();
        LeaveType GetDelete(long Id);
        Task Delete(LeaveType ll);
        bool GetExit(long id);
        decimal GetLeaveRemainDay(long LeaveTypeId, long FromEmpId);
    }
}
