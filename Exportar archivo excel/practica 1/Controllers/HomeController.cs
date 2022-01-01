using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using practica_1.Intefaces;
using practica_1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace practica_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGenereteSheetExcel _genereteSheetExcel;
        private readonly ILogger<HomeController> _logger;
        private List<Data> datas = new List<Data>();
        private readonly IMemoryCache _cache;
        public HomeController(IGenereteSheetExcel genereteSheetExcel, ILogger<HomeController> logger, IMemoryCache cache)
        {
            _genereteSheetExcel = genereteSheetExcel;
            _logger = logger;
            _cache = cache;

        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ExportToExcel()
        {
            for (int i = 0; i < 20; i++)
            {
                datas.Add(new Data { Column1 = $"xxx{i}", Column2 = $"xxx{i}", Column3 = $"xxx{i}", Column4 = $"xxx{i}", Column5 = $"xxx{i}" });

            }

            string filename = "";

            string handle = Guid.NewGuid().ToString();

            filename = $"MT103{DateTime.Now.ToString("dd-MM-yyyyy HH:mm")}.xlsx";

            _genereteSheetExcel.GenerateSheetExcelMT103(datas, handle);

            return Json(new { filename = filename, fileGuid = handle });
        }

        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            if (_cache.Get<byte[]>(fileGuid) != null)
            {
                byte[] data = _cache.Get<byte[]>(fileGuid);
                _cache.Remove(fileGuid);
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                return View("Index");
            }
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
