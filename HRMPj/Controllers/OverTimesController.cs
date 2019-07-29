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
    public class OverTimesController : Controller
    {
        public readonly IOverTimeRepository overTimeRepository;
        public readonly IEmployeeInfoRepository employeeInfoRepository;
        public OverTimesController(IOverTimeRepository oi,IEmployeeInfoRepository ie)
        {
            this.overTimeRepository = oi;
            this.employeeInfoRepository = ie;
        }
        //private readonly ApplicationDbContext _context;

        //public OverTimesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: OverTimes
        public IActionResult Index()
        {
          //  var applicationDbContext = _context.OverTimes.Include(o => o.FromEmployeeInfo).Include(o => o.ToEmployeeInfo);
            return View(overTimeRepository.GetDetail());
        }

        // GET: OverTimes/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var overTime = await _context.OverTimes
            //    .Include(o => o.FromEmployeeInfo)
            //    .Include(o => o.ToEmployeeInfo
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var overTime = overTimeRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (overTime == null)
            {
                return NotFound();
            }

            return View(overTime);
        }

        // GET: OverTimes/Create
        public IActionResult Create()
        {
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            return View();
        }

        // POST: OverTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OTDate,OTStartTime,OTEndTime,Status,ApprovedDate,OTTime,Year,FromEmployeeInfoId,ToEmployeeInfoId")] OverTimeViewModel overTime)
        {
            if (ModelState.IsValid)
            {
                OverTime ot = new OverTime()
                {
                    OTDate = overTime.OTDate,
                    OTStartTime = overTime.OTStartTime,
                    OTEndTime = overTime.OTEndTime,
                    Status = overTime.Status,
                    ApprovedDate = overTime.ApprovedDate,
                    OTTime = overTime.OTTime,
                    Year=overTime.Year,
                    FromEmployeeInfoId = overTime.FromEmployeeInfoId,
                    ToEmployeeInfoId = overTime.ToEmployeeInfoId
                };
                //_context.Add(overTime);
                //await _context.SaveChangesAsync();
                await overTimeRepository.Save(ot);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", overTime.FromEmployeeInfoId);
            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", overTime.ToEmployeeInfoId);
            return View(overTime);
        }

        // GET: OverTimes/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  var overTime = await _context.OverTimes.FindAsync(id)
            var overTime = overTimeRepository.GetEdit(id);
            if (overTime == null)
            {
                return NotFound();
            }
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", overTime.FromEmployeeInfoId);
            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", overTime.ToEmployeeInfoId);
            return View(overTime);
        }

        // POST: OverTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,OTDate,OTStartTime,OTEndTime,Status,ApprovedDate,OTTime,Year,FromEmployeeInfoId,ToEmployeeInfoId")] OverTime overTime)
        {
            if (id != overTime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(overTime);
                    //await _context.SaveChangesAsync();
                    await overTimeRepository.Update(overTime);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OverTimeExists(overTime.Id))
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
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", overTime.FromEmployeeInfoId);
            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", overTime.ToEmployeeInfoId);
            return View(overTime);
        }

        // GET: OverTimes/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var overTime = await _context.OverTimes
            //    .Include(o => o.FromEmployeeInfo)
            //    .Include(o => o.ToEmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var overTime = overTimeRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (overTime == null)
            {
                return NotFound();
            }

            return View(overTime);
        }

        // POST: OverTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var overTime = await _context.OverTimes.FindAsync(id);
            //_context.OverTimes.Remove(overTime);
            //await _context.SaveChangesAsync
            var overTime = overTimeRepository.GetDeleteList(id);
            await overTimeRepository.Delete(overTime);
            return RedirectToAction(nameof(Index));
        }

        private bool OverTimeExists(long id)
        {
            return overTimeRepository.GetExit(id);
        }
    }
}
