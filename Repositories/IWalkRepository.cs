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
    }
}