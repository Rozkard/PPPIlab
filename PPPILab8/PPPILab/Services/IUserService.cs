using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PPPILab.Models;

namespace PPPILab.Services
{
    public interface IUserService
    {
        UserModel AuthorizeUser(string email, string password);
        UserModel RegisterUser(UserModel user);
    }
}