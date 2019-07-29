using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public  interface IPayRollRepository
    {
        Task Save(PayRoll ot);
        Task Update(PayRoll ot);
        Task Delete(PayRoll ot);
        List<PayRoll> GetPayRollList();
        List<PayRoll> GetDetail();
        PayRoll GetEdit(long? id);
        List<PayRoll> GetDelete();
        PayRoll GetDeleteList(long id);
        bool GetExit(long id);
    }
}
