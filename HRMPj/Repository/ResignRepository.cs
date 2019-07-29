using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class ResignRepository : IResignRepository
    {
        private readonly ApplicationDbContext context;

        public ResignRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(Resign ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<Resign> GetDelete()
        {
            List<Resign> a = context.Resigns.Include(r => r.EmployeeInfo).ToList();
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
            List<Resign> a = context.Resigns.Include(r => r.EmployeeInfo).ToList();
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
    }
}
