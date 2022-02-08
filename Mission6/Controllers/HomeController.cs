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
       
    }
}
