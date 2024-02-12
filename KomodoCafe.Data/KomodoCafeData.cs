namespace KomodoCafe.Data;
    public class KomodoCafeData
    {
            public KomodoCafeData(){}
            public KomodoCafeData (int mealId, string mealName, string mealDescription, string ingredientsList, double mealPrice)
            {
                MealId = mealId; 
                MealName = mealName;
                MealDescription = mealDescription;
                IngredientsList = ingredientsList;
                MealPrice = mealPrice;
            }
    

        public int MealId { get; set; }

        public string MealName { get; set; }

        public string MealDescription { get; set; }

        public string IngredientsList { get; set; }

        public double MealPrice { get; set; }
    }