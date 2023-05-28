using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPPILab.Models 
{
    public class HistoryService : IHistoryService
    {
        private static readonly List<HistoryData> _historyDataList = new List<HistoryData>
        {
            new HistoryData { Id = 1, Title = "Login", Description = "User login to the system" },
            new HistoryData { Id = 2, Title = "Record Creation", Description = "A new record was created" },
            new HistoryData { Id = 3, Title = "Data Update", Description = "Existing data was updated" },
            new HistoryData { Id = 4, Title = "Logout", Description = "User logged out of the system" },
            new HistoryData { Id = 5, Title = "Record Deletion", Description = "A record was deleted" },
            new HistoryData { Id = 6, Title = "Data Import", Description = "Data was imported into the system" },
            new HistoryData { Id = 7, Title = "Data Export", Description = "Data was exported from the system" },
            new HistoryData { Id = 8, Title = "System Error", Description = "An error occurred in the system" },
            new HistoryData { Id = 9, Title = "Permission Change", Description = "User permission was changed" },
            new HistoryData { Id = 10, Title = "Password Reset", Description = "User password was reset" }
        };

        public async Task<List<HistoryData>> GetAllHistoryDataAsync()
        {
          
            return _historyDataList.ToList();
        }

        public async Task<HistoryData> CreateHistoryDataAsync(HistoryData historyData)
        {
          
            historyData.Id = _historyDataList.Count + 1;
            _historyDataList.Add(historyData);
            return historyData;
        }

        public async Task UpdateHistoryDataAsync(int id, HistoryData updatedHistoryData)
        {
          
            var existingHistoryData = _historyDataList.FirstOrDefault(h => h.Id == id);
            if (existingHistoryData != null)
            {
                existingHistoryData.Title = updatedHistoryData.Title;
                existingHistoryData.Description = updatedHistoryData.Description;
               
            }
        }

        public async Task DeleteHistoryDataAsync(int id)
        {
          
            var historyData = _historyDataList.FirstOrDefault(h => h.Id == id);
            if (historyData != null)
                _historyDataList.Remove(historyData);
        }
    }
}
