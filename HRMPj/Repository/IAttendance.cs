using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public  interface IAttendance
    {
        Task Save(Attendance ot);
        Task Update(Attendance ot);
        Task Delete(Attendance ot);
        List<Attendance> GetAttendanceList();
        List<Attendance> GetDetail();
        Attendance GetEdit(long? id);
        List<Attendance> GetDelete();
        Attendance GetDeleteList(long id);
        bool GetExit(long id);
        List<AttendancdRecordViewModel> GetAttendaceSearchList(long branchId, long departmentId,DateTime date1,DateTime date2,List<int> date3);
        List<int> GetDayList( DateTime date1, DateTime date2);

    }
}
