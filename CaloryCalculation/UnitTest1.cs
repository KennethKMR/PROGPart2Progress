namespace CaloryCalculation
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class RecipeTests
    {
        // Define a test case with some sample ingredients
        [Test]
        public void CalculateTotalCalories_Returns_CorrectTotal()
        {
            // Arrange
            var ingredients = new List<Ingredient>
        {
            new Ingredient { Name = "Flour", Calories = 100 },
            new Ingredient { Name = "Sugar", Calories = 50 },
            new Ingredient { Name = "Butter", Calories = 200 }
        };
            var recipe = new Recipe { Ingredients = ingredients };

            
            int totalCalories = recipe.CalculateTotalCalories();

            
            Assert.AreEqual(350, totalCalories); 
        }
    }

    // Define the Ingredient class
    public class Ingredient
    {
        public string Name { get; set; }
        public int Calories { get; set; }
    }

    // Define the Recipe class
    public class Recipe
    {
        public List<Ingredient> Ingredients { get; set; }

        public int CalculateTotalCalories()
        {
            int totalCalories = Ingredients.Sum(ingredient => ingredient.Calories);
            return totalCalories;
        }
    }
}