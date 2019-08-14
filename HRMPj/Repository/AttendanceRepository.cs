using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;


namespace HRMPj.Repository
{
    public class AttendanceRepository : IAttendance
    {
        private readonly ApplicationDbContext context;

        public AttendanceRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(Attendance ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<AttendancdRecordViewModel> GetAttendaceSearchList(long branchId, long departmentId,DateTime date1,DateTime date2,List<int> daylist)
        {
          
            List<EmployeeInfo> blist = context.Attendances.Include(d => d.EmployeeInfo).Where(b => b.BranchId == branchId && b.DepartmentId == departmentId && b.AttendanceDate >= date1 && b.AttendanceDate <= date2).Select(d=>d.EmployeeInfo).Distinct().ToList();
            List<AttendancdRecordViewModel> attRecordList = new List<AttendancdRecordViewModel>();
            List<String> attList = new List<string>();
            foreach (EmployeeInfo ei in blist)
            {
                attList = new List<string>();
                foreach(var s in daylist)
                {
                    string att = context.Attendances.Where(a => a.AttendanceDate >= date1 && a.AttendanceDate <= date2 && a.EmployeeInfoId == ei.Id && a.AttendanceDate.Day == s).Select(a => a.Status).SingleOrDefault();
                    if (att == null)
                    {
                        att = "Absent";
                    }
                    attList.Add(att);
                }
               
                AttendancdRecordViewModel attRecord = new AttendancdRecordViewModel()
                {
                    EmployeeId = ei.Id,
                    EmployeeName = ei.EmployeeName,
                    AttDateList = attList
                };
                attRecordList.Add(attRecord);
               
            }
            /*var lii = (from a in blist  join e in context.EmployeeInfos  on a.EmployeeInfoId equals e.Id select new AttendancdRecordViewModel { EmployeeId = e.Id, EmployeeName = e.EmployeeName }).GroupBy(e=>e.EmployeeName).ToList() ;
            List<AttendancdRecordViewModel> AttRecord = (from a in blist join e in context.EmployeeInfos on a.EmployeeInfoId equals e.Id select new  AttendancdRecordViewModel  { EmployeeId = e.Id, EmployeeName = e.EmployeeName }).Distinct().ToList();
            */
           /* for (int i = 0; i < AttRecord.Count; i++)
            {
                AttRecord[i].AttDateList = context.Attendances.Where(c => c.AttendanceDate >= date1 && c.AttendanceDate <= date2 && c.EmployeeInfoId == AttRecord[i].EmployeeId).Select(c => c.Status).ToList();
            }
            */
            return attRecordList;

        }

        public List<Attendance> GetAttendanceList()
        {
            List<Attendance> bb = context.Attendances.ToList();
            return bb;
        }

        public List<int> GetDayList(DateTime date1, DateTime date2)
        {
            List<int> Dat = context.Attendances.Where(b => b.AttendanceDate >= date1 && b.AttendanceDate <= date2).OrderBy(b=>b.AttendanceDate).Select(b => b.AttendanceDate.Day).Distinct().ToList();
            return Dat;
        }

        public List<Attendance> GetDelete()
        {
            List<Attendance> lt = context.Attendances.Include(a => a.EmployeeInfo).ToList();
            return lt;
        }

        public Attendance GetDeleteList(long id)
        {
            try
            {
                var com = context.Attendances.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Attendance> GetDetail()
        {
            List<Attendance> lt = context.Attendances.Include(a => a.EmployeeInfo).ToList();
            return lt;
        }

        public Attendance GetEdit(long? id)
        {
            try
            {
                var com = context.Attendances.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.Attendances.Any(e => e.Id == id);
            return dd;
        }

        public async Task Save(Attendance ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(Attendance ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
