using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG6221Part2
{
    class Ingredient
    {
        public string Name { get; set; } //Name of the ingredient 
        public double Quantity { get; set; } //Quantity of the ingredient
        public string Unit { get; set; } //Unit of measurement for the ingredient
        public int Calories { get; set; } //Amount of calories
        public string FoodGroup { get; set; } //Type of food group
    }
}
