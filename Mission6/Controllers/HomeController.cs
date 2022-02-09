using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mission6.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6.Controllers
{
    public class HomeController : Controller
    {
        private ToDoDatabaseContext toDoContext { get; set; } 

        public HomeController(ToDoDatabaseContext context)
        {
            toDoContext = context;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Category = toDoContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Add(ToDoItem response)
        {
            if (ModelState.IsValid)
            {
                toDoContext.Add(response);
                toDoContext.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Category = toDoContext.Categories.ToList();
                return View("Index");
            }
        }

    }
}
