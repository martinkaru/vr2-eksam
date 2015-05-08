using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using Domain.Models;

namespace DAL.Repositories
{
    public class OwnerRepository : EFRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(IDbContext dbContext) : base(dbContext)
        {
        }

        public List<Owner> GetOwnerByName(string name)
        {
            return DbSet
                .Where(a =>
                    a.FirstName.ToUpper().Contains(name)
                    || a.LastName.ToUpper().Contains(name)
                    || (a.FirstName + " " + a.LastName).ToUpper().Contains(name)
                )
                .ToList();
        }

        public Owner GetOwnerByEmail(string email)
        {
            return DbSet
                .FirstOrDefault(a => a.Email.ToUpper().Contains(email));
        }

        public Owner GetOwnerById(int id)
        {
            return DbSet
                .FirstOrDefault(a => a.OwnerID.Equals(id));
        }
    }
}