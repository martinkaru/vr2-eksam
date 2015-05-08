using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.ObjectFactory;
using BLL.Service;
using DAL.Interfaces;
using Domain.Models;

namespace WebApiApp.Controllers
{
    public class OwnerController : ApiController
    {
        private readonly OwnerDTOFactory _ownerFactory;
        private readonly OwnerService _ownerService;
        private readonly IUOW _uow;

        public OwnerController(IUOW uow)
        {
            _uow = uow;
            _ownerService = new OwnerService(uow);
            _ownerFactory = new OwnerDTOFactory();
        }

        // GET api/values
        public List<OwnerDTO> Get()
        {
            return _ownerService.GetAllOwners();
        }

        // GET api/values/5
        public OwnerDTO Get(int ownerId)
        {
            return _ownerService.GetOwnerById(ownerId);
        }

        // POST api/values
        [ResponseType(typeof (OwnerDTO))]
        public IHttpActionResult Post([FromBody] OwnerDTO owner)
        {
            owner.LastProfileUpdate = DateTime.Now.ToString();
            _uow.Owners.Add(_ownerFactory.CreateModel(owner));
            _uow.Commit();

            return CreatedAtRoute("DefaultApi", new {id = owner.OwnerID}, owner);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int ownerId, [FromBody] OwnerDTO owner)
        {
            if (!ownerId.Equals(owner.OwnerID))
            {
                return NotFound();
            }
            owner.LastProfileUpdate = DateTime.Now.ToString();

            _uow.Owners.Update(_ownerFactory.CreateModel(owner));
            _uow.Commit();

            return Ok(owner);
        }

        // DELETE api/values/5
        public IHttpActionResult DeleteOwner(int ownerId)
        {
            Owner owner = _uow.Owners.GetOwnerById(ownerId);
            if (owner == null)
            {
                return NotFound();
            }

            foreach (Pet pet in owner.Pets)
            {
                pet.OwnerID = null;
                _uow.Pets.Update(pet);
            }

            _uow.Owners.Delete(owner);
            _uow.Commit();

            return Ok(_ownerFactory.CreateDTO(owner));
        }

        // DELETE api/values/5
        public IHttpActionResult DeleteLogically(int ownerId)
        {
            var owner = _ownerService.GetOwnerById(ownerId);
            if (owner == null)
            {
                return NotFound();
            }

            owner.StateIsActive = false;
            owner.LastProfileUpdate = DateTime.Now.ToLongTimeString();
            _uow.Owners.Update(_ownerFactory.CreateModel(owner));
            _uow.Commit();

            return Ok(owner);
        }

        // DELETE api/values/5
        public IHttpActionResult PutLogically(int ownerId)
        {
            Owner owner = _uow.Owners.GetOwnerById(ownerId);
            if (owner == null)
            {
                return Ok("Owner not found: " + ownerId);
//                return NotFound(); // not found errors need better error handling..
            }

            owner.StateIsActive = true;
            owner.LastProfileUpdate = DateTime.Now.ToString();

            _uow.Owners.Update(owner);
            _uow.Commit();

            return Ok(_ownerFactory.CreateDTO(owner));
        }

        // GET api/owner/getEmptyDto
        public OwnerDTO getEmptyDto()
        {
            return new OwnerDTO();
        }
    }
}