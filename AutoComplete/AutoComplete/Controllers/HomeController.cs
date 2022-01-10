using AutoComplete.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AutoComplete.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult GetData(string search)
        {
            List<Person> datos = new List<Person>();

            datos.Add(new Person { Name = "Edwal", Lastname = "Tejada" });
            datos.Add(new Person { Name = "Ezequiel", Lastname = "Villalona" });
            datos.Add(new Person { Name = "Steven", Lastname = "Reyes" });
            datos.Add(new Person { Name = "Hojansel", Lastname = "Encanacion" });
            datos.Add(new Person { Name = "David", Lastname = "Sanchez" });
            datos.Add(new Person { Name = "Benito", Lastname = "Ramirez" });
            datos.Add(new Person { Name = "Enmanuel", Lastname = "Herrera" });
            datos.Add(new Person { Name = "Enmanuel", Lastname = "Reyes" });
            datos.Add(new Person { Name = "Enmanuel", Lastname = "Perz" });

            var data = datos.Where(x => x.Name.ToLower().Contains(search.ToLower())).Select(p => p.Name).Distinct().ToList();

            return Json(new { data });
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
