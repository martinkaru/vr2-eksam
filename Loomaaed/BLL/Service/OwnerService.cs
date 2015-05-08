using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using BLL.ObjectFactory;
using DAL.Interfaces;
using Domain.Models;

namespace BLL.Service
{
    public class OwnerService
    {
        private readonly OwnerDTOFactory _ownerFactory;
        private readonly IUOW _uow;

        public OwnerService(IUOW uow)
        {
            _uow = uow;
            _ownerFactory = new OwnerDTOFactory();
        }

        public List<OwnerDTO> GetAllOwners()
        {
            return _uow.Owners.All.ToList().Select(x => _ownerFactory.CreateDTO(x)).ToList();
        }

        public OwnerDTO GetOwnerById(int id)
        {
            Owner owner = _uow.Owners.GetOwnerById(id);
            return _ownerFactory.CreateDTO(owner);
        }

        public List<OwnerDTO> SearchAllByName(string name)
        {
            return _uow.Owners.GetOwnerByName(name)
                .Select(x => _ownerFactory.CreateDTO(x))
                .ToList();
        }
    }
}