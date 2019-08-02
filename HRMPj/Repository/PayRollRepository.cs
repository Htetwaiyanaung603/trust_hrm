using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HRMPj.Repository
{
    public class PayRollRepository : IPayRollRepository
    {
        private readonly ApplicationDbContext context;

        public PayRollRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public List<PayRollViewModel> ClaculatePayRoll(int year, int month, List<EmployeeInfo> employee)
        {
            OverTimeSetting cList = context.OverTimeSettings.Last();
            
            List<PayRollViewModel> po = new List<PayRollViewModel>();
          
                foreach (var item in employee)
                {
                PayRollViewModel p = new PayRollViewModel();
              
                //string otsql = "select ISNULL(SUM(OTTime),0)*(" + cList.Amount / 60 + ") As Amount from OverTime where Month(OTDate)=" + month + " AND Year(OTDate)=" + year + " AND FromEmployeeInfoId =" + item.Id;

                //     din = context.Query<PayRollCreateViewModel>().FromSql(otsql).Single();
                //p.OTFee = din.Amount;
                decimal ad = context.OverTimes.Where(o => o.OTDate.Month == month && o.OTDate.Year == year && o.FromEmployeeInfoId == item.Id).Sum(i => i.OTTime * Convert.ToDecimal(cList.Amount / 60));
                p.OTFee = ad;
                // string all1 ="select ISNULL(SUM(at.AmmountPerDay),0) As AllowanceAmount from AllowanceDetail ad join AllowancdType at on at.Id = ad.AllowanceTypeId where ad.Month =" + month + " AND ad.Year =" + year + " AND ad.EmployeeInfoId =" + item.Id + " AND at.Status='Monthly'";
                //        pav = context.Query<PayRollAllowanceViewModel>().FromSql(all1).Single();
                // // var allm = context.AllowanceDetails.FromSql("select ISNULL(SUM(at.AmmountPerDay), 0) from AllowanceDetail ad join AllowancdType at on at.Id = ad.AllowanceTypeId where ad.Month = " + month + " AND ad.Year = " + year + " AND ad.EmployeeInfoId = " + item.Id + " AND at.Status = 'Monthly'").Single();             
                long allwnceAmountMonthly = context.AllowanceDetails.Include(c => c.AllowanceType).Where(b => b.Month == month.ToString() && b.Year == year.ToString() && b.EmployeeInfoId == item.Id && b.AllowanceType.Status == "Monthly").Sum(i => i.AllowanceType.AmmountPerDay);
                int atttCount = context.Attendances.Where(a => a.AttendanceDate.Month == month && a.AttendanceDate.Year == year && a.EmployeeInfoId == item.Id && a.Status == "Present").ToList().Count();
                long allowanceAmountDaily = context.AllowanceDetails.Include(c => c.AllowanceType).Where(b => b.Month == month.ToString() && b.Year == year.ToString() && b.EmployeeInfoId == item.Id && b.AllowanceType.Status == "Daily").Sum(i => i.AllowanceType.AmmountPerDay * atttCount);
                // string all2 = "select COUNT(Id) from Attendance a where Month(a.AttendanceDate) =" + month + " And Year(a.AttendanceDate)=" + year + " And a.EmployeeInfoId =" + item.Id + " And a.Status = 'Present'";
                // pav = context.Query<PayRollAllowanceViewModel>().FromSql(all2).Single();

                // string all3 = "select ISNULL(SUM(at.AmmountPerDay), 0) *" + atttCount + " from AllowanceDetail ad join AllowancdType at on at.Id = ad.AllowanceTypeId where ad.Month =" + month + " And ad.Year =" + year + " And ad.EmployeeInfoId =" + item.Id + " And at.Status = 'Daily'";
                // pav = context.Query<PayRollAllowanceViewModel>().FromSql(all3).Single();
                decimal totalallowance = allwnceAmountMonthly + allowanceAmountDaily;
                p.TotalAllowence = totalallowance;
                long bonusPayroll = context.Bonuses.Include(c => c.BonusType).Where(b => b.Month == month.ToString() && b.Year == year.ToString() && b.EmployeeInfoId == item.Id).Sum(i => i.BonusType.Amount);
                p.Bonus = bonusPayroll;
                long basicSalary =context.EmployeeInfos.Where(a => a.Id == item.Id).Select(i=>i.BasicSalary).Single();
                p.BasicSalary = basicSalary;
                int absentList = context.Attendances.Where(a => a.AttendanceDate.Month == month && a.AttendanceDate.Year == year && a.EmployeeInfoId == item.Id && a.Status == "Absent").ToList().Count();
                int days = DateTime.DaysInMonth(year, month);
                //decimal panltyfee = (basicSalary / days) * absentList;
                decimal panltyfee = context.EmployeeInfos.Where(a => a.Id == item.Id).Select(i => (i.BasicSalary / days) * absentList).Single();
                p.PenaltyFee = panltyfee;
                string empName = context.EmployeeInfos.Where(a => a.Id == item.Id).Select(i => i.EmployeeName).Single();
                p.EmployeeName = empName;
                decimal netpay = (ad + totalallowance + bonusPayroll + basicSalary) - panltyfee;
                p.NetPay = netpay;
                p.EmployeeInfoId = item.Id;
                po.Add(p); 
                }
            return po;
        }

        public async Task Delete(PayRoll ot)
        {
            context.Remove(ot);
            await context.SaveChangesAsync();
        }

        public List<PayRoll> GetDelete()
        {
            List<PayRoll> a = context.PayRolls.Include(p => p.EmployeeInfo).ToList();
            return a;
        }

        public PayRoll GetDeleteList(long id)
        {
            try
            {
                var com = context.PayRolls.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PayRoll> GetDetail()
        {
            List<PayRoll> a = context.PayRolls.Include(p => p.EmployeeInfo).ToList();
            return a;
        }

        public PayRoll GetEdit(long? id)
        {
            try
            {
                var com = context.PayRolls.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetExit(long id)
        {
            var dd = context.PayRolls.Any(e => e.Id == id);
            return dd;
        }

        public List<PayRoll> GetPayRollList()
        {
            List<PayRoll> bb = context.PayRolls.ToList();
            return bb;
        }

        public async Task Save(PayRoll ot)
        {
            context.Add(ot);
            await context.SaveChangesAsync();
        }

        public async Task Update(PayRoll ot)
        {
            context.Update(ot);
            await context.SaveChangesAsync();
        }
    }
}
