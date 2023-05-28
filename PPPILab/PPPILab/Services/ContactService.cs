using PPPILab.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPPILab.Models 
{
    public class ContactService : IContactService
    {
        private static readonly List<Contact> _contacts = new List<Contact>
        {
                new Contact { Id = 1, Name = "John Doe", Email = "johndoe@gmail.com" },
                new Contact { Id = 2, Name = "Jane Smith", Email = "janesmith@gmail.com" },
                new Contact { Id = 3, Name = "Michael Johnson", Email = "michaeljohnson@gmail.com" },
                new Contact { Id = 4, Name = "Emily Davis", Email = "emilydavis@gmail.com" },
                new Contact { Id = 5, Name = "Daniel Wilson", Email = "danielwilson@gmail.com" },
                new Contact { Id = 6, Name = "Olivia Taylor", Email = "oliviataylor@gmail.com" },
                new Contact { Id = 7, Name = "Matthew Anderson", Email = "matthewanderson@gmail.com" },
                new Contact { Id = 8, Name = "Sophia Martinez", Email = "sophiamartinez@gmail.com" },
                new Contact { Id = 9, Name = "David Thomas", Email = "davidthomas@gmail.com" },
                new Contact { Id = 10, Name = "Emma Garcia", Email = "emmagarcia@gmail.com" },
                new Contact { Id = 11, Name = "Christopher Brown", Email = "christopherbrown@gmail.com" },
                new Contact { Id = 12, Name = "Isabella Lopez", Email = "isabellalopez@gmail.com" },
                new Contact { Id = 13, Name = "Andrew Lee", Email = "andrewlee@gmail.com" },
                new Contact { Id = 14, Name = "Mia Moore", Email = "miamoore@gmail.com" },
                new Contact { Id = 15, Name = "James Clark", Email = "jamesclark@gmail.com" }
            };


         
        public async Task<List<Contact>> GetAllContactsAsync()
        {
          
            return _contacts.ToList();
        }

        public async Task<Contact> CreateContactAsync(Contact contact)
        {
          
            contact.Id = _contacts.Count + 1;
            _contacts.Add(contact);
            return contact;
        }

        public async Task UpdateContactAsync(int id, Contact updatedContact)
        {
          
            var existingContact = _contacts.FirstOrDefault(c => c.Id == id);
            if (existingContact != null)
            {
                existingContact.Name = updatedContact.Name;
                existingContact.Email = updatedContact.Email;
            
            }
        }

        public async Task DeleteContactAsync(int id)
        {
          
            var contact = _contacts.FirstOrDefault(c => c.Id == id);
            if (contact != null)
                _contacts.Remove(contact);
        }
        public async Task<Contact> GetContactByIdAsync(int id)
        {
            await Task.Delay(100);
            return _contacts.FirstOrDefault(c => c.Id == id);
        }
    }
}
