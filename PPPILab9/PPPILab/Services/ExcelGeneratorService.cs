using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ClosedXML.Excel;
using PPPILab.Models;

namespace PPPILab.Services
{
    public class ExcelGeneratorService : IExcelGeneratorService
    {
        public byte[] GenerateExcelData()
        {
            using (var workbook = new XLWorkbook())
            {
               
                var worksheet = workbook.Worksheets.Add("Sheet1");

             
                worksheet.Cell("A1").Value = "Vladyslav";
                worksheet.Cell("B1").Value = "Edynok";

            
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    return stream.ToArray();
                }
            }
        }
    }
}
