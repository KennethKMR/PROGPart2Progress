// See https://aka.ms/new-console-template for more information
using PROG6221Part2;

namespace PROG6221Part2
{
    class Program
    {
        //Main
        static void Main(string[] args)
        {
            //Infinite loop that will continously add recipes
            while (true)
            {
                //Create a new recipe object
                Recipe recipe = new Recipe();

                //Prompt the user to enter the name of the recipe
                Console.WriteLine("Enter the name of the recipe: ");
                recipe.Name = Console.ReadLine();

                //Prompt the user to enter the number of ingredients

                Console.WriteLine("Enter the number of ingredients: ");
                int numIngredients;

                //A loop that will continously ask the user to enter the correct value
                while (!int.TryParse(Console.ReadLine(), out numIngredients) || numIngredients <= 0)
                {
                    Console.WriteLine("Try that again, make sure you are entering a positive number for the number of ingredients: ");
                }
                recipe.Ingredients = new Ingredient[numIngredients]; //Initialize ingredients array with specified size
                recipe.OriginalQuantities = new double[numIngredients]; //Initialize ingredients array with specified size

                //Loop to input details for each ingredient
                for (int i = 0; i < numIngredients; i++)
                {
                    Ingredient ingredient = new Ingredient(); //Create a new ingredient object

                    //Prompt the user to enter the name of the ingredient
                    Console.WriteLine($"Enter the name of ingredient {i + 1}:");
                    ingredient.Name = Console.ReadLine();

                    //Loop put in place to ensure valid input for quantity
                    double quantity;
                    string quantityInput;
                    do
                    {
                        //Promp the user to enter the quantity of the ingredient
                        Console.WriteLine($"Enter the quantity of {ingredient.Name}:");
                        quantityInput = Console.ReadLine();
                    } while (!double.TryParse(quantityInput, out quantity) || quantity <= 0);

                    ingredient.Quantity = quantity; //Set quantity of the ingredient
                    recipe.OriginalQuantities[i] = quantity; //Store original quantity

                    //Prompt user to enter the unit of measurement
                    Console.WriteLine($"Enter the unit of measurement for {ingredient.Name}:");
                    ingredient.Unit = Console.ReadLine();

                    recipe.Ingredients[i] = ingredient;
                }
                //Prompt the user to enter the number of steps
                Console.WriteLine("Enter the number of steps:");
                int numSteps;
                while (!int.TryParse(Console.ReadLine(), out numSteps) || numSteps <= 0)
                {
                    Console.WriteLine("Try that again, make sure you are entering a positive number for the number of steps");
                }
                recipe.Steps = new string[numSteps]; //Initialize Steps array with specified size

                //Loop to input details for each step
                for (int i = 0; i < numSteps; i++)
                {
                    Console.WriteLine($"Enter step {i + 1}:");
                    recipe.Steps[i] = Console.ReadLine();
                }
                //Display the recipe details
                Console.WriteLine("\nRecipe details:");
                Console.WriteLine($"Name: {recipe.Name}");

                Console.WriteLine("\nIngredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                }

                Console.WriteLine("\nSteps");
                for (int i = 0; i < recipe.Steps.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
                }
                //The following will be for the feature that allows the recipe to scale
                Console.WriteLine("\nWould you like to scale the recipe? (Enter '0,5' to cut quantity in half, '2' to double quantity, '3' to triple quantity, or just press enter if you wish not to scale the recipe.)");
                string scaleOption = Console.ReadLine();
                //If statement that scales the recipe according to the users input
                if (scaleOption == "0.5" || scaleOption == "2" || scaleOption == "3")
                {
                    double scaleFactor;
                    while (!double.TryParse(Console.ReadLine(), out scaleFactor))
                    {
                        Console.WriteLine("Try that again, please enter a valid number in order to scale the recipe: ");
                        scaleOption = Console.ReadLine();
                    }
                    //This takes the scaled recipe and displays it back to the user
                    ScaleRecipe(recipe, scaleFactor);

                    Console.WriteLine("\nScaled Recipe details:");
                    Console.WriteLine($"Name: {recipe.Name}");

                    Console.WriteLine("\nIngredients:");
                    //This gives the user the option to reset the quantities in their recipe
                    foreach (var ingredient in recipe.Ingredients)
                    {
                        Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
                    }
                    Console.WriteLine("\nWould you like to reset the quantities to their original values? (Y/N)");
                    string resetOption = Console.ReadLine().ToUpper();
                    //This will prompt the user to either reset the recipe or not
                    if (resetOption == "Y")
                    {
                        ResetQuantities(recipe); //This resets the quantities to the original values
                        Console.WriteLine("\nQuantities have been reset to their original values.");
                    }
                }
                else
                {
                    Console.WriteLine("No scaling has been added to the recipe.");
                }
                //Ask the user if they would like to clear the recipe and start a new one
                Console.WriteLine("\nWould you like to clear all your data and start a new recipe? (Y/N)");
                string clearOption = Console.ReadLine().ToUpper();
                if (clearOption != "Y")
                {
                    Console.WriteLine("I hope you enjoy your very own personal recipe.");
                    break; //This will exit the loop if the user chooses not to reset the recipe.
                }
            }
        }
        //Method used to scale the recipe
        static void ScaleRecipe(Recipe recipe, double scaleFactor)
        {
            foreach (var ingredient in recipe.Ingredients)
            {
                ingredient.Quantity = scaleFactor;
            }
        }
        //Method used to Reset the ingredient quantities
        static void ResetQuantities(Recipe recipe)
        {
            for (int i = 0; i < recipe.Ingredients.Length; i++)
            {
                recipe.Ingredients[i].Quantity = recipe.OriginalQuantities[i];
            }
        }
    }
}
