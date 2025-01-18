using top_bod_be.Models;

namespace top_bod_be.Services
{
    public interface INutritionService
    {
        Task<List<NutritionDetail>> SearchReturnsNutritionDetails(string query);
    }
}
