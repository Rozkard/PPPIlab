
using Microsoft.AspNetCore.Mvc;
using PPPILab.Models;
using PPPILab.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Versioning;

namespace PPPILab.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/sample")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiVersion("3.0")]
    public class VersionController : ControllerBase
    {
        private readonly IExcelGeneratorService _excelGeneratorService;

        public VersionController(IExcelGeneratorService excelGeneratorService)
        {
            _excelGeneratorService = excelGeneratorService;
        }

        [HttpGet("v1")]
        [MapToApiVersion("1.0")]
        [Obsolete("This version is obsolete.")]
        public IActionResult GetV1()
        {
            int intValue = 42; 
            return Ok(intValue);
        }

        [HttpGet("v2")]
        [MapToApiVersion("2.0")]
        public IActionResult GetV2()
        {
            string textValue = "Sample text"; 
            return Ok(textValue);
        }

        [HttpGet("v3")]
        [MapToApiVersion("3.0")]
        public IActionResult GetV3()
        {
            var excelData = _excelGeneratorService.GenerateExcelData();
      
            return File(excelData, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "sample.xlsx");
        }
    }
}
