using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IOverTimeRepository
    {
        Task Save(OverTime ot);
        Task Update(OverTime ot);
        Task Delete(OverTime ot);
        List<OverTime> GetOverTimeList();
        List<OverTime> GetDetail();
        OverTime GetEdit(long? id);
        List<OverTime> GetDelete();
        OverTime GetDeleteList(long id);
        bool GetExit(long id);
    }
}
