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

        public async Task<Walks?> DeleteWalkAsync(Guid id)
        {
           var walkExists = await dbContext.WalksSet.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x => x.ID == id);

           if (walkExists == null)
           {
             return null;
           }

             dbContext.WalksSet.Remove(walkExists);
             await dbContext.SaveChangesAsync();

             return walkExists;


        }

        public async Task<List<Walks>> GetAllAsync(string? filterOn=null,string? filterQuery=null,string? sortBy=null,
        bool isAscending=true,int pageNumber=1,int pageSize=1000)
        {
            var walks = dbContext.WalksSet.Include("Difficulty").Include("Region").AsQueryable();
            //filtering
            if(string.IsNullOrWhiteSpace(filterOn)==false&& string.IsNullOrWhiteSpace(filterQuery) ==false)
            {
                if(filterOn.Contains("name", StringComparison.OrdinalIgnoreCase))
                walks = walks.Where(x => x.Name.Contains(filterQuery));
            }

            if(string.IsNullOrWhiteSpace(sortBy)==false)
            {
                if(sortBy.Contains("name",StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x=>x.Name): walks.OrderByDescending(x=>x.Name);
                }
                else if(sortBy.Contains("length",StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x=>x.LengthInKm): walks.OrderByDescending(x=>x.LengthInKm);
                }  
            }

            //Pagination

            var skipResult = (pageNumber-1)*pageSize;

            return await walks.Skip(skipResult).Take(pageSize).ToListAsync();

           //return await dbContext.WalksSet.Include("Difficulty").Include("Region").ToListAsync();
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

            await dbContext.SaveChangesAsync();

            return WalkExist;
        }
    }
}