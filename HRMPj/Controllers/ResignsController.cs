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
    public class ResignsController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IResignRepository resignRepository;
        private readonly IBranchRepository branchRepository;
        private readonly IOverTimeRepository overTimeRepository;
        public ResignsController(IEmployeeInfoRepository e, IResignRepository a,IBranchRepository b,IOverTimeRepository o)
        {
            this.resignRepository = a;
            this.employeeInfoRepository = e;
            this.branchRepository = b;
            this.overTimeRepository = o;
            
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
       
        public IActionResult RequestView()
        {
            return View(resignRepository.RetrieveResignList());
        }              
        public IActionResult ResignChangeStatus(long ResignId, string status)
        {
             resignRepository.UpdateStatus(ResignId, status);
            return Content("true", "application/json");
        }
        [HttpGet]
        public IActionResult GetResignList()
        {
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
            ViewBag.Employee = new List<EmpResignViewModel>();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetResignList(EmpResignViewModel search)
        {

            List<EmployeeInfo> searchEmployee =resignRepository.GetEmpListById(search.BranchId, search.DepartmentId, search.DesignationId,search.EmployeeId);

            ViewBag.Employee = searchEmployee;
            return View();
        }
        [HttpGet]
        public IActionResult GetEmployeeList(long DesignationId)
        {

            List<EmployeeInfo> employeeList = resignRepository.GetEmployeeListByDesignationId(DesignationId);
            var d = JsonConvert.SerializeObject(employeeList, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d, "application/json");
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
        [HttpGet]
        public IActionResult GetToEmployeeList(long FromEmployeeInfoId)
        {

            List<EmployeeInfo> employeeList = overTimeRepository.GetEmployeeListByFromEmployeeId(FromEmployeeInfoId);
            var d = JsonConvert.SerializeObject(employeeList, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d, "application/json");
        }
        // GET: Resigns/Create
        public IActionResult Create()
        {
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            return View();
        }

        // POST: Resigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResignDate,Comment,CreatedDate,ApprovedDate,Status,Year,FromEmployeeInfoId,ToEmployeeInfoId")] ResignViewModel resign)
        {
            if (ModelState.IsValid)
            {
                Resign re = new Resign()
                {
                    ResignDate = DateTime.Now,
                   
                    Comment = resign.Comment,
                   
                    CreatedDate = DateTime.Now,
                    ApprovedDate = DateTime.Now,
                    Status = "Pending",
                    Year = DateTime.Now.Year.ToString(),
                   FromEmployeeInfoId=resign.FromEmployeeInfoId,
                   ToEmployeeInfoId=resign.ToEmployeeInfoId
                };
              
                
                //_context.Add(resign);
                //await _context.SaveChangesAsync();
                await resignRepository.Save(re);
                return RedirectToAction(nameof(Index));
            }
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id",resign.FromEmployeeInfoId);

            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", resign.ToEmployeeInfoId);
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
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", resign.FromEmployeeInfoId);

            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", resign.ToEmployeeInfoId);
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
