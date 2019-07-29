using HRMPj.Data;
using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext context;

        public LeaveTypeRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task Delete(LeaveType ll)
        {
            context.Remove(ll);
            await context.SaveChangesAsync();
        }

        public LeaveType GetDelete(long Id)
        {
            try
            {
                var com = context.LeaveTypes.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LeaveType> GetDeleteList()
        {
            List<LeaveType> cList = context.LeaveTypes.ToList();
            return cList;
        }

        public LeaveType GetEdit(long? Id)
        {
            try
            {
                var com = context.LeaveTypes.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var ss = context.LeaveTypes.Any(e => e.Id == id);
            return ss;
        }

        public async Task<List<LeaveTypeViewModel>> GetIndex()
        {
            var comList = await (from c in context.LeaveTypes select new LeaveTypeViewModel() { Id = c.Id, TypeName = c.TypeName, CreatedDate = c.CreatedDate, CreatedBy = c.CreatedBy, ServiceDay = c.ServiceDay }).ToAsyncEnumerable<LeaveTypeViewModel>().ToList();
            return comList;
        }

        public decimal GetLeaveRemainDay(long LeaveTypeId, long FromEmpId)
        {
            decimal LeaveRemainDay = 0;
            LeaveType l = context.LeaveTypes.Where(lt => lt.Id == LeaveTypeId).FirstOrDefault();
            long ServiceDay = l.ServiceDay;
            List<LeaveRequest> list = context.LeaveRequests.Where(ep => ep.FromEmployeeInfoId == FromEmpId && ep.LeaveTypeId == LeaveTypeId && ep.Status == LeaveStatus.Approve.ToString() && ep.CurrentYear == DateTime.Now.Year).ToList();
            for (int i = 0; i < list.Count(); i++)
            {
                LeaveRemainDay += list[i].LeaveTotalDay;
            }
            return ServiceDay - LeaveRemainDay;
        }

        public List<LeaveType> GetLeaveTypeList()
        {
            List<LeaveType> cList = context.LeaveTypes.ToList();
            return cList;
        }

        public async Task Save(LeaveType l)
        {
            context.Add(l);
            await context.SaveChangesAsync();
        }

        public async Task Update(LeaveType ll)
        {
            context.Update(ll);
            await context.SaveChangesAsync();
        }
    }
}
