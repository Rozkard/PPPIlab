using System.Collections.Generic;
using System.Threading.Tasks;


namespace PPPILab.Models
{
    public interface IHistoryService
    {
        Task<List<HistoryData>> GetAllHistoryDataAsync();
        Task<HistoryData> CreateHistoryDataAsync(HistoryData historyData);
        Task UpdateHistoryDataAsync(int id, HistoryData historyData);
        Task DeleteHistoryDataAsync(int id);
    }
}
