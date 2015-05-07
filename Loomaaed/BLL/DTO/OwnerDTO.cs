using System;

namespace BLL.DTO
{
    public class OwnerDTO
    {
        public int OwnerID { get; set; }

        public string PersonalCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public DateTime DateOfBirth { get; set; }
        public DateTime LastProfileUpdate { get; set; }

        public PetDTO[] Pets { get; set; }

        public bool IsActive { get; set; }
    }
}