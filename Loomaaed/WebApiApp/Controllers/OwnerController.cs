﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.ObjectFactory;
using BLL.Service;
using DAL.Interfaces;

namespace WebApiApp.Controllers
{
    [Authorize]
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
        public OwnerDTO Get(int id)
        {
            return _ownerService.GetOwnerById(id);
        }

        // POST api/values
        [ResponseType(typeof(OwnerDTO))]
        public IHttpActionResult Post([FromBody] OwnerDTO owner)
        {
            _uow.Owners.Add(_ownerFactory.CreateModel(owner));
            _uow.Commit();

            return CreatedAtRoute("DefaultApi", new { id = owner.OwnerID }, owner);
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody] OwnerDTO owner)
        {
            if (!id.Equals(owner.OwnerID))
            {
                return NotFound();
            }

            _uow.Owners.Update(_ownerFactory.CreateModel(owner));
            _uow.Commit();

            return Ok(owner);
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            OwnerDTO owner = _ownerService.GetOwnerById(id);

            _uow.Owners.Delete(_ownerFactory.CreateModel(owner));
            _uow.Commit();

            return Ok(owner);
        }

        // DELETE api/values/5
        public IHttpActionResult DeleteLogically(int id)
        {
            OwnerDTO owner = _ownerService.GetOwnerById(id);
            owner.IsActive = false;

            _uow.Owners.Update(_ownerFactory.CreateModel(owner));
            _uow.Commit();

            return Ok(owner);
        }

        // DELETE api/values/5
        public IHttpActionResult PutLogically(int id, [FromBody] OwnerDTO owner)
        {
            if (!id.Equals(owner.OwnerID))
            {
                return NotFound();
            }
            owner.IsActive = true;

            _uow.Owners.Update(_ownerFactory.CreateModel(owner));
            _uow.Commit();

            return Ok(owner);
        }
    }
}