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
    public class AllowanceTypesController : Controller
    {
        private readonly IAllowanceType allowanceType;
        public AllowanceTypesController(IAllowanceType i)
        {
            this.allowanceType = i;
        }
        //private readonly ApplicationDbContext _context;

        //public AllowanceTypesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: AllowanceTypes
        public async Task<IActionResult> Index()
        {
            return View(await allowanceType.GetAllowanceViewModelList());
        }

        // GET: AllowanceTypes/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var allowanceType = await _context.AllowanceTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var allowanceTypes = allowanceType.GetAllowanceList().FirstOrDefault(m => m.Id == id);
            if (allowanceTypes == null)
            {
                return NotFound();
            }

            return View(allowanceTypes);
        }

        // GET: AllowanceTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AllowanceTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AmmountPerDay,Status,CreatedBy,CreatedDate")] AllowanceTypeViewModel allowanceTypes)
        {
            if (ModelState.IsValid)
            {
                AllowanceType alt = new AllowanceType()
                {
                    Name = allowanceTypes.Name,
                    AmmountPerDay = allowanceTypes.AmmountPerDay,
                    Status = allowanceTypes.Status,

                    CreatedBy = allowanceTypes.CreatedBy,
                    CreatedDate = DateTime.Now
                };
                await allowanceType.Save(alt);
                //_context.Add(allowanceType);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(allowanceTypes);
        }

        // GET: AllowanceTypes/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var allowanceType = await _context.AllowanceTypes.FindAsync(id);
            var allowanceTypes = allowanceType.GetAllowance(id);
            if (allowanceTypes == null)
            {
                return NotFound();
            }
            return View(allowanceTypes);
        }

        // POST: AllowanceTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,AmmountPerDay,Status,CreatedBy,CreatedDate")] AllowanceType allowanceTypes)
        {
            if (id != allowanceTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(allowanceType);
                    //await _context.SaveChangesAsync();
                    await allowanceType.Update(allowanceTypes);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AllowanceTypeExists(allowanceTypes.Id))
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
            return View(allowanceTypes);
        }

        // GET: AllowanceTypes/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var allowanceType = await _context.AllowanceTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var allowanceTypes = allowanceType.GetAllowanceList().FirstOrDefault(m => m.Id == id);
            if (allowanceTypes == null)
            {
                return NotFound();
            }

            return View(allowanceTypes);
        }

        // POST: AllowanceTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var allowanceType = await _context.AllowanceTypes.FindAsync(id);
            var allowanceTypes = allowanceType.GetAllowance(id);
            //_context.AllowanceTypes.Remove(allowanceType);
            //await _context.SaveChangesAsync();
            await allowanceType.Delete(allowanceTypes);
            return RedirectToAction(nameof(Index));
        }

        private bool AllowanceTypeExists(long id)
        {
            return allowanceType.GetExit(id);
        }
    }
}
