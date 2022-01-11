using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SelectAll.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SelectAll.Controllers
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
            List<Vehicule> vehicules = new List<Vehicule>()
            {
                new Vehicule {id=1 ,  Marca = "Hyundai" , Modelo = "Tucson"},
                new Vehicule {id=2 ,  Marca = "Kia" , Modelo = "K5"},
                new Vehicule {id=3 ,  Marca = "Honda" , Modelo = "Civic"},
                new Vehicule {id=4 ,  Marca = "Toyota" , Modelo = "Corolla"},
                new Vehicule {id=5 ,  Marca = "Audi" , Modelo = "A5"}
           };


            return View(vehicules.ToList());
        }

        //Metodo para borrar por id todos los Items selecionados.
        public IActionResult DeleteAll(List<string> selectedIDs)
        {

            var ver = selectedIDs;

            return Json(new { data = "Bien" });
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
