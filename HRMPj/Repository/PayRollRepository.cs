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
            PayRollCreateViewModel din = new PayRollCreateViewModel();
            PayRollAllowanceViewModel pav = new PayRollAllowanceViewModel();
                foreach (var item in employee)
                {
                PayRollViewModel p = new PayRollViewModel();
                din = new PayRollCreateViewModel();
                pav = new PayRollAllowanceViewModel();
                //string otsql = "select ISNULL(SUM(OTTime),0)*(" + cList.Amount / 60 + ") As Amount from OverTime where Month(OTDate)=" + month + " AND Year(OTDate)=" + year + " AND FromEmployeeInfoId =" + item.Id;

                //     din = context.Query<PayRollCreateViewModel>().FromSql(otsql).Single();
                //p.OTFee = din.Amount;
                decimal ad = context.OverTimes.Where(o => o.OTDate.Month == month && o.OTDate.Year == year && o.FromEmployeeInfoId == item.Id).Sum(i => i.OTTime * Convert.ToDecimal(cList.Amount / 60));
                p.OTFee = ad;


                // string all1 ="select ISNULL(SUM(at.AmmountPerDay),0) As AllowanceAmount from AllowanceDetail ad join AllowancdType at on at.Id = ad.AllowanceTypeId where ad.Month =" + month + " AND ad.Year =" + year + " AND ad.EmployeeInfoId =" + item.Id + " AND at.Status='Monthly'";
                //        pav = context.Query<PayRollAllowanceViewModel>().FromSql(all1).Single();
                // // var allm = context.AllowanceDetails.FromSql("select ISNULL(SUM(at.AmmountPerDay), 0) from AllowanceDetail ad join AllowancdType at on at.Id = ad.AllowanceTypeId where ad.Month = " + month + " AND ad.Year = " + year + " AND ad.EmployeeInfoId = " + item.Id + " AND at.Status = 'Monthly'").Single();
             //   int allowa=context.AllowanceDetails.GroupJoin(context.AllowanceTypes,e=>e.AllowanceTypeId,s=>s.Id).
               //int atttCount = context.Attendances.Where(a => a.AttendanceDate.Month == month && a.AttendanceDate.Year == year && a.EmployeeInfoId == item.Id && a.Status == "Present").ToList().Count();
               // string all2 = "select COUNT(Id) from Attendance a where Month(a.AttendanceDate) =" + month + " And Year(a.AttendanceDate)=" + year + " And a.EmployeeInfoId =" + item.Id + " And a.Status = 'Present'";
               // pav = context.Query<PayRollAllowanceViewModel>().FromSql(all2).Single();

               // string all3 = "select ISNULL(SUM(at.AmmountPerDay), 0) *" + atttCount + " from AllowanceDetail ad join AllowancdType at on at.Id = ad.AllowanceTypeId where ad.Month =" + month + " And ad.Year =" + year + " And ad.EmployeeInfoId =" + item.Id + " And at.Status = 'Daily'";
               // pav = context.Query<PayRollAllowanceViewModel>().FromSql(all3).Single();

               // p.TotalAllowence = pav.AllowanceAmount + pav.AllowanceAmount   ;








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
