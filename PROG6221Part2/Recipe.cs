using PROG6221Part2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221Part2
{
    class Recipe
    {
        public string Name { get; set; } //Name of recipe
        public List<Ingredient> Ingredients { get; set; } //List of ingredients
        public List<string> Steps { get; set; } //List of steps 
        public double[] OriginalQuantities { get; set; } //Array to store original quantities of ingredients

        // Constructor for creating a new Recipe
        public Recipe(string name)
        {
            Name = name;  // Initializes the Name property
            Ingredients = new List<Ingredient>(); // Initializes the Ingredients list
            Steps = new List<string>(); // Initializes the Steps list

        }
        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient); // Adds the given ingredient to the list of ingredients
        }

        public void AddStep(string step)
        {
            Steps.Add(step); // Adds the given step to the list of steps
        }

        public int CalculateTotalCalories()
        {
            int totalCalories = Ingredients.Sum(ingredient => ingredient.Calories); // Calculates the total calories of the recipe
            return totalCalories;
        }

        public void ScaleRecipe(double factor)
        {
            foreach (var ingredient in Ingredients) // Scales the quantities of all ingredients in the recipe
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ClearRecipe()
        {
            Ingredients.Clear(); // Clears both the list of ingredients and the list of steps, basically it ends up clearing the entire recipe
            Steps.Clear();
        }


    }
}
   
