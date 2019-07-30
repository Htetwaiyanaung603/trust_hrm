using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public LeaveRequestRepository(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor)
        {
            this.context = _context;
            this.httpContextAccessor = _httpContextAccessor;
        }

        public async Task Delete(LeaveRequest ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<LeaveRequest> GetDelete()
        {
            List<LeaveRequest> lt = context.LeaveRequests.Include(l => l.LeaveType).ToList();
            return lt;
        }

        public LeaveRequest GetDeleteList(long id)
        {
            try
            {
                var com = context.LeaveRequests.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<LeaveRequest> GetDetail()
        {
            List<LeaveRequest> lt = context.LeaveRequests.Include(l => l.LeaveType).Include(l => l.FromEmployeeInfo).Include(l => l.ToEmployeeInfo).ToList();
            return lt;
        }

        public LeaveRequest GetEdit(long? id)
        {
            try
            {
                var com = context.LeaveRequests.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.LeaveRequests.Any(e => e.Id == id);
            return dd;
        }

        public List<LeaveRequest> GetLeaveRequestList()
        {
            List<LeaveRequest> bb = context.LeaveRequests.ToList();
            return bb;
        }

        public List<LeaveRequest> GetStatus(DateTime LeaveFromDate, DateTime LeaveToDate, string Status)
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            long EmployeeId = context.EmployeeInfos.Where(e => e.UserId == userId).SingleOrDefault().Id;
            List<LeaveRequest> leave = context.LeaveRequests.Include(l => l.LeaveType).Include(l => l.FromEmployeeInfo).Where(l => l.ToEmployeeInfoId == EmployeeId && l.Status == Status && l.LeaveFromDate.Date >= LeaveFromDate.Date && l.LeaveToDate.Date <= LeaveToDate.Date).ToList();
            return leave;
        }

        public List<LeaveRequest> RetrieveLeaveRequestList()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            long EmployeeId = context.EmployeeInfos.Where(e => e.UserId == userId).SingleOrDefault().Id;
            List<LeaveRequest> leave = context.LeaveRequests.Include(l => l.LeaveType).Include(l => l.FromEmployeeInfo).Where(l => l.ToEmployeeInfoId == EmployeeId && l.Status == LeaveStatus.Pending.ToString()).ToList();
            return leave;
        }

       

        public async Task Save(LeaveRequest ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(LeaveRequest ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }

        public async Task UpdateStatus(long LeaveRequestId, string status)
        {
            LeaveRequest request = context.LeaveRequests.Find(LeaveRequestId);
            request.Status = status;
            context.UpdateRange(request);
            await context.SaveChangesAsync();
        }
    }

}

