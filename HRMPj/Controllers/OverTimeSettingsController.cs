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
    public class OverTimeSettingsController : Controller
    {
        private readonly IOverTimeSettingRepository overTimeSettingRepository;
        public OverTimeSettingsController(IOverTimeSettingRepository d)
        {
            this.overTimeSettingRepository = d;
        }
        //private readonly ApplicationDbContext _context;

        //public OverTimeSettingsController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: OverTimeSettings
        public async Task<IActionResult> Index()
        {
            return View(await overTimeSettingRepository.GetOverTimeSettingViewModelList());
        }

        // GET: OverTimeSettings/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var overTimeSetting = await _context.OverTimeSettings
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var overTimeSetting = overTimeSettingRepository.GetOverTimeSettingList().FirstOrDefault(m => m.Id == id);
            if (overTimeSetting == null)
            {
                return NotFound();
            }

            return View(overTimeSetting);
        }

        // GET: OverTimeSettings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OverTimeSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Amount,Limit,MaxRange,MinRange,Remark,CreatedDate")] OverTimeSettingViewModel overTimeSetting)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(overTimeSetting);
                //await _context.SaveChangesAsync();
                OverTimeSetting ov = new OverTimeSetting()
                {
                    Amount = overTimeSetting.Amount,
                    Hour = overTimeSetting.Hour,
                    Remark = overTimeSetting.Remark,
                    CreatedDate = overTimeSetting.CreatedDate
                };
                await overTimeSettingRepository.Save(ov);
                return RedirectToAction(nameof(Index));
            }
            return View(overTimeSetting);
        }

        // GET: OverTimeSettings/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var overTimeSetting = await _context.OverTimeSettings.FindAsync(id);
            var overTimeSetting = overTimeSettingRepository.GetOverTimeSetting(id);
            if (overTimeSetting == null)
            {
                return NotFound();
            }
            return View(overTimeSetting);
        }

        // POST: OverTimeSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Amount,Limit,MaxRange,MinRange,Remark,CreatedDate")] OverTimeSetting overTimeSetting)
        {
            if (id != overTimeSetting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(overTimeSetting);
                    //await _context.SaveChangesAsync();
                    await overTimeSettingRepository.Update(overTimeSetting);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OverTimeSettingExists(overTimeSetting.Id))
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
            return View(overTimeSetting);
        }

        // GET: OverTimeSettings/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var overTimeSetting = await _context.OverTimeSettings
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var overTimeSetting = overTimeSettingRepository.GetOverTimeSettingList().FirstOrDefault(m => m.Id == id);
            if (overTimeSetting == null)
            {
                return NotFound();
            }

            return View(overTimeSetting);
        }

        // POST: OverTimeSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var overTimeSetting = await _context.OverTimeSettings.FindAsync(id);
            //_context.OverTimeSettings.Remove(overTimeSetting);
            //await _context.SaveChangesAsync();
            var overTimeSetting = overTimeSettingRepository.GetDelete(id);
            await overTimeSettingRepository.Delete(overTimeSetting);
            return RedirectToAction(nameof(Index));
        }

        private bool OverTimeSettingExists(long id)
        {
            return overTimeSettingRepository.GetExit(id);
        }
    }
}
