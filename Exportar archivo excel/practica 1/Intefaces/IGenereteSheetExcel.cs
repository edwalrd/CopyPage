using practica_1.Models;
using System.Collections.Generic;

namespace practica_1.Intefaces
{
    public interface IGenereteSheetExcel
    {
        void GenerateSheetExcelMT103(List<Data> data, string handle);
    }
}
