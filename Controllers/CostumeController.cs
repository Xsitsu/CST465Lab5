using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CST465Lab5.Models;
using CST465Lab5.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CST465Lab5.Controllers
{
    public class CostumeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new CostumeDBRepository().GetList());
        }
        [HttpPost]
        public IActionResult Insert(CostumeModel model)
        {
            new CostumeDBRepository().Insert(model.Name);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(CostumeModel model)
        {
            int id = -1;
            var repo = new CostumeDBRepository();
            foreach (var costume in repo.GetList())
            {
                if (costume.Name == model.Name)
                {
                    id = costume.Id;
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