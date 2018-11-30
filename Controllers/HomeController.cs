using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CST465Lab5.Models;
using CST465Lab5.Repositories;

namespace CST465Lab5.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new TreaterDBRepository().GetList());
        }
        [HttpPost]
        public IActionResult Index(TrickOrTreaterModel model)
        {
            new TreaterDBRepository().Insert(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ListAll()
        {
            return View(new TreaterDBRepository().GetList());
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
