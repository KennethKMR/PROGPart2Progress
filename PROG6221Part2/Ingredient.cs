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

        // Constructor for creating a new Ingredient
        public Ingredient(string name, double quantity, string unit, int calories, string foodgroup)
        {
            Name = name; // Initializes the Name property
            Quantity = quantity; // Initializes the Quantity property
            Unit = unit; // Initializes the Unit property
            Calories = calories; // Initializes the Calories property
            FoodGroup = foodgroup; // Initializes the FoodGroup property

        }
        public override string ToString()
        {
            // Constructs a string with the quantity, unit, name, and calories of the ingredient.
            return $"{Quantity} {Unit} of {Name} ({Calories} calories)";
        }
    }
}
