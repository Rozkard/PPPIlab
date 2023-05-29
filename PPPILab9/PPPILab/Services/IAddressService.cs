using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;


namespace PPPILab.Models
{
    public interface IAddressService
    {
        Task<List<Address>> GetAllAddressesAsync();
        Task<Address> CreateAddressAsync(Address address);
        Task UpdateAddressAsync(int id, Address address);
        Task DeleteAddressAsync(int id);
    }
}
