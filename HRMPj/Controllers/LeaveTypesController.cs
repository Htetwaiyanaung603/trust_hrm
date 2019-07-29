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
    public class LeaveTypesController : Controller
    {
        private readonly ILeaveTypeRepository leaveTypeRepository;
        public LeaveTypesController(ILeaveTypeRepository d)
        {
            this.leaveTypeRepository = d;
        }
        //private readonly ApplicationDbContext _context;

        //public LeaveTypesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            return View(await leaveTypeRepository.GetIndex());
        }

        // GET: LeaveTypes/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var leaveType = leaveTypeRepository.GetLeaveTypeList().FirstOrDefault(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // GET: LeaveTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName,CreatedDate,ServiceDay")] LeaveTypeViewModel leaveType)
        {
            if (ModelState.IsValid)
            {
                LeaveType ll = new LeaveType()
                {
                    TypeName = leaveType.TypeName,
                   
                    
                    CreatedDate = DateTime.Now,
                    ServiceDay = leaveType.ServiceDay
                };
                //_context.Add(leaveType);
                //await _context.SaveChangesAsync();
                await leaveTypeRepository.Save(ll);
                return RedirectToAction(nameof(Index));
            }
            return View(leaveType);
        }

        // GET: LeaveTypes/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            var leaveType = leaveTypeRepository.GetEdit(id);
            if (leaveType == null)
            {
                return NotFound();
            }
            return View(leaveType);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TypeName,RunningYear,IsActive,CreatedDate,CreatedBy,ServiceDay")] LeaveType leaveType)
        {
            if (id != leaveType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(leaveType);
                    //await _context.SaveChangesAsync();
                    await leaveTypeRepository.Update(leaveType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeExists(leaveType.Id))
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
            return View(leaveType);
        }

        // GET: LeaveTypes/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveType = await _context.LeaveTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var leaveType = leaveTypeRepository.GetDeleteList().FirstOrDefault(m => m.Id == id);
            if (leaveType == null)
            {
                return NotFound();
            }

            return View(leaveType);
        }

        // POST: LeaveTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var leaveType = await _context.LeaveTypes.FindAsync(id);
            //_context.LeaveTypes.Remove(leaveType);
            //await _context.SaveChangesAsync();
            var leaveType = leaveTypeRepository.GetDelete(id);
            await leaveTypeRepository.Delete(leaveType);
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeExists(long id)
        {
            return leaveTypeRepository.GetExit(id);
        }
    }
}
