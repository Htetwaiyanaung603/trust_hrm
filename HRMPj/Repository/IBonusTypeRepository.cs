using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public  interface IBonusTypeRepository
    {
        Task<List<BonusTypeViewModel>> GetIndex();
        List<BonusType> GetBonusTypeList();
        Task Save(BonusType l);
        BonusType GetEdit(long? Id);
        Task Update(BonusType ll);
        List<BonusType> GetDeleteList();
        BonusType GetDelete(long Id);
        Task Delete(BonusType ll);
        bool GetExit(long id);
    }
}
