using top_bod_be.Models;

namespace top_bod_be.Data
{
    public interface IDataRepo
    {
        Task<List<NutritionDetail>> GetNutritionByName(string query);
    }
}
