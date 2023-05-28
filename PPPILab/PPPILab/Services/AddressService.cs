using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PPPILab.Models 
{
    public class AddressService : IAddressService
    {
        private static readonly List<Address> _addresses = new List<Address>
        {
            new Address { Id = 1, Street = "123 Main St", City = "Kyiv" },
            new Address { Id = 2, Street = "456 Elm St", City = "Odessa" },
            new Address { Id = 3, Street = "789 Oak St", City = "Lviv" },
            new Address { Id = 4, Street = "10 Maple Ave", City = "Kharkiv" },
            new Address { Id = 5, Street = "11 Pine St", City = "Dnipro" },
            new Address { Id = 6, Street = "12 Cedar Rd", City = "Zaporizhia" },
            new Address { Id = 7, Street = "13 Birch St", City = "Vinnytsia" },
            new Address { Id = 8, Street = "14 Walnut Ave", City = "Poltava" },
            new Address { Id = 9, Street = "15 Cherry St", City = "Mykolaiv" },
            new Address { Id = 10, Street = "16 Willow Rd", City = "Chernihiv" },
            new Address { Id = 11, Street = "17 Elm St", City = "Kherson" },
            new Address { Id = 12, Street = "18 Oak Ave", City = "Sumy" },
            new Address { Id = 13, Street = "19 Pine St", City = "Lutsk" }
        };

        public async Task<List<Address>> GetAllAddressesAsync()
        {
            await Task.Delay(100); // Simulating async operation
            return _addresses.ToList();
        }

        public async Task<Address> CreateAddressAsync(Address address)
        {
            await Task.Delay(100); // Simulating async operation
            address.Id = _addresses.Count + 1;
            _addresses.Add(address);
            return address;
        }

        public async Task UpdateAddressAsync(int id, Address updatedAddress)
        {
            await Task.Delay(100); // Simulating async operation
            var existingAddress = _addresses.FirstOrDefault(a => a.Id == id);
            if (existingAddress != null)
            {
                existingAddress.Street = updatedAddress.Street;
                existingAddress.City = updatedAddress.City;
                // Update other properties as needed
            }
        }

        public async Task DeleteAddressAsync(int id)
        {
            await Task.Delay(100); // Simulating async operation
            var address = _addresses.FirstOrDefault(a => a.Id == id);
            if (address != null)
                _addresses.Remove(address);
        }
    }
}
