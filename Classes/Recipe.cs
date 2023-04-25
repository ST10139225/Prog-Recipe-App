using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
            setTitle();

            Addingredients();

            Addsteps(); 

           
            


        }

        private void setTitle() //This is a setter method for the title of a recipe.
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Please enter a title for the recipe: ");
            UserInput = Console.ReadLine();

            if (UserInput != null && UserInput.Equals("") != true)
            {
                this.Title = UserInput;

            }
            else
            { 
            red_warningMessage("Please enter a title for the recipe.\n For example: cheesecake \n");
            setTitle();
        }

        }

        private void Addsteps()
        {
            int Number_of_steps = 0;
            Console.WriteLine("Please enter the number of steps:");
            UserInput = Console.ReadLine();
            if (UserInput == null && UserInput.Equals("") == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                red_warningMessage("Please enter an integer value for the number of steps.");
                Addsteps();
            }
            try
            {
                 Number_of_steps = int.Parse(UserInput);
            }
            catch (FormatException e)
            {
                red_warningMessage("Please enter an integer value, e.g. 23 for the number of steps.");
                Addsteps();
            }
            List_of_Steps = new Steps[Number_of_steps];
            for (int index = 0; index <
                Number_of_steps; index++)
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
                red_warningMessage("Please enter an integer value for the number of ingredients.");
                Addingredients();
            }
            try
            {
                Number_of_ingredients = int.Parse(UserInput);
            }
            catch (FormatException e)
            {
                red_warningMessage("Please enter an integer value, e.g. 23 for the number of steps.");
                Addingredients();
            }

            List_of_ingredients = new Ingredients[Number_of_ingredients];
            for (int index = 0; index < Number_of_ingredients; index++)
            { 
                Ingredients ingredient = new Ingredients();
                List_of_ingredients[index]=ingredient;
            }
        }

        public void printRecipe() //This method will display a selected recipe.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n \n{0}:", Title);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n Ingredients: ");
            Console.ForegroundColor = ConsoleColor.White;

            string line = String.Format("{0,-15} {1,-15} {2,13}", "Ingredient ", "Quanity", "Unit of Measurement");
            Console.WriteLine(line);

            foreach (Ingredients ingredient in List_of_ingredients)
            {
               
                 ingredient.PrintIngredient();
            }
         

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n \nSteps: ");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Steps step in List_of_Steps)
            { 
                Console.WriteLine("{0}",step.getStep());
            }
        }

        public void red_warningMessage(string message) //This method is to display warning messages in red.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;


        }

        public void scale_recipe()
        {
            float scale = 0; //This variable stores the factor of scale

            Console.WriteLine("Do you wish to scale the recipe? \n\nType in yes or no");
            UserInput = Console.ReadLine();

            if (UserInput == null && UserInput.Equals("") == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                red_warningMessage("Please enter an yes or no. ");
                scale_recipe();
            }
            if (UserInput.Equals("yes"))
            {
                Console.WriteLine("Enter the factor of scale to apply, e.g. 0.5");
                UserInput = Console.ReadLine();
            }

            else
                clearData();
            if (UserInput == null && UserInput.Equals("") == true)
            {
                red_warningMessage("Please enter a value ");
                scale_recipe();
            }
            try
            {
                scale = float.Parse(UserInput);
            }catch(FormatException e)
            {
                red_warningMessage("Please enter a value 2.5, 0.5 ");
                scale_recipe();
            }

            Console.WriteLine("Do you wish to scale up or scale down the recipe? \n\nType in u for up or d for down");
            UserInput = Console.ReadLine();

            if (UserInput == null && UserInput.Equals("") == true)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                red_warningMessage("Type in u for up or d for down");
                UserInput = Console.ReadLine();

            }
            if (UserInput.Equals("u"))
            {
               for(int i =0; i<List_of_ingredients.Length; i++)
                {
                    List_of_ingredients[i].scale_up_ingredient(scale);
                } 
               
            }




        }

        public void clearData()
        {
            Console.WriteLine("Clearing data...");

        }


    }
}
