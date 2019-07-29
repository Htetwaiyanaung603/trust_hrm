using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;

namespace HRMPj.Repository
{
    public class AllowanceTypeRepository : IAllowanceType
    {
        private readonly ApplicationDbContext context;

        public AllowanceTypeRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(AllowanceType sa)
        {
            context.Remove(sa);
            await context.SaveChangesAsync();
        }

        public AllowanceType GetAllowance(long? Id)
        {
            try
            {
                var com = context.AllowanceTypes.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<AllowanceType> GetAllowanceList()
        {
            List<AllowanceType> cList = context.AllowanceTypes.ToList();
            return cList;
        }

        public async Task<List<AllowanceTypeViewModel>> GetAllowanceViewModelList()
        {
            var comList = await(from c in context.AllowanceTypes select new AllowanceTypeViewModel() { Id = c.Id, Name = c.Name,AmmountPerDay = c.AmmountPerDay,Status = c.Status, CreatedDate = c.CreatedDate,CreatedBy = c.CreatedBy, }).ToAsyncEnumerable<AllowanceTypeViewModel>().ToList();
            return comList;
        }

        public AllowanceType GetDelete(long id)
        {
            try
            {
                var com = context.AllowanceTypes.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.AllowanceTypes.Any(e => e.Id == id);
            return dd;
        }

        public List<AllowanceType> GetList(long? id)
        {
            List<AllowanceType> cList = context.AllowanceTypes.ToList();
            return cList;
        }

        public async Task Save(AllowanceType c)
        {
            context.Add(c);
            await context.SaveChangesAsync();
        }

        public async Task Update(AllowanceType s)
        {
            context.Update(s);
            await context.SaveChangesAsync();
        }
    }
}
