using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HRMPj.Models;
using Microsoft.AspNetCore.Authorization;
using HRMPj.Repository;

namespace HRMPj.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeRepository homeRepository;
        public HomeController(IHomeRepository e)
        {
            this.homeRepository = e;
            
        }
        public IActionResult Index()
        {
            int emp = homeRepository.GetEmpList();
            ViewData["Employee"] = emp;
            int leave = homeRepository.GetLeaveList();
            ViewData["Leave"] = leave;
            decimal net = homeRepository.GetTotalPay();
            ViewData["Net"] = net;
            int ll = homeRepository.GetLeaveApprovedList();
            ViewData["App"] = ll;
            int ss = homeRepository.GetResignList();
            ViewData["Res"] = ss;
            int e = homeRepository.GetEmpAccount();
            ViewData["Account"] = e;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
