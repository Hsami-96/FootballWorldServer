using FootballWorldServerSide.Interfaces.Repositories;
using FootballWorldServerSide.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FootballWorldServerSide.Repositories
{
    public class MatchDetailsRepository : IMatchDetailsRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        public MatchDetailsRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<MatchObject> GetPLMatchDetails()
        {
            var client = _clientFactory.CreateClient("API Client");
            var result = await client.GetAsync("/v2/competitions/PL/matches");

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<MatchObject>(content);
            }
            return null;
        }
    }
}
