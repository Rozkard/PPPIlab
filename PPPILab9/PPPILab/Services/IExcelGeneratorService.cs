using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PPPILab.Models;
using ClosedXML.Excel;

namespace PPPILab.Models
{
    public interface IExcelGeneratorService
    {
        byte[] GenerateExcelData();
    }
}