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
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentRepository departmentRepository;
        private readonly IBranchRepository branchRepository;
        public DepartmentsController(IDepartmentRepository d,IBranchRepository b)
        {
            this.branchRepository = b;
            this.departmentRepository = d;
        }
        //private readonly ApplicationDbContext _context;

        //public DepartmentsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Departments
        public IActionResult Index()
        {
           // var applicationDbContext = _context.Departments.Include(d => d.Branch);
            return View(departmentRepository.GetDepartmentListByBranch());
        }

        // GET: Departments/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var department = await _context.Departments
            //    .Include(d => d.Branch)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var department = departmentRepository.GetDepartmentList().FirstOrDefault(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CreatedDate,BranchId")] DepartmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                Department dd = new Department()
                {
                    Name = department.Name,
                    CreatedDate = department.CreatedDate,
                    BranchId = department.BranchId
                };
                // _context.Add(department);
                await departmentRepository.Save(dd);
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "Id", department.BranchId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var department = await _context.Departments.FindAsync(id);
            var department = departmentRepository.GetDepartment(id);
            if (department == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "Id", department.BranchId);
            return View(department);
        }

        //// POST: Departments/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,CreatedDate,BranchId")] Department department)
        {
            if (id != department.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(department);
                    //await _context.SaveChangesAsync();
                    await departmentRepository.Update(department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentExists(department.Id))
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
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "Id", department.BranchId);
            return View(department);
        }

        //// GET: Departments/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var department = await _context.Departments
            //    .Include(d => d.Branch)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var department = departmentRepository.GetDepartmentListByBranch().FirstOrDefault(m => m.Id == id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        //// POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var department = await _context.Departments.FindAsync(id);
            //_context.Departments.Remove(department);
            //await _context.SaveChangesAsync();
            var department = departmentRepository.GetDelete(id);
            await departmentRepository.Delete(department);
            return RedirectToAction(nameof(Index));
        }

        private bool DepartmentExists(long id)
        {
            return departmentRepository.GetExit(id);
        }
    }
}
