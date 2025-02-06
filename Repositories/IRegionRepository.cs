using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NzWalks.Models.Domain;

namespace NzWalks.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetRegiobByIdAsync(string code);

        Task<Region?> CreateAsync(Region region);

        Task<Region?> UpdateAsync(Guid id, Region region);

        Task<Region?> DeleteAsync(Guid id);
    }
}