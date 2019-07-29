using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class BonusRepository : IBonusRepository
    {
        private readonly ApplicationDbContext context;

        public BonusRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(Bonus ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<Bonus> GetBonusList()
        {
            List<Bonus> bb = context.Bonuses.ToList();
            return bb;
        }

        public List<Bonus> GetDelete()
        {
            List<Bonus> a = context.Bonuses.Include(b => b.BonusType).Include(b => b.EmployeeInfo).ToList();
            return a;
        }

        public Bonus GetDeleteList(long id)
        {
            try
            {
                var com = context.Bonuses.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Bonus> GetDetail()
        {
            List<Bonus> a = context.Bonuses.Include(b => b.BonusType).Include(b => b.EmployeeInfo).ToList();
            return a;
        }

        public Bonus GetEdit(long? id)
        {
            try
            {
                var com = context.Bonuses.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.Bonuses.Any(e => e.Id == id);
            return dd;
        }

        public async Task Save(Bonus ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(Bonus ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
