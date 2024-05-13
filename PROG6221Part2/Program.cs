// See https://aka.ms/new-console-template for more information
using PROG6221Part2;

namespace PROG6221Part2
{
    class Program
    {
        //Main
        static List<Recipe> recipes = new List<Recipe>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\u001b[35m\nYour Very Own Recipe Book:");
                Console.WriteLine("------------------------------");
                Console.WriteLine("1. Enter a new recipe ");
                Console.WriteLine("2. Display all recipes that have been created");
                Console.WriteLine("3. Display a recipe of your choice");
                Console.WriteLine("4. Scale your reccipe");
                Console.WriteLine("5. Clear all recipe");
                Console.WriteLine("6. Close Program");
                Console.WriteLine("------------------------------");

                Console.WriteLine("Enter your choice: ");
                Console.WriteLine("------------------------------");
                int choice = int.Parse(Console.ReadLine());

                // Switch statement to handle different choices made by the user
                switch (choice)
                {
                    case 1:
                        EnterNewRecipe();
                        break;
                    case 2:
                        DisplayAllRecipe();
                        break;
                    case 3:
                        DisplayRecipe();
                        break;
                    case 4:
                        ScaleRecipe();
                        break;
                    case 5:
                        ClearAllRecipe();
                        break;
                    case 6:
                        Environment.Exit(0);   // If the user choose this option the program will close
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please select another number"); // If the choice doesn't match any of the above cases, display an error message
                        break;
                }

            }
        }

        // Method to enter details for a new recipe.
        static void EnterNewRecipe()
        {
            Console.WriteLine("------------------------------");
            Console.Write("Enter recipe name: ");  // Prompt user to enter recipe name
            String name = Console.ReadLine();

            Recipe recipe = new Recipe(name); // Create a new Recipe object with the provided name

            Console.Write("Enter number of ingridents: ");  // Prompt user to enter the number of ingredients
            int ingrdientCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter details for each ingredient: ");  // Prompt user to enter details for each ingredient
            for (int i = 0; i < ingrdientCount; i++)
            {
                Console.Write($"Ingredient {i + 1} - Name: "); // Prompt user to enter details for each ingredient
                string ingrdientName = Console.ReadLine();

                Console.Write($"Quantity: ");
                double quantity = int.Parse(Console.ReadLine());

                Console.Write($"Unit of measurement: ");
                string unit = Console.ReadLine();

                Console.Write($"Calories:");
                int calories = int.Parse(Console.ReadLine());

                Console.Write($"Food Group:");
                string foodGroup = Console.ReadLine();

                recipe.AddIngredient(new Ingredient(ingrdientName, quantity, unit, calories, foodGroup));  // Create a new Ingredient object with the provided details and add it to the recipe
            }

            Console.Write("Enter the number of steps: "); // Prompt user to enter the number of steps
            int stepCount = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter details for each step: "); // Prompt user to enter details for each step
            for (int i = 0; i < stepCount; i++)
            {
                Console.Write($"step {i + 1}:");
                string step = Console.ReadLine();
                recipe.AddStep(step);
            }
            // Add the created recipe to the list of recipes
            recipes.Add(recipe);

            // Calculate the total calories of the recipe
            int totalCalories = recipe.CalculateTotalCalories();

            // Notifies the user if they have exceeded 300 calories
            if (totalCalories > 300)
            {
                NotifyExceedingCalories(recipe.Name);
            }
            // Notify the user that the recipe has been added successfully
            Console.WriteLine("Recipe added successfully");
        }

        // Method to display all available recipes
        static void DisplayAllRecipe()
        {
            // This checks if there are no recipes available
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available."); // If there are no recipes, inform the user
                return;
            }
            // If there are recipes available, display the heading of all the recipes
            Console.WriteLine("\nAll recipes");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name); // Display the name of each recipe
            }
        }

        // Method to display details of a specific recipe
        static void DisplayRecipe()
        {
            // This checks if there are no recipes available
            if (recipes.Count == 0)
            {
                // If there are no recipes, inform the user
                Console.WriteLine("No recipes available.");
                return;
            }
            // Display prompt to select a recipe
            Console.WriteLine("Select a recipe:");

            // Display the list of available recipes with their corresponding numbers
            for (int i = 0; i < recipes.Count; i++) 
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            // Prompt the user to enter the number of the recipe to display
            Console.Write("Enter the number of the recipe to display: ");
            int index = int.Parse(Console.ReadLine()) - 1;
            // This checks if the entered index is valid
            if (index < 0 || index >= recipes.Count)
            {
                Console.WriteLine("Invalid recipe number."); // If the index is not valid, inform the user
                return;
            }
            // Retrieve the selected recipe using the entered index
            Recipe selectedRecipe = recipes[index];
            Console.WriteLine($"\nRecipe: {selectedRecipe.Name}"); // Display the name of the selected recipe
            Console.WriteLine("Ingredients:");

            // Display the list of ingredients for the selected recipe
            foreach (var ingredient in selectedRecipe.Ingredients)
            {
                Console.WriteLine($"- {ingredient}");
            }
            // Display the list of steps for the selected recipe
            Console.WriteLine("\nSteps:");
            for (int i = 0; i < selectedRecipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedRecipe.Steps[i]}");
            }
            // Calculate and display the total calories of the selected recipe
            int totalCalories = selectedRecipe.CalculateTotalCalories();
            Console.WriteLine($"Total calories: {totalCalories}");
        }

        // Method to scale a recipe by a given factor
        static void ScaleRecipe()
        {
            // Check if there are no recipes available
            if (recipes.Count == 0)
            {
                // If there are no recipes, inform the user
                Console.WriteLine("No recipe available");
                return;
            }
            // Display prompt to select a recipe to scale
            Console.WriteLine("Select a recipe to scale:");

            // Display the list of available recipes with their corresponding numbers
            for (int i = 0; i < recipes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipes[i].Name}");
            }
            // Prompt the user to enter the number of the recipe to scale
            Console.Write("Enter the number of the recipe to scale: ");
            int index = int.Parse(Console.ReadLine()) - 1;

            if (index < 0 || index >= recipes.Count)
            {
                Console.WriteLine("Invalid recipe number.");
                return;
            }
            // Prompt the user to enter the scaling factor.
            Console.Write("Enter scaling factor (0,5, or 2, or 3): ");
            double factor = double.Parse(Console.ReadLine());

            Recipe selectedRecipe = recipes[index];
            selectedRecipe.ScaleRecipe(factor);
            Console.WriteLine($"Recipe '{selectedRecipe.Name}' scaled successfully.");
        }

        // Method to notify the user when the total calories for a recipe exceed 300
        static void NotifyExceedingCalories(string recipeName)
        {
            // Display a warning message that the amount of calories has exceeded 300
            Console.WriteLine($"Warning: Total calories for recipe '{recipeName}' exceed 300!");
        }

        // Method to clear all recipes.
        static void ClearAllRecipe()
        {
            // Clear the list of recipes
            recipes.Clear(); 
            Console.WriteLine("All recipes cleared"); // Inform the user that all recipes have been cleared
        }

    }
}