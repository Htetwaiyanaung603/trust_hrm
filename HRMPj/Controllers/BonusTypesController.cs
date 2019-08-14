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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HRMPj.Controllers
{
    public class BonusTypesController : Controller
    {
        private readonly IBonusTypeRepository bonusTypeRepository;
        private readonly IHttpContextAccessor httpContextAccessor;
        public BonusTypesController(IBonusTypeRepository d, IHttpContextAccessor f)
        {
            this.bonusTypeRepository = d;
            this.httpContextAccessor = f;
        }
        //private readonly ApplicationDbContext _context;

        //public BonusTypesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: BonusTypes
        public async Task<IActionResult> Index()
        {
            return View(await bonusTypeRepository.GetIndex());
        }

        // GET: BonusTypes/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var bonusType = await _context.BonusTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var bonusType = bonusTypeRepository.GetBonusTypeList().FirstOrDefault(m => m.Id == id);
            if (bonusType == null)
            {
                return NotFound();
            }

            return View(bonusType);
        }

        // GET: BonusTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BonusTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TypeName,Amount,IsActive,Year,CreatedDate,CreatedBy")] BonusTypeViewModel bonusType)
        {
            if (ModelState.IsValid)
            {
                var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                BonusType bb = new BonusType()
                {
                    TypeName = bonusType.TypeName,
                    Amount = bonusType.Amount,
                    IsActive = false,
                    Year = "",
                    CreatedBy = userId,
                    CreatedDate = DateTime.Now
                };
                await bonusTypeRepository.Save(bb);
                //_context.Add(bonusType);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bonusType);
        }

        // GET: BonusTypes/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var bonusType = await _context.BonusTypes.FindAsync(id);
            var bonusType = bonusTypeRepository.GetEdit(id);
            if (bonusType == null)
            {
                return NotFound();
            }
            return View(bonusType);
        }

        // POST: BonusTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,TypeName,Amount,IsActive,Year,CreatedDate,CreatedBy")] BonusType bonusType)
        {
            if (id != bonusType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                    bonusType.CreatedDate = DateTime.Now;
                    bonusType.CreatedBy = userId;
                    //_context.Update(bonusType);
                    //await _context.SaveChangesAsync();
                    await bonusTypeRepository.Update(bonusType);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BonusTypeExists(bonusType.Id))
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
            return View(bonusType);
        }

        // GET: BonusTypes/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var bonusType = await _context.BonusTypes
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var bonusType = bonusTypeRepository.GetDeleteList().FirstOrDefault(m => m.Id == id);
            if (bonusType == null)
            {
                return NotFound();
            }

            return View(bonusType);
        }

        // POST: BonusTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var bonusType = await _context.BonusTypes.FindAsync(id);
            //_context.BonusTypes.Remove(bonusType);
            //await _context.SaveChangesAsync();
            var bonusType = bonusTypeRepository.GetDelete(id);
            await bonusTypeRepository.Delete(bonusType);
            return RedirectToAction(nameof(Index));
        }

        private bool BonusTypeExists(long id)
        {
            return bonusTypeRepository.GetExit(id);
        }
    }
}
