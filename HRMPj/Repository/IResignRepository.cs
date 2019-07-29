using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
   public interface IResignRepository
    {
        Task Save(Resign ot);
        Task Update(Resign ot);
        Task Delete(Resign ot);
        List<Resign> GetResignList();
        List<Resign> GetDetail();
        Resign GetEdit(long? id);
        List<Resign> GetDelete();
        Resign GetDeleteList(long id);
        bool GetExit(long id);
    }
}
