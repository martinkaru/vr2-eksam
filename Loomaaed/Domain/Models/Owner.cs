using System;
using System.Net.Configuration;

namespace Domain.Models
{
    public class Owner
    {
        public int OwnerID { get; set; }
        public string PersonalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime LastProfileUpdate { get; set; }

        public Pet[] Pets { get; set; }

        // Loogiline kustutamine
        public bool IsActive { get; set; }
    }
}