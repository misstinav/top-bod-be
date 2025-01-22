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
            var results = new List<NutritionDetail>();
            var localDbResult = await _data.GetNutritionByName(query);
            if (localDbResult != null && localDbResult.Count > 0) 
            { 
                return localDbResult;
            }

            Dictionary<string, string?> queryString = new Dictionary<string, string?> { { "query", query } };
            var uri = QueryHelpers.AddQueryString(Credentials.BaseUrl, queryString);
            _client.DefaultRequestHeaders.Add("X-Api-Key", Credentials.ApiKey);
            
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                Console.Write(response.StatusCode.ToString());
                return [];
            }

            var json = await response.Content.ReadAsStringAsync();

            //TODO: convert the json and pull the data within the 'items' kv pair
            //var items = JsonSerializer.Serialize(json);
            //var foodItem = JsonSerializer.Deserialize<NutritionDetail>(stringContent);

            var itemNutrition = new NutritionDetail
            {
                FoodName = foodItem.FoodName,
                Calories = foodItem.Calories,
                ServingInGrams = foodItem.ServingInGrams,
                TotalCarbsInGrams = foodItem.TotalCarbsInGrams,
                TotalProteinInGrams = foodItem.TotalProteinInGrams,
                TotalFatInGrams = foodItem.TotalFatInGrams
            };
            
            //await _data.SaveNutrition(itemNutrition);
            results.Add(itemNutrition);

            return results;
        }
    }

}
