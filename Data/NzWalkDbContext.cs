using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NzWalks.Models.Domain;

namespace NzWalks.Data
{
    public class NzWalkDbContext : DbContext
    {
        public NzWalkDbContext(DbContextOptions<NzWalkDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Difficulty> DifficultySet { get; set; }

        public DbSet<Region> RegionsSet { get; set; }

        public DbSet<Walks> WalksSet { get; set; }
        
       
    }
}