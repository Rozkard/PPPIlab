using System;
using System.ComponentModel.DataAnnotations;

namespace PPPILab.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        [MaxLength(15)]
        public string FirstName { get; set; }

        [MaxLength(15)]
        public string Surname { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Password { get; set; }

        public DateTime LastAuthorizationDate { get; set; }

        public int FailedAuthorizationAttempts { get; set; }
    }
}
