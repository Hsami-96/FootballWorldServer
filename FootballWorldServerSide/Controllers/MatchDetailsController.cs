using FootballWorldServerSide.Interfaces.Services;
using FootballWorldServerSide.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballWorldServerSide.Controllers
{
    [ApiController]
    public class MatchDetailsController : Controller
    {
        private readonly IMatchDetailsService _matchDetailsService;
        public MatchDetailsController(IMatchDetailsService matchDetailsService)
        {
            _matchDetailsService = matchDetailsService;
        }

        [HttpGet]
        [Route("api/GetPlMatches")]
        public async Task<List<MatchDetails>> GetPLMatches()
        {
            List<MatchDetails> matchDetails = new List<MatchDetails>();
            var matches = await _matchDetailsService.GetAllPLMatchesAsync();
            foreach (var item in matches.matches)
            {
                matchDetails.Add(item);
            }
            return matchDetails;
             
        }
    }

}
