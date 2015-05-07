using BLL.DTO;
using Domain.Models;

namespace BLL.ObjectFactory
{
    public class OwnerDTOFactory
    {
        public OwnerDTO CreateDTO(Owner owner)
        {
            return new OwnerDTO
            {
                OwnerID = owner.OwnerID,
                PersonalCode = owner.PersonalCode,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Email = owner.Email,
                DateOfBirth = owner.DateOfBirth,
                LastProfileUpdate = owner.LastProfileUpdate
            };
        }

        public OwnerDTO CreateDTO(Owner owner, PetDTO[] pets)
        {
            var ownerDto = CreateDTO(owner);
            ownerDto.Pets = pets;
            return ownerDto;
        }

        public Owner CreateModel(OwnerDTO owner)
        {
            return new Owner
            {
                OwnerID = owner.OwnerID,
                PersonalCode = owner.PersonalCode,
                FirstName = owner.FirstName,
                LastName = owner.LastName,
                Email = owner.Email,
                DateOfBirth = owner.DateOfBirth,
                LastProfileUpdate = owner.LastProfileUpdate
            };
        }

        public Owner CreateModel(OwnerDTO owner, Pet[] pets)
        {
            var ownerModel = CreateModel(owner);
            ownerModel.Pets = pets;
            return ownerModel;
        }
    }
}