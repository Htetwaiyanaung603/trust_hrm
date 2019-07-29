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
    public class BonusesController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IBonusTypeRepository bonusTypeRepository;
        private readonly IBonusRepository bonusRepository;
        public BonusesController(IEmployeeInfoRepository e, IBonusTypeRepository a, IBonusRepository s)
        {
            this.bonusTypeRepository = a;
            this.employeeInfoRepository = e;
            this.bonusRepository = s;
        }
        //private readonly ApplicationDbContext _context;

        //public BonusesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Bonuses
        public IActionResult Index()
        {
            //  var applicationDbContext = _context.Bonuses.Include(b => b.BonusType).Include(b => b.EmployeeInfo);
            return View(bonusRepository.GetDetail());
        }

        // GET: Bonuses/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var bonus = await _context.Bonuses
            //    .Include(b => b.BonusType)
            //    .Include(b => b.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var bonus = bonusRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (bonus == null)
            {
                return NotFound();
            }

            return View(bonus);
        }

        // GET: Bonuses/Create
        public IActionResult Create()
        {
            ViewData["BonusTypeId"] = new SelectList(bonusTypeRepository.GetBonusTypeList(), "Id", "TypeName");
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            string currentMonth = DateTime.Now.Month.ToString();
            ViewData["Month"] = currentMonth;
            return View();
        }

        // POST: Bonuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Year,Month,CreatedDate,CreatedBy,EmployeeInfoId,BonusTypeId")] BonusViewModel bonus)
        {
            if (ModelState.IsValid)
            {
                Bonus bb = new Bonus()
                {
                    Year=bonus.Year,
                    Month=bonus.Month,
                    CreatedBy="",
                    CreatedDate=DateTime.Now,
                    EmployeeInfoId=bonus.EmployeeInfoId,
                    BonusTypeId=bonus.BonusTypeId
                };
                await bonusRepository.Save(bb);
                //_context.Add(bonus);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BonusTypeId"] = new SelectList(bonusTypeRepository.GetBonusTypeList(), "Id", "Id", bonus.BonusTypeId);
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", bonus.EmployeeInfoId);
            return View(bonus);
        }

        // GET: Bonuses/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  var bonus = await _context.Bonuses.FindAsync(id);
            var bonus = bonusRepository.GetEdit(id);
            if (bonus == null)
            {
                return NotFound();
            }
            ViewData["BonusTypeId"] = new SelectList(bonusTypeRepository.GetBonusTypeList(), "Id", "Id", bonus.BonusTypeId);
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", bonus.EmployeeInfoId);
            return View(bonus);
        }

        // POST: Bonuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Year,Month,CreatedDate,CreatedBy,EmployeeInfoId,BonusTypeId")] Bonus bonus)
        {
            if (id != bonus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(bonus);
                    //await _context.SaveChangesAsync();
                    await bonusRepository.Update(bonus);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonusExists(bonus.Id))
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
            ViewData["BonusTypeId"] = new SelectList(bonusTypeRepository.GetBonusTypeList(), "Id", "Id", bonus.BonusTypeId);
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", bonus.EmployeeInfoId);
            return View(bonus);
        }

        // GET: Bonuses/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var bonus = await _context.Bonuses
            //    .Include(b => b.BonusType)
            //    .Include(b => b.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var bonus = bonusRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (bonus == null)
            {
                return NotFound();
            }

            return View(bonus);
        }

        // POST: Bonuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var bonus = await _context.Bonuses.FindAsync(id);
            //_context.Bonuses.Remove(bonus);
            //await _context.SaveChangesAsync();
            var bonus = bonusRepository.GetDeleteList(id);
            await bonusRepository.Delete(bonus);
            return RedirectToAction(nameof(Index));
        }

        private bool BonusExists(long id)
        {
            return bonusRepository.GetExit(id);
        }
    }
}
