using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public  interface IBonusRepository
    {
        Task Save(Bonus ot);
        Task Update(Bonus ot);
        Task Delete(Bonus ot);
        List<Bonus> GetBonusList();
        List<Bonus> GetDetail();
        Bonus GetEdit(long? id);
        List<Bonus> GetDelete();
        Bonus GetDeleteList(long id);
        bool GetExit(long id);
    }
}
