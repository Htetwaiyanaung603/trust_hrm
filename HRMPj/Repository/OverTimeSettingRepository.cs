using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;

namespace HRMPj.Repository
{
    public class OverTimeSettingRepository : IOverTimeSettingRepository
    {
        private readonly ApplicationDbContext context;

        public OverTimeSettingRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task Delete(OverTimeSetting sa)
        {
            context.Remove(sa);
            await context.SaveChangesAsync();
        }

       

        public OverTimeSetting GetDelete(long id)
        {
            try
            {
                var com = context.OverTimeSettings.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var ss = context.OverTimeSettings.Any(e => e.Id == id);
            return ss;
        }

        public List<OverTimeSetting> GetList(long? id)
        {
            List<OverTimeSetting> cList = context.OverTimeSettings.ToList();
            return cList;
        }

        public OverTimeSetting GetOverTimeSetting(long? Id)
        {

            try
            {
                var com = context.OverTimeSettings.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<OverTimeSetting> GetOverTimeSettingList()
        {
            List<OverTimeSetting> cList = context.OverTimeSettings.ToList();
            return cList;
        }

        public async Task<List<OverTimeSettingViewModel>> GetOverTimeSettingViewModelList()
        {
            var comList = await(from c in context.OverTimeSettings select new OverTimeSettingViewModel() { Id = c.Id, Amount=c.Amount,Hour=c.Hour,Remark=c.Remark,CreatedDate=c.CreatedDate }).ToAsyncEnumerable<OverTimeSettingViewModel>().ToList();
            return comList;
        }

        public async Task Save(OverTimeSetting c)
        {
            context.Add(c);
            await context.SaveChangesAsync();
        }

        public async Task Update(OverTimeSetting s)
        {
            context.Update(s);
            await context.SaveChangesAsync();
        }
    }
}
