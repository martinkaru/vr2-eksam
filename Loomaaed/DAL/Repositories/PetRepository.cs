using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories
{
    public class PetRepository : EFRepository<Pet>, IPetRepository
    {
        public PetRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<Pet> GetPetsByName(string name)
        {
            return DbSet
                .Where(a => a.Name.ToUpper().Contains(name))
                .ToList();
        }

        public List<Pet> GetPetsByOwnerID(int ownerID)
        {
            return DbSet
                .Where(a => a.OwnerID.Equals(ownerID))
                .ToList();
        }

        public Pet GetPetById(int id)
        {
            return DbSet
                .FirstOrDefault(a => a.PetID.Equals(id));
        }
    }
}