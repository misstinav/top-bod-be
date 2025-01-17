using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using top_bod_be.Models;
using top_bod_be.Services;

namespace top_bod_be.Controllers
{
    public class NutritionGet : EndpointBaseAsync
        .WithRequest<string>
        .WithResult<List<NutritionDetails>>
    {
        private readonly INutritionService _nutritionService;

        public NutritionGet(INutritionService nutritionService)
        { 
            _nutritionService = nutritionService;
        }

        [HttpGet("api/nutrition")]
        public override Task<List<NutritionDetails>> HandleAsync(
            [FromQuery(Name ="query")] string request, 
            CancellationToken cancellationToken = default)
        {
            if (request == null || request == string.Empty)
            {
                throw new ArgumentNullException(nameof(request));
            }

            //TODO: need to add error handling service
            var queryNutrition = _nutritionService.SearchReturnsNutritionDetails(request);

            return queryNutrition;
        }
    }
}
