using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PPPILab.Models;

namespace PPPILab.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordEncryptionService _passwordEncryptionService;
        private static readonly List<UserModel> _users = new List<UserModel>
        {

        };

        public UserService(IPasswordEncryptionService passwordEncryptionService)
        {
            _passwordEncryptionService = passwordEncryptionService;
           

            _users.Add(new UserModel
            {
                Id = 1,
                FirstName = "John",
                Surname = "Doe",
                Email = "john.doe@example.com",
                DateOfBirth = new DateTime(1990, 1, 1),
                Password = _passwordEncryptionService.EncryptPassword("password1"),
                LastAuthorizationDate = DateTime.Now,
                FailedAuthorizationAttempts = 0
            });

            _users.Add(new UserModel
            {
                Id = 2,
                FirstName = "Jane",
                Surname = "Smith",
                Email = "jane.smith@example.com",
                DateOfBirth = new DateTime(1995, 5, 10),
                Password = _passwordEncryptionService.EncryptPassword("password2"),
                LastAuthorizationDate = DateTime.Now,
                FailedAuthorizationAttempts = 0
            });
            _users.Add(new UserModel
            {
                Id = 3,
                FirstName = "David",
                Surname = "Johnson",
                Email = "david.johnson@example.com",
                DateOfBirth = new DateTime(1985, 3, 15),
                Password = _passwordEncryptionService.EncryptPassword("password3"),
                LastAuthorizationDate = DateTime.Now,
                FailedAuthorizationAttempts = 0
            });
            
            _users.Add(new UserModel
            {
                Id = 4,
                FirstName = "Emily",
                Surname = "Wilson",
                Email = "emily.wilson@example.com",
                DateOfBirth = new DateTime(1988, 9, 20),
                Password = _passwordEncryptionService.EncryptPassword("password4"),
                LastAuthorizationDate = DateTime.Now,
                FailedAuthorizationAttempts = 0
            });
        }

        public UserModel AuthorizeUser(string email, string password)
        {
            var encryptedPassword = _passwordEncryptionService.EncryptPassword(password);
            var user = _users.FirstOrDefault(u => u.Email == email && u.Password == encryptedPassword);
            return user;
        }

        public UserModel RegisterUser(UserModel user)
        {
        
            user.Id = _users.Count + 1;

           
            user.Password = _passwordEncryptionService.EncryptPassword(user.Password);

          
            _users.Add(user);

            return user;
        }
    }
}
