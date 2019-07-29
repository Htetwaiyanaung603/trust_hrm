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
    public class ResignsController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IResignRepository resignRepository;
        public ResignsController(IEmployeeInfoRepository e, IResignRepository a)
        {
            this.resignRepository = a;
            this.employeeInfoRepository = e;
            
        }
        //    private readonly ApplicationDbContext _context;

        //    public ResignsController(ApplicationDbContext context)
        //    {
        //        _context = context;
        //    }

        // GET: Resigns
        public IActionResult Index()
        {
           // var applicationDbContext = _context.Resigns.Include(r => r.EmployeeInfo);
            return View(resignRepository.GetDetail());
        }

        // GET: Resigns/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var resign = await _context.Resigns
            //    .Include(r => r.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var resign = resignRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (resign == null)
            {
                return NotFound();
            }

            return View(resign);
        }

        // GET: Resigns/Create
        public IActionResult Create()
        {
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            return View();
        }

        // POST: Resigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResignDate,ResignStatus,Comment,Remark,CreatedDate,ApprovedDate,Status,Year,EmployeeInfoId")] ResignViewModel resign)
        {
            if (ModelState.IsValid)
            {
                Resign re = new Resign()
                {
                    ResignDate = resign.ResignDate,
                    ResignStatus = resign.ResignStatus,
                    Comment = resign.Comment,
                    Remark = resign.Remark,
                    CreatedDate = resign.CreatedDate,
                    ApprovedDate = resign.ApprovedDate,
                    Status = resign.Status,
                    Year = resign.Year,
                    EmployeeInfoId = resign.EmployeeInfoId
                };
                //_context.Add(resign);
                //await _context.SaveChangesAsync();
                await resignRepository.Save(re);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", resign.EmployeeInfoId);
            return View(resign);
        }

        // GET: Resigns/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  var resign = await _context.Resigns.FindAsync(id);
            var resign = resignRepository.GetEdit(id);
            if (resign == null)
            {
                return NotFound();
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", resign.EmployeeInfoId);
            return View(resign);
        }

        // POST: Resigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ResignDate,ResignStatus,Comment,Remark,CreatedDate,ApprovedDate,Status,Year,EmployeeInfoId")] Resign resign)
        {
            if (id != resign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(resign);
                    //await _context.SaveChangesAsync();
                    await resignRepository.Update(resign);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResignExists(resign.Id))
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
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", resign.EmployeeInfoId);
            return View(resign);
        }

        // GET: Resigns/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var resign = await _context.Resigns
            //    .Include(r => r.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var resign = resignRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (resign == null)
            {
                return NotFound();
            }

            return View(resign);
        }

        // POST: Resigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var resign = await _context.Resigns.FindAsync(id);
            //_context.Resigns.Remove(resign);
            //await _context.SaveChangesAsync();
            var resign = resignRepository.GetDeleteList(id);
            await resignRepository.Delete(resign);
            return RedirectToAction(nameof(Index));
        }

        private bool ResignExists(long id)
        {
            return resignRepository.GetExit(id) ;
        }
    }
}
