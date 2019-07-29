using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class DesignationRepository : IDesignationRepository
    {
        private readonly ApplicationDbContext context;

        public DesignationRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task Delete(Designation sa)
        {
            context.Remove(sa);
            await context.SaveChangesAsync();
        }

        public Designation GetDelete(long id)
        {
            try
            {
                var com = context.Designations.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Designation GetDesignation(long? Id)
        {
            try
            {
                var com = context.Designations.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Designation> GetDesignationList()
        {
            List<Designation> ddd = context.Designations.ToList();
            return ddd;
        }

        public List<Designation> GetDesignationListByDepartment()
        {
            List<Designation> blist = context.Designations.Include(b => b.Department).ToList();
            return blist;
        }

        public List<Designation> GetDesignationListByDepartmentId(long departmentId)
        {
            List<Designation> blist = context.Designations.Where(b => b.DepartmentId == departmentId).ToList();
            return blist;
        }

        public bool GetExit(long id)
        {
            var dd = context.Designations.Any(e => e.Id == id);
            return dd;
        }

        public async Task Save(Designation b)
        {
            context.Add(b);
            await context.SaveChangesAsync();
        }

        public async Task Update(Designation s)
        {
            context.Update(s);
            await context.SaveChangesAsync();
        }
    }
}
