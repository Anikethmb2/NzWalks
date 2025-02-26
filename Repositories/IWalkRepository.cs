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
         Task<List<Walks>> GetAllAsync(string? filterOn=null,string? filterQuery=null,string? sortBy=null,bool isAscending=true,
         int pageNumber=1,int pageSize=1000);

         Task<Walks?> GetWalkByIdAsync(Guid id);

         Task<Walks?> UpdateWalkAsync(Guid id, Walks walk);
       // Task UpdateWalkAsync(Walks walkDomain);


       Task<Walks?> DeleteWalkAsync(Guid id);
    }
}