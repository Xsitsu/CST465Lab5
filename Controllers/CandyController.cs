using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CST465Lab5.Models;
using CST465Lab5.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CST465Lab5.Controllers
{
    public class CandyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CandyDBRepository().GetList());
        }
        [HttpPost]
        public IActionResult Insert(CandyModel model)
        {
            new CandyDBRepository().Insert(model.ProductName);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(CandyModel model)
        {
            int id = -1;
            var repo = new CandyDBRepository();
            foreach (var candy in repo.GetList())
            {
                if (candy.ProductName == model.ProductName)
                {
                    id = candy.Id;
                    break;
                }
            }
            if (id != -1)
            {
                repo.Delete(id);
            }
            
            return RedirectToAction("Index");
        }
    }
}