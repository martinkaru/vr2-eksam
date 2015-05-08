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

        public string DateOfBirth { get; set; }
        public string LastProfileUpdate { get; set; }

        public PetDTO[] Pets { get; set; }

        public bool StateIsActive { get; set; }
    }
}