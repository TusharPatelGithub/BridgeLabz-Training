using System;
class MealPlanGenerator
{
    interface IMealPlan
    {
        string GetMealType();
        void ShowMealDetails();
    }
    class VegetarianMeal : IMealPlan
    {
        public string GetMealType()
        {
            return "Vegetarian";
        }
        public void ShowMealDetails()
        {
            Console.WriteLine("Includes vegetables, fruits, grains, dairy.");
        }
    }
    class VeganMeal : IMealPlan
    {
        public string GetMealType()
        {
            return "Vegan";
        }
        public void ShowMealDetails()
        {
            Console.WriteLine("Plant-based meals with no animal products.");
        }
    }
    class KetoMeal : IMealPlan
    {
        public string GetMealType()
        {
            return "Keto";
        }
        public void ShowMealDetails()
        {
            Console.WriteLine("Low-carb, high-fat diet.");
        }
    }
    class HighProteinMeal : IMealPlan
    {
        public string GetMealType()
        {
            return "High Protein";
        }
        public void ShowMealDetails()
        {
            Console.WriteLine("Protein-rich meals for muscle growth.");
        }
    }
    class Meal<T> where T : IMealPlan
    {
        private T mealPlan;
        public Meal(T mealPlan)
        {
            this.mealPlan = mealPlan;
        }
        public void DisplayMeal()
        {
            Console.WriteLine($"Meal Type: {mealPlan.GetMealType()}");
            mealPlan.ShowMealDetails();
        }
    }
    static void GenerateMealPlan<T>(T meal) where T : IMealPlan
    {
        Console.WriteLine("\n--- Generating Meal Plan ---");
        Console.WriteLine($"Selected Meal: {meal.GetMealType()}");
        meal.ShowMealDetails();
    }
    public static void Main(string[] args)
    {
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\n=== Personalized Meal Plan Generator ===");
            Console.WriteLine("1. Vegetarian Meal");
            Console.WriteLine("2. Vegan Meal");
            Console.WriteLine("3. Keto Meal");
            Console.WriteLine("4. High Protein Meal");
            Console.WriteLine("5. Exit");
            Console.Write("Choose your meal plan: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    VegetarianMeal veg = new VegetarianMeal();
                    Meal<VegetarianMeal> vegMeal = new Meal<VegetarianMeal>(veg);
                    vegMeal.DisplayMeal();
                    GenerateMealPlan(veg);
                    break;
                case 2:
                    VeganMeal vegan = new VeganMeal();
                    Meal<VeganMeal> veganMeal = new Meal<VeganMeal>(vegan);
                    veganMeal.DisplayMeal();
                    GenerateMealPlan(vegan);
                    break;
                case 3:
                    KetoMeal keto = new KetoMeal();
                    Meal<KetoMeal> ketoMeal = new Meal<KetoMeal>(keto);
                    ketoMeal.DisplayMeal();
                    GenerateMealPlan(keto);
                    break;
                case 4:
                    HighProteinMeal hp = new HighProteinMeal();
                    Meal<HighProteinMeal> hpMeal = new Meal<HighProteinMeal>(hp);
                    hpMeal.DisplayMeal();
                    GenerateMealPlan(hp);
                    break;
                case 5:
                    exit = true;
                    Console.WriteLine("Exiting Meal Plan Generator...");
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
