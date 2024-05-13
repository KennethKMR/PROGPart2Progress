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

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();

        }
    }
}
