using Microsoft.AspNetCore.WebUtilities;
using System.Text.Json;
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
            //TODO: add in error handling for if json is empty or null

            var foodItems = JsonSerializer.Deserialize<NutritionDetailList>(json);

            foreach (var food in foodItems.NutritionList)
            {
                var itemNutrition = new NutritionDetail
                {
                    FoodName = food.FoodName,
                    Calories = food.Calories,
                    ServingInGrams = food.ServingInGrams,
                    TotalCarbsInGrams = food.TotalCarbsInGrams,
                    TotalProteinInGrams = food.TotalProteinInGrams,
                    TotalFatInGrams = food.TotalFatInGrams
                };

                results.Add(itemNutrition);
            }
            //await _data.SaveNutrition(itemNutrition);

            return results;
        }
    }

}
