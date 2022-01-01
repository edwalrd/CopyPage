using ClosedXML.Excel;
using Microsoft.Extensions.Caching.Memory;
using practica_1.Intefaces;
using practica_1.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace practica_1.repositories
{
    public class GenereteSheetExcelRepository : IGenereteSheetExcel
    {
        private readonly IMemoryCache _cache;
        public GenereteSheetExcelRepository(IMemoryCache cache)
        {
            _cache = cache;
        }

        public void GenerateSheetExcelMT103(List<Data> data, string handle)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Mt103"); // Nombre de la hoja del documento.
                var currentRow = 3; // Comenzar tres fila mas abajo

                worksheet.Cell(1, 1).Value = "MT 103 Single Customer Credit Transfer"; //TITLE
                worksheet.Cell(1, 3).Value = $"Reporte Generado {DateTime.Now.ToString("dd-MM-yyyyy HH:mm")}"; //TITLE


                worksheet.Columns("A" , "E").AdjustToContents();

                worksheet.Cell(currentRow, 1).Value = "Column1";
                worksheet.Cell(currentRow, 2).Value = "Column2";
                worksheet.Cell(currentRow, 3).Value = "Column3";
                worksheet.Cell(currentRow, 4).Value = "Column4";
                worksheet.Cell(currentRow, 5).Value = "Column5";


                foreach (var x in data)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = x.Column1;
                    worksheet.Cell(currentRow, 2).Value = x.Column2;
                    worksheet.Cell(currentRow, 3).Value = x.Column3;
                    worksheet.Cell(currentRow, 4).Value = x.Column4;
                    worksheet.Cell(currentRow, 5).Value = x.Column5;
                }

                int num = 6;
                for (int i = 1; i < num; i++)
                {
                    worksheet.Cell(3, i).Style.Fill.BackgroundColor = XLColor.MacaroniAndCheese;

                }


                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);

                    stream.Position = 0;

                    _cache.Set(handle, stream.ToArray(),
                    new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(10)));
                }

            }

        }


    }
}
