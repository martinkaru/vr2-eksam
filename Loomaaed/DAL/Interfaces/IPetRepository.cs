using System.Collections.Generic;
using Domain.Models;

namespace DAL.Interfaces
{
    public interface IPetRepository : IEFRepository<Pet>
    {
        List<Pet> GetPetsByName(string name);
    }
}