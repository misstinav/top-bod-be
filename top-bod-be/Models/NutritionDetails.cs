namespace top_bod_be.Models
{
    public class NutritionDetails
    {
        public int Id { get; set; }
        public string FoodName { get; set; }
        public decimal Calories { get; set; }
        public decimal ServingInGrams { get; set; }
        public decimal TotalFatInGrams { get; set; }
        public decimal TotalProteinInGrams { get; set; }
        public decimal TotalCarbsInGrams { get; set; }
    }
}
