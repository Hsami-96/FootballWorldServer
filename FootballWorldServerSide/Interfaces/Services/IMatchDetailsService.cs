using FootballWorldServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballWorldServerSide.Interfaces.Services
{
    public interface IMatchDetailsService
    {
        Task<MatchObject> GetAllPLMatchesAsync();
    }
}
