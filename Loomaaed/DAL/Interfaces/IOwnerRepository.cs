using System.Collections.Generic;
using Domain.Models;

namespace DAL.Interfaces
{
    public interface IOwnerRepository : IEFRepository<Owner>
    {
        List<Owner> GetOwnerByName(string userName);
        Owner GetOwnerByEmail(string email);
        Owner GetOwnerById(int id);
    }
}