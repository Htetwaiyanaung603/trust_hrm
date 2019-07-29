using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;

namespace HRMPj.Repository
{
    public class BonusTypeRepository : IBonusTypeRepository
    {
        private readonly ApplicationDbContext context;

        public BonusTypeRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(BonusType ll)
        {
            context.Remove(ll);
            await context.SaveChangesAsync();
        }

        public List<BonusType> GetBonusTypeList()
        {
            List<BonusType> cList = context.BonusTypes.ToList();
            return cList;
        }

        public BonusType GetDelete(long Id)
        {
            try
            {
                var com = context.BonusTypes.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<BonusType> GetDeleteList()
        {
            List<BonusType> cList = context.BonusTypes.ToList();
            return cList;
        }

        public BonusType GetEdit(long? Id)
        {
            try
            {
                var com = context.BonusTypes.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var ss = context.BonusTypes.Any(e => e.Id == id);
            return ss;
        }

        public async Task<List<BonusTypeViewModel>> GetIndex()
        {
            var comList = await(from c in context.BonusTypes select new BonusTypeViewModel() { Id = c.Id, TypeName = c.TypeName, Amount=c.Amount, IsActive = c.IsActive, CreatedDate = c.CreatedDate, CreatedBy = c.CreatedBy, Year=c.Year }).ToAsyncEnumerable<BonusTypeViewModel>().ToList();
            return comList;
        }

        public async Task Save(BonusType l)
        {
            context.Add(l);
            await context.SaveChangesAsync();
        }

        public async Task Update(BonusType ll)
        {
            context.Update(ll);
            await context.SaveChangesAsync();
        }
    }
}
