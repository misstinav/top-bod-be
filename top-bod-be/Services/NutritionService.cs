using Microsoft.AspNetCore.WebUtilities;
using top_bod_be.Models;

namespace top_bod_be.Services
{
    public class NutritionService : INutritionService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;

        public NutritionService(IConfiguration config, HttpClient client)
        {
            _config = config;
            _client = client;
        }
        public async Task<List<NutritionDetail>> SearchReturnsNutritionDetails(string query)
        {
            var resultedNutrition = new List<NutritionDetail>();
            //TODO: make a call to the db to see if the data is there first, if not call the third party api

            //TODO: figure out how to encode url, also need to plug in api key
            Dictionary<string, string?> queryString = new Dictionary<string, string?> { { "query", query } };
            var uri = QueryHelpers.AddQueryString("api URL", queryString);
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                Console.Write(response.StatusCode.ToString());
                return [];
            }

            //TODO: do I want to return every item nutrition details or just the first one?
            //how is it all going to be handled?
            var itemNutrition = await response.Content.ReadFromJsonAsync<NutritionDetail>();

            return resultedNutrition;
        }
    }
}
