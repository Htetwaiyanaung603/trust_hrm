using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HRMPj.Data;
using HRMPj.Models;
using HRMPj.Repository;

namespace HRMPj.Controllers
{
    public class PayRollsController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IPayRollRepository payRollRepository;
        public PayRollsController(IEmployeeInfoRepository e, IPayRollRepository a)
        {
            this.payRollRepository = a;
            this.employeeInfoRepository = e;

        }
        //private readonly ApplicationDbContext _context;

        //public PayRollsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: PayRolls
        public IActionResult Index()
        {
           // var applicationDbContext = _context.PayRolls.Include(p => p.EmployeeInfo);
            return View(payRollRepository.GetDetail());
        }

        // GET: PayRolls/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var payRoll = await _context.PayRolls
            //    .Include(p => p.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var payRoll = payRollRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (payRoll == null)
            {
                return NotFound();
            }

            return View(payRoll);
        }

        // GET: PayRolls/Create
        public IActionResult Create()
        {
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            return View();
        }

        // POST: PayRolls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PaymentDate,BasicSalary,OTFee,TotalAllowence,Bonus,LoanAmount,LateDebuct,PenaltyFee,TaxFee,Saving,NetPay,CreatedDate,CreatedBy,Year,Month,PrintStatus,Claim,EmployeeInfoId")] PayRollViewModel payRoll)
        {
            if (ModelState.IsValid)
            {
                PayRoll pp = new PayRoll()
                {
                    PaymentDate = payRoll.PaymentDate,
                    BasicSalary = payRoll.BasicSalary,
                    OTFee = payRoll.OTFee,
                    TotalAllowence = payRoll.TotalAllowence,
                    Bonus = payRoll.Bonus,
                    LoanAmount = payRoll.LoanAmount,
                    LateDebuct = payRoll.LateDebuct,
                    NetPay = payRoll.NetPay,
                    PenaltyFee = payRoll.PenaltyFee,
                    TaxFee = payRoll.TaxFee,
                    Year = payRoll.Year,
                    Month = payRoll.Month,
                    Saving = payRoll.Saving,
                    PrintStatus = payRoll.PrintStatus,
                  
                    CreatedBy = payRoll.CreatedBy,
                    CreatedDate = payRoll.CreatedDate,
                    EmployeeInfoId = payRoll.EmployeeInfoId
                };
                await payRollRepository.Save(pp);
                //_context.Add(payRoll);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", payRoll.EmployeeInfoId);
            return View(payRoll);
        }

        // GET: PayRolls/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var payRoll = await _context.PayRolls.FindAsync(id);
            var payRoll = payRollRepository.GetEdit(id);
            if (payRoll == null)
            {
                return NotFound();
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", payRoll.EmployeeInfoId);
            return View(payRoll);
        }

        // POST: PayRolls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,PaymentDate,BasicSalary,OTFee,TotalAllowence,Bonus,LoanAmount,LateDebuct,PenaltyFee,TaxFee,Saving,NetPay,CreatedDate,CreatedBy,Year,Month,PrintStatus,Claim,EmployeeInfoId")] PayRoll payRoll)
        {
            if (id != payRoll.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(payRoll);
                    //await _context.SaveChangesAsync();
                    await payRollRepository.Update(payRoll);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PayRollExists(payRoll.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", payRoll.EmployeeInfoId);
            return View(payRoll);
        }

        // GET: PayRolls/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var payRoll = await _context.PayRolls
            //    .Include(p => p.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var payRoll = payRollRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (payRoll == null)
            {
                return NotFound();
            }

            return View(payRoll);
        }

        // POST: PayRolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var payRoll = await _context.PayRolls.FindAsync(id);
            //_context.PayRolls.Remove(payRoll);
            //await _context.SaveChangesAsync();
            var payRoll = payRollRepository.GetDeleteList(id);
            await payRollRepository.Delete(payRoll);
            return RedirectToAction(nameof(Index));
        }

        private bool PayRollExists(long id)
        {
            return payRollRepository.GetExit(id);
        }
    }
}
