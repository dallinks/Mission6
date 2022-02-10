using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            return View(new ToDoItem());
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
                return View("Add",response);
            }
        }

        [HttpGet]
        public IActionResult Quadrants()
        {
            var tasks = toDoContext.ToDoItems
                .Where(x => x.Completed == false)
                .Include(x => x.Category)
                .OrderBy(x => x.DueDate)
                .ToList();
            return View(tasks);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Category = toDoContext.Categories.ToList();

            var task = toDoContext.ToDoItems.Single(x => x.ToDoItemId == id);
            return View("Add", task);
        }

        [HttpPost]
        public IActionResult Edit(ToDoItem response)
        {
            if (ModelState.IsValid)
            {
                toDoContext.Update(response);
                toDoContext.SaveChanges();
                return RedirectToAction("Quadrants");
            }
            else
            {
                ViewBag.Category = toDoContext.Categories.ToList();
                return View("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            ViewBag.Category = toDoContext.Categories.ToList();
            var task = toDoContext.ToDoItems.Single(x => x.ToDoItemId == id);
            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(ToDoItem item)
        {
            toDoContext.ToDoItems.Remove(item);
            toDoContext.SaveChanges();

            return RedirectToAction("Quadrants");
        }
    }
}
