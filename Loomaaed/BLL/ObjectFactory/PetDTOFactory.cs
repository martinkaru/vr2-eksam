using BLL.DTO;
using Domain.Models;

namespace BLL.ObjectFactory
{
    public class PetDTOFactory
    {
        public PetDTO CreateDTO(Pet pet)
        {
            var ownerFactory = new OwnerDTOFactory();
            var petDto = new PetDTO
            {
                PetID = pet.PetID,
                Name = pet.Name,
                Breed = pet.Breed,
                Age = pet.Age,
                OwnerID = pet.OwnerID
            };

            return petDto;
        }

        public Pet CreateModel(PetDTO petDto)
        {
            var ownerFactory = new OwnerDTOFactory();

            var pet = new Pet
            {
                PetID = petDto.PetID,
                Name = petDto.Name,
                Breed = petDto.Breed,
                Age = petDto.Age,
                OwnerID = petDto.OwnerID
            };

            return pet;
        }
    }
}