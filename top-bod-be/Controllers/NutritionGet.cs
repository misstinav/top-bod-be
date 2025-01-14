using Microsoft.AspNetCore.Mvc;
//using top_bod_be.Models;

namespace top_bod_be.Controllers
{
    [ApiController]
    //TODO: should I update the route? Do I need to?
    [Route("api/[controller]")]
    public class NutritionGet : ControllerBase
    {
        private readonly IHttpClientFactory _httpFactory;

        public NutritionGet(IHttpClientFactory httpFactory)
        {
            _httpFactory = httpFactory;
        }

        //[HttpGet]
        //public async Task<List<NutritionDetails>> GetNutritionDetails(string query)
        //{
        //    var client = _httpFactory.CreateClient();
        //    //TODO: build URL
        //    var response = await client.GetAsync(query);
        //}
    }
}
