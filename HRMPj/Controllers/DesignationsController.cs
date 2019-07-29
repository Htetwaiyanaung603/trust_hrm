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
    public class DesignationsController : Controller
    {
        private readonly IDesignationRepository designationRepository;
        private readonly IDepartmentRepository departmentRepository;
        public DesignationsController(IDesignationRepository de,IDepartmentRepository dp)
        {
            this.designationRepository = de;
            this.departmentRepository = dp;
        }
        //private readonly ApplicationDbContext _context;

        //public DesignationsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Designations
        public IActionResult Index()
        {
          //  var applicationDbContext = _context.Designations.Include(d => d.Department);
            return View(designationRepository.GetDesignationListByDepartment());
        }

        // GET: Designations/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var designation = await _context.Designations
            //    .Include(d => d.Department)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var designation = designationRepository.GetDesignationList().FirstOrDefault(m => m.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // GET: Designations/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartmentList(), "Id", "Name");
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Remark,CreatedDate,CreatedBy,DepartmentId")] DesignationViewModel designation)
        {
            if (ModelState.IsValid)
            {
                Designation des = new Designation()
                {
                    Name = designation.Name,
                    Remark = designation.Remark,
                    CreatedDate = designation.CreatedDate,
                    CreatedBy = designation.CreatedBy,
                    DepartmentId = designation.DepartmentId
                };
               // _context.Add(designation);
                await designationRepository.Save(des);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList( departmentRepository.GetDepartmentList(), "Id", "Id", designation.DepartmentId);
            return View(designation);
        }

        // GET: Designations/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var designation = await _context.Designations.FindAsync(id);
            var designation = designationRepository.GetDesignation(id);
            if (designation == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList( designationRepository.GetDesignationList(), "Id", "Id", designation.DepartmentId);
            return View(designation);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,Remark,CreatedDate,CreatedBy,DepartmentId")] Designation designation)
        {
            if (id != designation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    await designationRepository.Update(designation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DesignationExists(designation.Id))
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
            ViewData["DepartmentId"] = new SelectList(designationRepository.GetDesignationList(), "Id", "Id", designation.DepartmentId);
            return View(designation);
        }

        // GET: Designations/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var designation = await _context.Designations
            //    .Include(d => d.Department)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var designation = designationRepository.GetDesignationListByDepartment().FirstOrDefault(m => m.Id == id);
            if (designation == null)
            {
                return NotFound();
            }

            return View(designation);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var designation = await _context.Designations.FindAsync(id);
            //_context.Designations.Remove(designation);
            //await _context.SaveChangesAsync();
            var designation = designationRepository.GetDelete(id);
            await designationRepository.Delete(designation);
            return RedirectToAction(nameof(Index));
        }

        private bool DesignationExists(long id)
        {
            return designationRepository.GetExit(id);
        }
    }
}
