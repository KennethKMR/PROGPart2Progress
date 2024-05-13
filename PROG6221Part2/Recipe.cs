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
        public string Name { get; set; } //Name of the recipe
        public Ingredient[] Ingredients { get; set; } //Array of Ingredients
        public string[] Steps { get; set; } //Array of Steps for the ingredients
        public double[] OriginalQuantities { get; set; } //Array to store original quantities of ingredients

        public Recipe()
        {
            Ingredients = new Ingredient[0]; //This initializes the Ingredients array with the size of zero
            Steps = new string[0]; //This initializes the Steps array with the size of zero
        }
    }
}
