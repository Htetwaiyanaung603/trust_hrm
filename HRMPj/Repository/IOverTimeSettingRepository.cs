using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IOverTimeSettingRepository
    {
        Task Save(OverTimeSetting c);
        List<OverTimeSetting> GetOverTimeSettingList();
        Task<List<OverTimeSettingViewModel>> GetOverTimeSettingViewModelList();
        List<OverTimeSetting> GetList(long? id);
        OverTimeSetting GetOverTimeSetting(long? Id);
        Task Update(OverTimeSetting s);
        OverTimeSetting GetDelete(long id);
        Task Delete(OverTimeSetting sa);
        bool GetExit(long id);
    }
}
