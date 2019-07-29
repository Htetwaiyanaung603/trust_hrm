using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class EmployeeInfoRepository : IEmployeeInfoRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeInfoRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task Delete(EmployeeInfo ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<EmployeeInfo> GetDelete()
        {
            List<EmployeeInfo> a = context.EmployeeInfos.Include(e => e.Branch).Include(e => e.Department).Include(e => e.Designation).ToList();
            return a;
        }

        public EmployeeInfo GetDeleteList(long id)
        {
            try
            {
                var com = context.EmployeeInfos.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeInfo> GetDetail()
        {
            List<EmployeeInfo> a = context.EmployeeInfos.Include(e => e.Branch).Include(e => e.Department).Include(e => e.Designation).ToList();
            return a;
        }

        public EmployeeInfo GetEdit(long? id)
        {
            try
            {
                var com = context.EmployeeInfos.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<EmployeeInfo> GetEmployeeInfoList()
        {
            List<EmployeeInfo> bb = context.EmployeeInfos.ToList();
            return bb;
        }

        public List<EmployeeInfo> GetEmployeeListByBranchAndDepartmentId(long branchId, long departmentId)
        {
            List<EmployeeInfo> blist = context.EmployeeInfos.Include(d => d.Designation).Where(b => b.BranchId == branchId && b.DepartmentId == departmentId).ToList();
            return blist;
        }

        public bool GetExit(long id)
        {
            var dd = context.EmployeeInfos.Any(e => e.Id == id);
            return dd;
        }

        public async Task Save(EmployeeInfo ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(EmployeeInfo ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
