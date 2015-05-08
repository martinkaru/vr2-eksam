using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.ObjectFactory;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Service
{
    public class PetService
    {
        private readonly PetDTOFactory _petFactory;
        private readonly IUOW _uow;

        public PetService(IUOW uow)
        {
            _uow = uow;
            _petFactory = new PetDTOFactory();
        }

        public List<PetDTO> GetAllPets()
        {
            return convertPetsToDtos(_uow.Pets.All.ToList());
        }

        public PetDTO GetPetById(int id)
        {
            var pet = _uow.Pets.GetPetById(id);
            return _petFactory.CreateDTO(pet);
        }

        public List<PetDTO> GetPetsByName(string name)
        {
            return convertPetsToDtos(_uow.Pets.GetPetsByName(name).ToList());
        }

        public List<PetDTO> GetPetsByOwnerID(int ownerID)
        {
            return convertPetsToDtos(_uow.Pets.GetPetsByOwnerID(ownerID).ToList());
        }

        private List<PetDTO> convertPetsToDtos(List<Pet> pets)
        {
            return pets
                .Select(x => _petFactory.CreateDTO(x))
                .ToList();
        }
    }
}