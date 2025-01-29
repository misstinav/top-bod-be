using System.Text.Json.Serialization;

namespace top_bod_be.Models
{
    public class NutritionDetail
    {
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string FoodName { get; set; }
        [JsonPropertyName("calories")]
        public decimal Calories { get; set; }
        [JsonPropertyName("serving_size_g")]
        public decimal ServingInGrams { get; set; }
        [JsonPropertyName("fat_total_g")]
        public decimal TotalFatInGrams { get; set; }
        [JsonPropertyName("protein_g")]
        public decimal TotalProteinInGrams { get; set; }
        [JsonPropertyName("carbohydrates_total_g")]
        public decimal TotalCarbsInGrams { get; set; }
    }

    public class NutritionDetailList
    {
        [JsonPropertyName("items")]
        public List<NutritionDetail> NutritionList { get; set; } 
    }
}
