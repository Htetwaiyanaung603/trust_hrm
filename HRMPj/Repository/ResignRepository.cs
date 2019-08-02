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
    public class ResignRepository : IResignRepository
    {
        private readonly ApplicationDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ResignRepository(ApplicationDbContext _context, IHttpContextAccessor _httpContextAccessor)
        {
            this.context = _context;
            this.httpContextAccessor = _httpContextAccessor;
        }
        public async Task Delete(Resign ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<Resign> GetDelete()
        {
            List<Resign> a = context.Resigns.ToList();
            return a;
        }

        public Resign GetDeleteList(long id)
        {
            try
            {
                var com = context.Resigns.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Resign> GetDetail()
        {
            List<Resign> a = context.Resigns.Include(l => l.FromEmployeeInfo).Include(l => l.ToEmployeeInfo).ToList();
            return a;
        }

        public Resign GetEdit(long? id)
        {
            try
            {
                var com = context.Resigns.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeInfo> GetEmpListById(long branchId, long departmentId, long designationId, long empId)
        {
            List<EmployeeInfo> blist = context.EmployeeInfos.Include(d => d.Designation).Where(b => b.BranchId == branchId && b.DepartmentId == departmentId && b.DesignationId == designationId && b.Id == empId).ToList();
            return blist;
        }

        public List<EmployeeInfo> GetEmployeeListByDesignationId(long designationId)
        {
            List<EmployeeInfo> blist = context.EmployeeInfos.Where(b => b.DesignationId == designationId).ToList();
            return blist;
        }

        public bool GetExit(long id)
        {
            var dd = context.Resigns.Any(e => e.Id == id);
            return dd;
        }

        public List<Resign> GetResignList()
        {
            List<Resign> bb = context.Resigns.ToList();
            return bb;
        }

        public List<Resign> RetrieveResignList()
        {
            var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            long EmployeeId = context.EmployeeInfos.Where(e => e.UserId == userId).SingleOrDefault().Id;
            List<Resign> res = context.Resigns.Include(l => l.FromEmployeeInfo).Where(l => l.ToEmployeeInfoId == EmployeeId && l.Status == "Pending").ToList();
            return res;
        }

        public async Task Save(Resign ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(Resign ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }

       

        public void UpdateStatus(long ResignId, string status)
        {
            Resign resign = context.Resigns.Find(ResignId);
            resign.Status = status;
            resign.ApprovedDate = DateTime.Now;

           


            context.UpdateRange(resign);
             context.SaveChangesAsync();

            if (status == LeaveStatus.Approve.ToString())
            {

                 UpdateEmployeeStatus(resign.FromEmployeeInfoId);
            }

        }

        public void UpdateEmployeeStatus(long EmployeeInfoId)
        {
            
                EmployeeInfo emp_resign = context.EmployeeInfos.Find(EmployeeInfoId);
                emp_resign.IsActive = false;

                context.EmployeeInfos.Update(emp_resign);
             context.SaveChangesAsync();
          


        }
    }
}
