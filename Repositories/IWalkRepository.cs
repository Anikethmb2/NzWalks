using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NzWalks.Models.Domain;

namespace NzWalks.Repositories
{
    public interface IWalkRepository
    {
         Task<Walks> CreateAsync(Walks walks);
         Task<List<Walks>> GetAllAsync();

         Task<Walks?> GetWalkByIdAsync(Guid id);

         Task<Walks?> UpdateWalkAsync(Guid id, Walks walk);
       // Task UpdateWalkAsync(Walks walkDomain);
    }
}