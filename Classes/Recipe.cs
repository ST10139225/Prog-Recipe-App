using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_K_Baholo_Part1.Classes
{
    //This is a class for recipes. 
    internal class Recipe
    {
        String Title = "";//To store the name of the recipe.

        String UserInput = ""; //To store user input.

        Steps[] List_of_Steps;         //To store all the steps.

        Ingredients[] List_of_ingredients; //To store all the ingredients.

        public Recipe()
        {
            Console.WriteLine("Please enter a title for the recipe: ");

            UserInput = Console.ReadLine();

           
            


        }


        private void Addsteps()
        {
            int Number_of_steps = 0;
            Console.WriteLine("Please enter the number of steps:");
            UserInput = Console.ReadLine();
            if (UserInput == null && UserInput.Equals("") == true)
            {
                Console.WriteLine("Please enter an integer value for the number of steps.");
                Addsteps();
            }
            try
            {
                 Number_of_steps = int.Parse(UserInput);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter an integer value, e.g. 23 for the number of steps.");
                Addsteps();
            }
            List_of_Steps = new Steps[Number_of_steps];
            for (int index = 0; index <= Number_of_steps; index++)
            {
                Steps step = new Steps(index + 1);
                List_of_Steps[index] = step;    
               
            }
        }

        private void Addingredients()
        {
            int Number_of_ingredients=0;
            Console.WriteLine("Please enter the number of ingredients:");
            UserInput = Console.ReadLine();
            if (UserInput == null && UserInput.Equals("") == true)
            {
                Console.WriteLine("Please enter an integer value for the number of ingredients.");
                Addingredients();
            }
            try
            {
                Number_of_ingredients = int.Parse(UserInput);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please enter an integer value, e.g. 23 for the number of steps.");
                Addingredients();
            }

            List_of_ingredients = new Ingredients[Number_of_ingredients];
            for (int index = 0; index <= Number_of_ingredients; index++)
            { 
                Ingredients ingredient = new Ingredients();
                List_of_ingredients[index]=ingredient;
            }
        }

        public void printRecipe() //This method will display a selected recipe.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0}:", Title);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Ingredients: ");
            Console.ForegroundColor = ConsoleColor.White;

            int counter = 0;
            foreach(Ingredients ingredient in List_of_ingredients)
            {
                counter++;
                Console.WriteLine("{0}.) {1}.", counter, ingredient.PrintIngredient());
            }
         

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Steps: ");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Steps step in List_of_Steps)
            { 
                Console.WriteLine("{0}",step.getStep());
            }
        }

    }
}
