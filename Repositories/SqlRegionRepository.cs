using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NzWalks.Data;
using NzWalks.Models.Domain;
using NzWalks.Repositories;

namespace NzWalks.Repositories
{
    public class SqlRegionRepository : IRegionRepository
    {   
        private readonly NzWalkDbContext _dbContext;
        public SqlRegionRepository(NzWalkDbContext dbContext )
        {
            this._dbContext = dbContext;
        }

        public async Task<Region?> CreateAsync(Region region)
        {
            await _dbContext.RegionsSet.AddAsync( region );
            await _dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
           var region = await _dbContext.RegionsSet.FindAsync( id );
           if (region == null)
           {
                return null;
           }

           _dbContext.Remove(region);
           _dbContext.SaveChanges();

           return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _dbContext.RegionsSet.ToListAsync();
        }

        public async Task<Region?> GetRegiobByIdAsync(string code)
        {
            return await _dbContext.RegionsSet.FirstOrDefaultAsync(x => x.Code == code);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var regionId = await _dbContext.RegionsSet.FirstOrDefaultAsync(x => x.ID == id);

            if (regionId == null)
            {
                return null;
            }

            regionId.Name = region.Name;
            regionId.Code = region.Code;    
            regionId.RegionImgUrl = region.RegionImgUrl;

            _dbContext.SaveChanges();

            return regionId;


        }
    }
}