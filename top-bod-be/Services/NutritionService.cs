using Microsoft.AspNetCore.WebUtilities;
using top_bod_be.Data;
using top_bod_be.Models;

namespace top_bod_be.Services
{
    public class NutritionService : INutritionService
    {
        private readonly IConfiguration _config;
        private readonly HttpClient _client;
        private readonly IDataRepo _data;

        public NutritionService(IConfiguration config, HttpClient client, IDataRepo data)
        {
            _config = config;
            _client = client;
            _data = data;
        }
        public async Task<List<NutritionDetail>> SearchReturnsNutritionDetails(string query)
        {
            var resultedNutrition = new List<NutritionDetail>();
            var localDbResult = await _data.GetNutritionByName(query);
            if (localDbResult != null && localDbResult.Count > 0) 
            { 
                return localDbResult;
            }
            //TODO: figure out how to encode url, also need to plug in api key
            Dictionary<string, string?> queryString = new Dictionary<string, string?> { { "query", query } };
            var uri = QueryHelpers.AddQueryString("api URL", queryString);
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                Console.Write(response.StatusCode.ToString());
                return [];
            }

            var itemNutrition = await response.Content.ReadFromJsonAsync<NutritionDetail>();

            return resultedNutrition;
        }
    }
}
