using BLL.DTO;
using Domain.Models;

namespace BLL.ObjectFactory
{
    public class PetDTOFactory
    {
        public PetDTO CreateDTO(Pet pet)
        {
            var ownerFactory = new OwnerDTOFactory();
            return new PetDTO
            {
                PetID = pet.PetID,
                Name = pet.Name,
                Breed = pet.Breed,
                Age = pet.Age,
                Owner = ownerFactory.CreateDTO(pet.Owner)
            };
        }

        public Pet CreateModel(PetDTO petDto)
        {
            OwnerDTOFactory ownerFactory = new OwnerDTOFactory();

            return new Pet
            {
                PetID = petDto.PetID,
                Name = petDto.Name,
                Breed = petDto.Breed,
                Age = petDto.Age,
                Owner = ownerFactory.CreateModel(petDto.Owner),
            };
        }
    }
}