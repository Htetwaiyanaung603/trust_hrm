using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class AllowanceDetailRepository : IAllowanceDetailRepository
    {
        private readonly ApplicationDbContext context;

        public AllowanceDetailRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(AllowanceDetail sa)
        {
            context.Remove(sa);
            await context.SaveChangesAsync();
        }

        public AllowanceDetail GetAllowanceDetail(long? Id)
        {
            try
            {
                var com = context.AllowanceDetails.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AllowanceDetail> GetAllowanceDetailList()
        {
            List<AllowanceDetail> bb = context.AllowanceDetails.ToList();
            return bb;
        }

        public List<AllowanceDetail> GetAllowanceDetailListBy()
        {
            List<AllowanceDetail> ll = context.AllowanceDetails.Include(a => a.AllowanceType).Include(a => a.Employee).ToList();
            return ll;
        }

        public AllowanceDetail GetDelete(long id)
        {
            try
            {
                var com = context.AllowanceDetails.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.AllowanceDetails.Any(e => e.Id == id);
            return dd;
        }

        public async Task Save(AllowanceDetail b)
        {
            context.Add(b);
            await context.SaveChangesAsync();
        }

        public async Task Update(AllowanceDetail s)
        {
            context.Update(s);
            await context.SaveChangesAsync();
        }
    }
}
