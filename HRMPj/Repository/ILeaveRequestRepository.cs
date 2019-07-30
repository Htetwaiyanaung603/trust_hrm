using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public  interface ILeaveRequestRepository
    {
        Task Save(LeaveRequest ot);
        Task Update(LeaveRequest ot);
        Task Delete(LeaveRequest ot);
        List<LeaveRequest> GetLeaveRequestList();
        List<LeaveRequest> GetDetail();
        LeaveRequest GetEdit(long? id);
        List<LeaveRequest> GetDelete();
        LeaveRequest GetDeleteList(long id);
        bool GetExit(long id);
        List<LeaveRequest> RetrieveLeaveRequestList();
        Task UpdateStatus(long LeaveRequestId,string status);
        List<LeaveRequest> GetStatus(DateTime LeaveFromDate, DateTime LeaveToDate, string Status); 

    }
}
