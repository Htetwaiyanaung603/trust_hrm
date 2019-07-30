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
using System.IO;
using Newtonsoft.Json;

namespace HRMPj.Controllers
{
    public class EmployeeInfoesController : Controller
    {
        private readonly IBranchRepository  branchRepository;
        private readonly IDepartmentRepository departmentRepository;
        private readonly IDesignationRepository designationRepository;
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        public EmployeeInfoesController(IBranchRepository b,IDesignationRepository ds,IDepartmentRepository dp,IEmployeeInfoRepository e)
        {
            this.branchRepository = b;
            this.departmentRepository = dp;
            this.designationRepository = ds;
            this.employeeInfoRepository = e;
        }
        //private readonly ApplicationDbContext _context;

        //public EmployeeInfoesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        // GET: EmployeeInfoes
        public IActionResult Index()
        {
           // var applicationDbContext = _conext.EcontmployeeInfos.Include(e => e.Branch).Include(e => e.Department).Include(e => e.Designation);
            return View(employeeInfoRepository.GetDetail());
        }
        [HttpGet]
        public IActionResult GetDepartmentList(long BranchId)
        {

            List<Department> departmentList = departmentRepository.GetDepartmentListByBranchs(BranchId);
            var d = JsonConvert.SerializeObject(departmentList, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d, "application/json");
        }
        [HttpGet]
        public IActionResult GetDesignationList(long DepartmentId)
        {

            List<Designation> designationlist = designationRepository.GetDesignationListByDepartmentId(DepartmentId);
            var d = JsonConvert.SerializeObject(designationlist, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d, "application/json");
        }
        // GET: EmployeeInfoes/Details/5
        //public async Task<IActionResult> Details(long? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var employeeInfo = await _context.EmployeeInfos
        //        .Include(e => e.Branch)
        //        .Include(e => e.Department)
        //        .Include(e => e.Designation)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (employeeInfo == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employeeInfo);
        //}

        // GET: EmployeeInfoes/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
            ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartmentList(), "Id", "Name");
            ViewData["DesignationId"] = new SelectList(designationRepository.GetDesignationList(), "Id", "Name");
            return View();
        }

        // POST: EmployeeInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( EmployeeInfoViewModel employee)
        {
            if (ModelState.IsValid)
            {
                List<Document> teaList = new List<Document>();

                if (employee.DocumentProfile != null)
                {

                    foreach (IFormFile photo in employee.DocumentProfile)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photo.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        photo.CopyTo(stream);
                        Document teas = new Document()
                        {
                            DocumentImagePath = photo.FileName
                        };
                        teaList.Add(teas);
                    }
                };


                if (employee.EmployeeProfile != null)
                {
                    foreach (IFormFile photos in employee.EmployeeProfile)
                    {
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", photos.FileName);
                        var stream = new FileStream(path, FileMode.Create);
                        photos.CopyTo(stream);
                        EmployeeInfo str = new EmployeeInfo()
                        {
                            EmployeeName = employee.EmployeeName,
                            FatherName = employee.FatherName,
                            NRC = employee.NRC,
                            Nationality = employee.Nationality,
                            Gender = employee.Gender,
                            MartialStatus = employee.MartialStatus,
                            MobilePhone = employee.MobilePhone,
                            DateOfBirth = employee.DateOfBirth,
                            CurrentAddress = employee.CurrentAddress,
                            EmergencyNo = employee.EmergencyNo,
                            AccountNo = employee.AccountNo,
                            ATMNumber = employee.ATMNumber,
                            IsActive = employee.IsActive,
                            CreatedDate = DateTime.Now,
                            CreatedBy = "",
                            EmployeeProfile = photos.FileName,
                            Document = teaList,
                            DepartmentId=employee.DepartmentId,
                            DesignationId=employee.DesignationId,
                            BranchId=employee.BranchId,
                            BasicSalary=employee.BasicSalary
                        };
                        await employeeInfoRepository.Save(str);

                    }
                    return RedirectToAction(nameof(Index));
                }

            }
        
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "Id", employee.BranchId);
            ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartmentList(), "Id", "Id", employee.DepartmentId);
            ViewData["DesignationId"] = new SelectList(designationRepository.GetDesignationList(), "Id", "Id", employee.DesignationId);
            return View(employee);
        }

        // GET: EmployeeInfoes/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // var employeeInfo = await _context.EmployeeInfos.FindAsync(id);
            var employeeInfo = employeeInfoRepository.GetEdit(id);
            if (employeeInfo == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "Id", employeeInfo.BranchId);
            ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartmentList(), "Id", "Id", employeeInfo.DepartmentId);
            ViewData["DesignationId"] = new SelectList(designationRepository.GetDesignationList(), "Id", "Id", employeeInfo.DesignationId);
            return View(employeeInfo);
        }

        //// POST: EmployeeInfoes/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,EmployeeName,FatherName,Gender,NRC,Nationality,MartialStatus,DateOfBirth,MobilePhone,CurrentAddress,EmergencyNo,AccountNo,ATMNumber,IsActive,CreatedDate,CreatedBy,EmployeeProfile,BranchId,DepartmentId,DesignationId")] EmployeeInfo employeeInfo)
        {
            if (id != employeeInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await employeeInfoRepository.Update(employeeInfo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeInfoExists(employeeInfo.Id))
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
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "Id", employeeInfo.BranchId);
            ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartmentList(), "Id", "Id", employeeInfo.DepartmentId);
            ViewData["DesignationId"] = new SelectList(designationRepository.GetDesignationList(), "Id", "Id", employeeInfo.DesignationId);
            return View(employeeInfo);
        }

        //// GET: EmployeeInfoes/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var employeeInfo = await _context.EmployeeInfos
            //    .Include(e => e.Branch)
            //    .Include(e => e.Department)
            //    .Include(e => e.Designation)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var employeeInfo = employeeInfoRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (employeeInfo == null)
            {
                return NotFound();
            }

            return View(employeeInfo);
        }

        //// POST: EmployeeInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var employeeInfo = await _context.EmployeeInfos.FindAsync(id);
            //_context.EmployeeInfos.Remove(employeeInfo);
            //await _context.SaveChangesAsync();
            var employeeInfo = employeeInfoRepository.GetDeleteList(id);
            await employeeInfoRepository.Delete(employeeInfo);
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeInfoExists(long id)
        {
            return employeeInfoRepository.GetExit(id) ;
        }
    }
}
