using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}