using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoList.Web.Models;
using ToDoList.Web.Repositories;

namespace ToDoList.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly Repository<ApplicationUser> _userRepository;
        public HomeController()
        {
            _userRepository = new Repository<ApplicationUser>();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}