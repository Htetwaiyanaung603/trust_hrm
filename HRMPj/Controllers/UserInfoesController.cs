using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRMPj.Controllers
{
    public class UserInfoesController : Controller
    {
        private readonly IUserInfoRepository userInfoRepository;
        public UserInfoesController(IUserInfoRepository e)
        {
            this.userInfoRepository = e;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(userInfoRepository.GetUserInfoList());
        }
    }
}
