using System.Collections.Generic;
using System.Threading.Tasks;


namespace PPPILab.Models
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContactsAsync();
        Task<Contact> CreateContactAsync(Contact contact);
        Task<Contact> GetContactByIdAsync(int id);
        Task UpdateContactAsync(int id, Contact contact);
        Task DeleteContactAsync(int id);
    }
}
