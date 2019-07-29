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
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using Newtonsoft.Json;

namespace HRMPj.Controllers
{
   
    public class BranchesController : Controller
    {
        private readonly IBranchRepository branchRepository;
        private readonly ICompanyRepository companyRepository;
        private readonly IDepartmentRepository departmentRepository;
        public BranchesController(IBranchRepository b,ICompanyRepository c,IDepartmentRepository d)
        {
            this.branchRepository = b;
            this.companyRepository = c;
            this.departmentRepository = d;
        }
        //private readonly ApplicationDbContext _context;

        //public BranchesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Branches
        public IActionResult Index()
        {
            //var applicationDbContext = _context.Branches.Include(b => b.Company);
            return View(branchRepository.GetBranchListByCompany());
        }

        // GET: Branches/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var branch = await _context.Branches
            //    .Include(b => b.Company)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var branch = branchRepository.GetBranchList().FirstOrDefault(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }
        [HttpGet]
        public IActionResult GetDepartmentList(long BranchId)
        {

            List<Department> departmentList = departmentRepository.GetDepartmentListByBranchs(BranchId);
            var d= JsonConvert.SerializeObject(departmentList,Formatting.None,new JsonSerializerSettings() {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d,"application/json");
        }
        // GET: Branches/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CompanyId"] = new SelectList(await companyRepository.GetCompanyListc(), "Id", "CompanyName");
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BranchName,Address,CreatedDate,CompanyId")] BranchViewModel branch)
        {
            if (ModelState.IsValid)
            {
                Branch br = new Branch()
                {
                    BranchName = branch.BranchName,
                    Address = branch.Address,
                    CreatedDate = DateTime.Now,
                    CompanyId = branch.CompanyId
                };
                //_context.Add(branch);
                await branchRepository.SaveCompany(br);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(await companyRepository.GetCompanyListc(), "Id", "Id", branch.CompanyId);
            return View(branch);
        }

        // GET: Branches/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var branch = await _context.Branches.FindAsync(id);
            var branch = branchRepository.GetBranch(id);
            if (branch == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(await companyRepository.GetCompanyListc(), "Id", "Id", branch.CompanyId);
            return View(branch);
        }

        //// POST: Branches/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,BranchName,Address,CreatedDate,CompanyId")] Branch branch)
        {
            if (id != branch.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(branch);
                    //await _context.SaveChangesAsync();
                    await branchRepository.Update(branch);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchExists(branch.Id))
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
            ViewData["CompanyId"] = new SelectList(await companyRepository.GetCompanyListc(), "Id", "Id", branch.CompanyId);
            return View(branch);
        }



        //// GET: Branches/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var branch = await _context.Branches
            //    .Include(b => b.Company)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var branch = branchRepository.GetBranchListByCompany().FirstOrDefault(m => m.Id == id);
            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        //// POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var branch = await _context.Branches.FindAsync(id);
            //_context.Branches.Remove(branch);
            //await _context.SaveChangesAsync();
            var branch = branchRepository.GetDelete(id);
            await branchRepository.Delete(branch);
            return RedirectToAction(nameof(Index));
        }

        private bool BranchExists(long id)
        {
            return branchRepository.GetExit(id);
        }
    }
}
