using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NzWalks.Data;
using NzWalks.Models.Domain;

namespace NzWalks.Repositories
{
    public class SqlWalkRepository:IWalkRepository
    {
        //add dbcontext
        private readonly NzWalkDbContext dbContext;
        public SqlWalkRepository(NzWalkDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        public async Task<Walks> CreateAsync(Walks walks)
        {
             await dbContext.WalksSet.AddAsync(walks);
             await dbContext.SaveChangesAsync();

             return walks;

        }

        public async Task<List<Walks>> GetAllAsync()
        {
           return await dbContext.WalksSet.Include("Difficulty").Include("Region").ToListAsync();
        }

        public async Task<Walks?> GetWalkByIdAsync(Guid id)
        {
            return await dbContext.WalksSet.Include("Difficulty").Include("Region").
            FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Walks?> UpdateWalkAsync(Guid id,Walks walk)
        {
            var WalkExist = await dbContext.WalksSet.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.ID == id);

            if (WalkExist == null)
            {
                return null;
            }


            //WalkExist.ID = walk.ID;
            WalkExist.Name = walk.Name;
            WalkExist.Description = walk.Description;
            WalkExist.WalkImgUrl = walk.WalkImgUrl;
            WalkExist.LengthInKm = walk.LengthInKm;
            WalkExist.DifficultyId = walk.DifficultyId;
            WalkExist.RegionId  = walk.RegionId;

            return WalkExist;
        }
    }
}