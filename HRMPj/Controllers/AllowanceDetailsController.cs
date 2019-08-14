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
    public class AllowanceDetailsController : Controller
    {
        private readonly IAllowanceDetailRepository detailRepository;
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IAllowanceType allowanceRepository;
        public AllowanceDetailsController(IAllowanceDetailRepository d,IEmployeeInfoRepository e,IAllowanceType f)
        {
            this.detailRepository = d;
            this.employeeInfoRepository = e;
            this.allowanceRepository = f;
        }
        //private readonly ApplicationDbContext _context;

        //public AllowanceDetailsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: AllowanceDetails
        public IActionResult Index()
        {
          //  var applicationDbContext = _context.AllowanceDetails.Include(a => a.AllowanceType).Include(a => a.Employee);
            return View(detailRepository.GetAllowanceDetailListBy());
        }

        // GET: AllowanceDetails/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var allowanceDetail = await _context.AllowanceDetails
            //    .Include(a => a.AllowanceType)
            //    .Include(a => a.Employee)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var allowanceDetail = detailRepository.GetAllowanceDetailList().FirstOrDefault(m => m.Id == id);
            if (allowanceDetail == null)
            {
                return NotFound();
            }

            return View(allowanceDetail);
        }

        // GET: AllowanceDetails/Create
        public IActionResult Create()
        {
            ViewData["AllowanceTypeId"] = new SelectList(allowanceRepository.GetAllowanceList(), "Id", "Name");
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            string currentMonth = DateTime.Now.Month.ToString();
            ViewData["Month"] = currentMonth;
            return View();
        }

        // POST: AllowanceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AllowanceDetailViewModel allowanceDetail)
        {
            if (ModelState.IsValid)
            {
                AllowanceDetail def = new AllowanceDetail()
                {
                    Month = allowanceDetail.Month,
                    Year = allowanceDetail.Year,
                    AllowanceTypeId = allowanceDetail.AllowanceTypeId,
                    EmployeeInfoId = allowanceDetail.EmployeeInfoId
                };
                //_context.Add(allowanceDetail);
                //await _context.SaveChangesAsync();
              //  AllowanceDetail ss = detailRepository.ffff(allowanceDetail.Month, allowanceDetail.Year, allowanceDetail.EmployeeInfoId, allowanceDetail.AllowanceTypeId);
                //if (ss == null)
                //{
                    await detailRepository.Save(def);
                    return RedirectToAction(nameof(Index));
                //}
                //else
                //{
                //    ViewBag.Message = "This Allowance Type is already pay.";
                //}

            }
            ViewData["AllowanceTypeId"] = new SelectList(allowanceRepository.GetAllowanceList(), "Id", "Name", allowanceDetail.AllowanceTypeId);
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName", allowanceDetail.EmployeeInfoId);
            return View(allowanceDetail);
        }

        // GET: AllowanceDetails/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var allowanceDetail = await _context.AllowanceDetails.FindAsync(id);
            var allowanceDetail = detailRepository.GetAllowanceDetail(id);
            if (allowanceDetail == null)
            {
                return NotFound();
            }
            ViewData["AllowanceTypeId"] = new SelectList(allowanceRepository.GetAllowanceList(), "Id", "Name", allowanceDetail.AllowanceTypeId);
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName", allowanceDetail.EmployeeInfoId);
            return View(allowanceDetail);
        }

        // POST: AllowanceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Month,Year,AllowanceTypeId,EmployeeInfoId")] AllowanceDetail allowanceDetail)
        {
            if (id != allowanceDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(allowanceDetail);
                    //await _context.SaveChangesAsync();
                    await detailRepository.Update(allowanceDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllowanceDetailExists(allowanceDetail.Id))
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
            ViewData["AllowanceTypeId"] = new SelectList(allowanceRepository.GetAllowanceList(), "Id", "Id", allowanceDetail.AllowanceTypeId);
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", allowanceDetail.EmployeeInfoId);
            return View(allowanceDetail);
        }

        // GET: AllowanceDetails/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var allowanceDetail = await _context.AllowanceDetails
            //    .Include(a => a.AllowanceType)
            //    .Include(a => a.Employee)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var allowanceDetail = detailRepository.GetAllowanceDetailList().FirstOrDefault(m => m.Id == id);
            if (allowanceDetail == null)
            {
                return NotFound();
            }

            return View(allowanceDetail);
        }

        // POST: AllowanceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var allowanceDetail = await _context.AllowanceDetails.FindAsync(id);
            //_context.AllowanceDetails.Remove(allowanceDetail);
            //await _context.SaveChangesAsync();
            var allowanceDetail = detailRepository.GetDelete(id);
            await detailRepository.Delete(allowanceDetail);
            return RedirectToAction(nameof(Index));
        }

        private bool AllowanceDetailExists(long id)
        {
            return detailRepository.GetExit(id);
        }
    }
}
