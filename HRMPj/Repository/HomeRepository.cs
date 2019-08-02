using HRMPj.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext context;

        public HomeRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public int GetEmpAccount()
        {
            int ss = context.Users.ToList().Count();
            return ss;
        }

        public int GetEmpList()
        {
            int emp = context.EmployeeInfos.Where(i=>i.IsActive==true).Count();
            return emp;
        }

        public int GetLeaveApprovedList()
        {
            int ll = context.LeaveRequests.Where(i => i.Status == "Approve").Count();
            return ll;
        }

        public int GetLeaveList()
        {
            int leave = context.LeaveRequests.Count();
            return leave;
        }

        public int GetResignList()
        {
            int ees = context.Resigns.Where(i => i.Status == "Approve").Count();
            return ees;
        }

        public decimal GetTotalPay()
        {
            decimal net = context.PayRolls.Where(a=>a.Month == "6").Sum(i => i.NetPay);
            return net;
        }
    }
}
