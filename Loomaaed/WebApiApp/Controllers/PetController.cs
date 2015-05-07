using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using BLL.DTO;
using BLL.ObjectFactory;
using BLL.Service;
using DAL.Interfaces;

namespace WebApiApp.Controllers
{
    [Authorize]
    public class PetController : ApiController
    {
        private readonly PetDTOFactory _petFactory;
        private readonly PetService _petService;
        private readonly IUOW _uow;

        public PetController(IUOW uow)
        {
            _uow = uow;
            _petService = new PetService(uow);
            _petFactory = new PetDTOFactory();
        }

        // GET api/pet
        public List<PetDTO> Get()
        {
            return _petService.GetAllPets();
        }

        // GET api/pet/5
        public PetDTO Get(int id)
        {
            return _petService.GetPetById(id);
        }

        // POST api/pet
        [ResponseType(typeof (PetDTO))]
        public IHttpActionResult Post([FromBody] PetDTO pet)
        {
            _uow.Pets.Add(_petFactory.CreateModel(pet));
            _uow.Commit();

            return CreatedAtRoute("DefaultApi", new {id = pet.PetID}, pet);
        }

        // PUT api/pet/5
        public IHttpActionResult Put(int id, [FromBody] PetDTO pet)
        {
            if (!id.Equals(pet.PetID))
            {
                return NotFound();
            }

            _uow.Pets.Update(_petFactory.CreateModel(pet));
            _uow.Commit();

            return Ok(pet);
        }

        // DELETE api/pet/5
        public IHttpActionResult Delete(int id)
        {
            var pet = _petService.GetPetById(id);

            _uow.Pets.Delete(_petFactory.CreateModel(pet));
            _uow.Commit();

            return Ok(pet);
        }

        // GET api/pet/getEmptyDto
        public PetDTO GetEmptyDto()
        {
            return new PetDTO();
        }
    }
}