using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public interface IHomeRepository
    {
        int GetEmpList();
        int GetLeaveList();
        decimal GetTotalPay();
        int GetLeaveApprovedList();
        int GetEmpAccount();
        int GetResignList();
    }
}
