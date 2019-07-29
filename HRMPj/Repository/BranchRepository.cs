using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class BranchRepository : IBranchRepository
    {
        private readonly ApplicationDbContext context;

        public BranchRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async Task Delete(Branch sa)
        {
            context.Remove(sa);
            await context.SaveChangesAsync();
        }

        public Branch GetBranch(long? Id)
        {
            try
            {
                var com = context.Branches.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Branch> GetBranchList()
        {
            List<Branch> bb = context.Branches.ToList();
            return bb;
           
        }

        public List<Branch> GetBranchListByCompany()
        {
            List<Branch> blist = context.Branches.Include(b => b.Company).ToList();
            return blist;
        }

        public Branch GetDelete(long id)
        {
            try
            {
                var com = context.Branches.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    

        public bool GetExit(long id)
        {
            var dd = context.Branches.Any(e => e.Id == id);
            return dd;
        }

        public async Task SaveCompany(Branch b)
        {
            context.Add(b);
            await context.SaveChangesAsync();
        }

        public async Task Update(Branch s)
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
