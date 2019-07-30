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
using Newtonsoft.Json;

namespace HRMPj.Controllers
{
    public class PayRollsController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IPayRollRepository payRollRepository;
        private readonly IBranchRepository branchRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IDesignationRepository designationRepository;
        public PayRollsController(IEmployeeInfoRepository e, IPayRollRepository a,IBranchRepository b,IDepartmentRepository d,IDesignationRepository de)
        {
            this.payRollRepository = a;
            this.employeeInfoRepository = e;
            this.branchRepository = b;
            this.departmentRepository = d;
            this.designationRepository = de;

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
        public IActionResult GetEmpView()
        {
            ViewData["Branch"] =new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
            List<EmployeeInfo> searchEmployee = new List<EmployeeInfo>();
            ViewBag.Employee = searchEmployee;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetEmpView(EmpPayRollViewModel search)
        {

            List<EmployeeInfo> searchEmployee = employeeInfoRepository.GetEmployeeListByBranchAndDepartmentIdAndDesignationId(search.BranchId, search.DepartmentId,search.DesignationId);
            List<PayRollViewModel> o = payRollRepository.ClaculatePayRoll(search.Year, search.Month,searchEmployee);
            ViewBag.Employee = o;
            
            return View();
        }

        [HttpGet]
        public IActionResult GetDepartmentList(long BranchId)
        {

            List<Department> departmentList = departmentRepository.GetDepartmentListByBranchs(BranchId);
            var d = JsonConvert.SerializeObject(departmentList, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d, "application/json");
        }
        [HttpGet]
        public IActionResult GetDesignationList(long DepartmentId)
        {

            List<Designation> designationlist = designationRepository.GetDesignationListByDepartmentId(DepartmentId);
            var d = JsonConvert.SerializeObject(designationlist, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d, "application/json");
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
        public async Task<IActionResult> Create([Bind("Id,PaymentDate,BasicSalary,OTFee,TotalAllowence,Bonus,PenaltyFee,NetPay,EmployeeInfoId")] PayRollViewModel payRoll)
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
                    NetPay = payRoll.NetPay,
                    PenaltyFee = payRoll.PenaltyFee,                
                    Year = DateTime.Now.Year.ToString(),
                    Month = DateTime.Now.Month.ToString(),                 
                    CreatedBy ="",
                    CreatedDate = DateTime.Now,
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
