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
    public class CompaniesController : Controller
    {
        private readonly ICompanyRepository companyRepository;
        public CompaniesController(ICompanyRepository c)
        {
            this.companyRepository = c;
        }
        //private readonly ApplicationDbContext _context;

        //public CompaniesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Companies
        public async Task<IActionResult> Index()
        {                   
            return View(await companyRepository.GetCompanyListc());
        }
        [HttpGet]
        public IActionResult GetSearchList(string searchId)
        {
            List<Company> com = companyRepository.GetSearchList(searchId);
            var d = JsonConvert.SerializeObject(com, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d, "application/json");
        }

        // GET: Companies/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var company = await _context.Companies
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var company =  companyRepository.GetCompanyList().FirstOrDefault(m => m.Id == id);
               
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,CreatedDate")] CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                Company com = new Company()
                {
                    CompanyName = company.CompanyName,
                    CreatedDate = company.CreatedDate
                };
                //_context.Add(company);
                await companyRepository.SaveCompany(com);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Companies/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var company = await _context.Companies.FindAsync(id);
            var company =  companyRepository.GetCompany(id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        //// POST: Companies/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CompanyName,CreatedDate")] Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //  _context.Update(company);
                    //await _context.SaveChangesAsync();
                    await companyRepository.Update(company);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyExists(company.Id))
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
            return View(company);
        }

        //// GET: Companies/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //  var company = await _context.Companies
            //     .FirstOrDefaultAsync(m => m.Id == id);
            var company = companyRepository.GetCompanyList().FirstOrDefault(m => m.Id == id);

            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        //// POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var company = companyRepository.GetDelete(id);
            // _context.Companies.Remove(company);
            // await _context.SaveChangesAsync();
            await companyRepository.Delete(company);
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyExists(long id)
        {
            return companyRepository.GetExit(id);
        }
    }
}
