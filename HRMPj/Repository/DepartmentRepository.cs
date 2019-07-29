using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly ApplicationDbContext context;

        public DepartmentRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task Delete(Department sa)
        {
            context.Remove(sa);
            await context.SaveChangesAsync();
        }

        public Department GetDelete(long id)
        {
            try
            {
                var com = context.Departments.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Department GetDepartment(long? Id)
        {
            try
            {
                var com = context.Departments.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Department> GetDepartmentList()
        {
            List<Department> bb = context.Departments.ToList();
            return bb;
        }

        public List<Department> GetDepartmentListByBranch()
        {
            List<Department> blist = context.Departments.Include(b => b.Branch).ToList();
            return blist;
        }

      

        public List<Department> GetDepartmentListByBranchs(long branchId)
        {
            List<Department> blist = context.Departments.Where(b => b.BranchId == branchId).ToList();
            return blist;
        }

        public bool GetExit(long id)
        {
            var dd = context.Departments.Any(e => e.Id == id);
            return dd;
        }

        public async Task Save(Department b)
        {
            context.Add(b);
            await context.SaveChangesAsync();
        }

        public async Task Update(Department s)
        {
            try
            {
                context.Update(s);
                await context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
