using FootballWorldServerSide.Interfaces.Repositories;
using FootballWorldServerSide.Interfaces.Services;
using FootballWorldServerSide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballWorldServerSide.Services
{
    public class MatchDetailsService : IMatchDetailsService
    {
        private readonly IMatchDetailsRepository _matchDetailsRepository;
        public MatchDetailsService(IMatchDetailsRepository matchDetails)
        {
            _matchDetailsRepository = matchDetails;
        }

        public async Task<MatchObject> GetAllPLMatchesAsync()
        {
            //Any filtering is applied here
            return await _matchDetailsRepository.GetPLMatchDetails();
        }


    }
}
