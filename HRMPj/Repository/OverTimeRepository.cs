using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class OverTimeRepository : IOverTimeRepository
    {
        private readonly ApplicationDbContext context;

        public OverTimeRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(OverTime ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync(); 
        }

        public List<OverTime> GetDelete()
        {
            List<OverTime> lt = context.OverTimes.Include(o => o.FromEmployeeInfo).Include(o => o.ToEmployeeInfo).ToList();
            return lt;
           
           
        }

        public OverTime GetDeleteList(long id)
        {
            try
            {
                var com = context.OverTimes.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OverTime> GetDetail()
        {
            List<OverTime> lt = context.OverTimes.Include(o => o.FromEmployeeInfo).Include(o => o.ToEmployeeInfo).ToList();
            return lt;

        }

        public OverTime GetEdit(long? id)
        {
            try
            {
                var com = context.OverTimes.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.OverTimes.Any(e => e.Id == id);
            return dd;
        }

        public List<OverTime> GetOverTimeList()
        {
            List<OverTime> bb = context.OverTimes.ToList();
            return bb;
        }

        public async Task Save(OverTime ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();

        }

        public async Task Update(OverTime ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
