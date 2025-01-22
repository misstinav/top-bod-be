using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Web;
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

            Dictionary<string, string?> queryString = new Dictionary<string, string?> { { "query", query } };
            var uri = QueryHelpers.AddQueryString(Credentials.BaseUrl, queryString);
            _client.DefaultRequestHeaders.Add("X-Api-Key", Credentials.ApiKey);
            
            var response = await _client.GetAsync(uri);

            if (!response.IsSuccessStatusCode)
            {
                Console.Write(response.StatusCode.ToString());
                return [];
            }

            var itemNutrition = await response.Content.ReadFromJsonAsync<NutritionDetail>();

            return resultedNutrition;
        }

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
