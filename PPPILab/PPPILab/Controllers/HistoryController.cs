using Microsoft.AspNetCore.Mvc;
using PPPILab.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PPPILab.Services
{

    [Route("api/history")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService _historyService;

        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }

        // GET api/history
        [HttpGet]
        public async Task<ActionResult<List<HistoryData>>> GetAllHistoryData()
        {
            var historyData = await _historyService.GetAllHistoryDataAsync();
            return Ok(historyData);
        }

        // POST api/history
        [HttpPost]
        public async Task<ActionResult<HistoryData>> CreateHistoryData(HistoryData historyData)
        {
            var createdHistoryData = await _historyService.CreateHistoryDataAsync(historyData);
            return Ok(createdHistoryData);
            //return CreatedAtAction(nameof(GetHistoryDataById), new { id = createdHistoryData.Id }, createdHistoryData);
        }

        // PUT api/history/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHistoryData(int id, HistoryData historyData)
        {
            await _historyService.UpdateHistoryDataAsync(id, historyData);
            return NoContent();
        }

        // DELETE api/history/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistoryData(int id)
        {
            await _historyService.DeleteHistoryDataAsync(id);
            return NoContent();
        }
    }
}
