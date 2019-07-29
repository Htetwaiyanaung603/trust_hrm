using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class PayRollRepository : IPayRollRepository
    {
        private readonly ApplicationDbContext context;

        public PayRollRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(PayRoll ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<PayRoll> GetDelete()
        {
            List<PayRoll> a = context.PayRolls.Include(p => p.EmployeeInfo).ToList();
            return a;
        }

        public PayRoll GetDeleteList(long id)
        {
            try
            {
                var com = context.PayRolls.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PayRoll> GetDetail()
        {
            List<PayRoll> a = context.PayRolls.Include(p => p.EmployeeInfo).ToList();
            return a;
        }

        public PayRoll GetEdit(long? id)
        {
            try
            {
                var com = context.PayRolls.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.PayRolls.Any(e => e.Id == id);
            return dd;
        }

        public List<PayRoll> GetPayRollList()
        {
            List<PayRoll> bb = context.PayRolls.ToList();
            return bb;
        }

        public async Task Save(PayRoll ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(PayRoll ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
