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
    public class AttendancesController : Controller
    {
        private readonly IEmployeeInfoRepository employeeInfoRepository;
        private readonly IAttendance attendanceRepository;
        private readonly IBranchRepository branchRepository;
        private readonly IDepartmentRepository departmentRepository;
        public AttendancesController( IEmployeeInfoRepository e,IAttendance a,IBranchRepository b,IDepartmentRepository d)
        {
            this.attendanceRepository = a;
            this.employeeInfoRepository = e;
            this.branchRepository = b;
            this.departmentRepository = d;
        }
        //private readonly ApplicationDbContext _context;

        //public AttendancesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
        //    List<EmployeeInfo> searchEmployee = new List<EmployeeInfo>();
        //    ViewBag.Employee = searchEmployee;
        //    return View(attendanceRepository.GetDetail());
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Index(AttendanceSearchViewModel search)
        //{

        //  //  List<Attendance> searchEmployee = attendanceRepository.GetAttendaceSearchList(search.BranchId, search.DepartmentId);
        //   // ViewBag.Employee = searchEmployee;
        //    return View();
        //}
        [HttpGet]
        public IActionResult GetAttendance()
        {
            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
            List<Attendance> searchEmployee = attendanceRepository.GetDetail();
            ViewBag.Employee = new List<AttendancdRecordViewModel>();
            ViewBag.DayList = new List<int>();
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetAttendance(AttendanceSearchViewModel search)
        {

            List<AttendancdRecordViewModel> searchEmployee = attendanceRepository.GetAttendaceSearchList(search.BranchId, search.DepartmentId,search.FromDate,search.ToDate);
            ViewBag.Employee = searchEmployee;
            ViewBag.DayList = attendanceRepository.GetDayList(search.FromDate, search.ToDate);
            return View();
        }

        // GET: Attendances/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var attendance = await _context.Attendance
            //    .Include(a => a.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var attendance = attendanceRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // GET: Attendances/Create
        //public IActionResult Create()
        //{
        //    ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
        //    ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartmentList(), "Id", "Id");
        //    List<EmployeeInfo> searchEmployee = new List<EmployeeInfo>();
        //    ViewData["Employee"] = new SelectList(searchEmployee);
        //    return View();
        //}

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,AttendanceDate,CreatedDate,CreatedBy,Status,EmployeeInfoId")] AttendanceViewModel attendance)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        Attendance at = new Attendance()
        //        {
        //            AttendanceDate = attendance.AttendanceDate,
        //            Status = attendance.Status,
        //            CreatedBy = attendance.CreatedBy,
        //            CreatedDate = DateTime.Now,
                    
        //            EmployeeInfoId = attendance.EmployeeInfoId
        //        };
        //        await attendanceRepository.Save(at);
        //        //_context.Add(attendance);
        //        //await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", attendance.EmployeeInfoId);
        //    ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
        //    ViewData["DepartmentId"] = new SelectList(departmentRepository.GetDepartmentList(), "Id", "Id");

        //    return View(attendance);
        //}

        [HttpGet]
        public IActionResult SearchEmployeeForAttendance()
        {

            ViewData["BranchId"] = new SelectList(branchRepository.GetBranchList(), "Id", "BranchName");
            List<EmployeeInfo> searchEmployee = new List<EmployeeInfo>();
            ViewBag.Employee = searchEmployee;
            string currentMonth = DateTime.Now.ToString();
            ViewData["Month"] = currentMonth;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchEmployeeForAttendance(SearchViewModel search)
        {
           
            List<EmployeeInfo> searchEmployee = employeeInfoRepository.GetEmployeeListByBranchAndDepartmentId(search.BranchId, search.DepartmentId);
            ViewBag.Employee = searchEmployee;
            ViewBag.AttDate = search.AttendanceDate;
            ViewBag.branch = search.BranchId;
            ViewBag.department = search.DepartmentId;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveAttendance(List<EmployeeAttendanceViewModel> emp)
        {
            if (ModelState.IsValid)
            {


                foreach (var item in emp)
                {
                    Attendance atten = new Attendance()
                    {
                        Status = item.Status,
                        AttendanceDate = item.AttendanceDate,
                        EmployeeInfoId = item.EmployeeId,
                        CreatedDate = DateTime.Now,
                        BranchId=item.BranchId,
                        DepartmentId=item.DepartmentId,
                        CreatedBy=""
                    };
                    await attendanceRepository.Save(atten);
                };

                return RedirectToAction(nameof(GetAttendance));
            };
            return View(emp);
            
        }



        // GET: Attendances/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var attendance = await _context.Attendance.FindAsync(id);
            var attendance = attendanceRepository.GetEdit(id);
            if (attendance == null)
            {
                return NotFound();
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", attendance.EmployeeInfoId);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,AttendanceDate,InTime,OutTime,CreatedDate,CreatedBy,EarlyInTime,EarlyOutTime,LateInTime,LateOutTime,EmployeeInfoId")] Attendance attendance)
        {
            if (id != attendance.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(attendance);
                    //await _context.SaveChangesAsync();
                    await attendanceRepository.Update(attendance);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AttendanceExists(attendance.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(GetAttendance));
            }
            ViewData["EmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "Id", attendance.EmployeeInfoId);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var attendance = await _context.Attendance
            //    .Include(a => a.EmployeeInfo)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var attendance = attendanceRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var attendance = await _context.Attendance.FindAsync(id);
            //_context.Attendance.Remove(attendance);
            //await _context.SaveChangesAsync();
            var attendance = attendanceRepository.GetDeleteList(id);
            await attendanceRepository.Delete(attendance);
            return RedirectToAction(nameof(GetAttendance));
        }

        private bool AttendanceExists(long id)
        {
            return attendanceRepository.GetExit(id);
        }
    }
}
