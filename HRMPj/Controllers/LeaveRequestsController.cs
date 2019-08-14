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
    public class LeaveRequestsController : Controller
    {
        public readonly ILeaveRequestRepository leaveRequestRepository;
        public readonly ILeaveTypeRepository leaveTypeRepository;
        public readonly IEmployeeInfoRepository employeeInfoRepository;
        public readonly IOverTimeRepository overTimeRepository;

        public LeaveRequestsController(ILeaveRequestRepository oi, ILeaveTypeRepository ie, IEmployeeInfoRepository i, IOverTimeRepository o)
        {
            this.leaveRequestRepository = oi;
            this.leaveTypeRepository = ie;
            this.employeeInfoRepository = i;
            this.overTimeRepository = o;
        }


        // GET: LeaveRequests
        public IActionResult Index()
        {
            return View(leaveRequestRepository.GetDetail());
        }

        public IActionResult LeaveRequestView()
        {
          
            return View(leaveRequestRepository.RetrieveLeaveRequestList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LeaveRequestView(DateTime LeaveFromDate,DateTime LeaveToDate,string Status)
        {
            List<LeaveRequest> leave = leaveRequestRepository.GetStatus(LeaveFromDate, LeaveToDate, Status);
            return View(leave);
        }

        public IActionResult LeaveRequestChangeStatus(long LeaveRequestId, string status)
        {
            string Status = leaveRequestRepository.UpdateStatus(LeaveRequestId, status).ToString();


            return Content("true", "application/json");

        }
        // GET: LeaveRequests/Details/5
        public IActionResult Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var leaveRequest = leaveRequestRepository.GetDetail().FirstOrDefault(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }
        [HttpGet]
        public IActionResult GetToEmployeeList(long FromEmployeeInfoId)
        {

            List<EmployeeInfo> employeeList = overTimeRepository.GetEmployeeListByFromEmployeeId(FromEmployeeInfoId);
            var d = JsonConvert.SerializeObject(employeeList, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            });
            return Content(d, "application/json");
        }
        // GET: LeaveRequests/Create
        public IActionResult Create()
        {
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "TypeName");
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName");
            return View();
        }

        // POST: LeaveRequests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveFromDate,LeaveToDate,Description,LeaveTotalDay,HalfDay,UnPaidLeaveStatus,LeaveRemainDay,LeaveTypeId,FromEmployeeInfoId,ToEmployeeInfoId")] LeaveRequestViewModel leaveRequest)
        {
            if (ModelState.IsValid)
            {
                LeaveRequest ll = new LeaveRequest()
                {
                    CurrentYear = DateTime.Now.Year,
                    LeaveFromDate = leaveRequest.LeaveFromDate,
                    LeaveToDate = leaveRequest.LeaveToDate,
                    LeaveTotalDay = leaveRequest.LeaveTotalDay,
                    HalfDay = leaveRequest.HalfDay.ToString(),
                    Description = leaveRequest.Description,
                    Status = LeaveStatus.Pending.ToString(),
                    UnPaidLeaveStatus = leaveRequest.UnPaidLeaveStatus.ToString(),
                    LeaveRemainDay = leaveRequest.LeaveRemainDay,
                    FromEmployeeInfoId = leaveRequest.FromEmployeeInfoId,
                    ToEmployeeInfoId = leaveRequest.ToEmployeeInfoId
                };
                if (leaveRequest.UnPaidLeaveStatus)
                {
                    ll.LeaveType = null;
                }
                else
                {
                    ll.LeaveTypeId = leaveRequest.LeaveTypeId;
                }

                await leaveRequestRepository.Save(ll);
                return RedirectToAction(nameof(Index));
            }
            /*ViewBag.Message = ModelState.ErrorCount + ">>>>> ";*/
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "TypeName", leaveRequest.LeaveTypeId);
            ViewData["FromEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName", leaveRequest.FromEmployeeInfoId);
            ViewData["ToEmployeeInfoId"] = new SelectList(employeeInfoRepository.GetEmployeeInfoList(), "Id", "EmployeeName", leaveRequest.ToEmployeeInfoId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Edit/5
        public IActionResult Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveRequest = leaveRequestRepository.GetEdit(id);
            if (leaveRequest == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "TypeName", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // POST: LeaveRequests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,CurrentYear,LeaveFromDate,LeaveToDate,LeaveTotalDay,HalfDay,HalfStatus,Status,Description,UnPaidLeaveStatus,PayRollStatus,LeaveTypeId,FromEmployeeInfoId,ToEmployeeInfoId")] LeaveRequest leaveRequest)
        {
            if (id != leaveRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(leaveRequest);
                    //await _context.SaveChangesAsync();
                    await leaveRequestRepository.Update(leaveRequest);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveRequestExists(leaveRequest.Id))
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
            ViewData["LeaveTypeId"] = new SelectList(leaveTypeRepository.GetLeaveTypeList(), "Id", "Id", leaveRequest.LeaveTypeId);
            return View(leaveRequest);
        }

        // GET: LeaveRequests/Delete/5
        public IActionResult Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var leaveRequest = await _context.LeaveRequests
            //    .Include(l => l.LeaveType)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var leaveRequest = leaveRequestRepository.GetDelete().FirstOrDefault(m => m.Id == id);
            if (leaveRequest == null)
            {
                return NotFound();
            }

            return View(leaveRequest);
        }
        public IActionResult GetLeaveRemainDay(long LeaveTypeId, long FromEmpId)
        {



            decimal RemainDay = leaveTypeRepository.GetLeaveRemainDay(LeaveTypeId, FromEmpId);


            var day = JsonConvert.SerializeObject(RemainDay, Formatting.None, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore

            });
            return Content(day, "application/json");
        }



        // POST: LeaveRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            //var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            //_context.LeaveRequests.Remove(leaveRequest);
            //await _context.SaveChangesAsync();
            var leaveRequest = leaveRequestRepository.GetDeleteList(id);
            await leaveRequestRepository.Delete(leaveRequest);
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveRequestExists(long id)
        {
            return leaveRequestRepository.GetExit(id);
        }
    }
}
