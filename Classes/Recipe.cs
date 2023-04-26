﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace ST10139225_K_Baholo_Part1.Classes
{
    //This is a class for recipes. 
    internal class Recipe
    {
      public String Title = "";//To store the name of the recipe.

        String UserInput = ""; //To store user input.

        public Steps[] List_of_Steps;         //To store all the steps.

        public Ingredients[] List_of_ingredients; //To store all the ingredients.

        float scale = 0; //This variable stores the factor of scale.
        String scaleType = ""; //To store which type of scaling was choosen, whether it was an up scale or down scale.



        public Recipe()
        {
            setTitle();

            Addingredients();

            Addsteps();

            printRecipe(); 
            


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
            try
            {
                 Number_of_steps = int.Parse(UserInput);
            }
            catch (FormatException )
            {
                red_warningMessage("Please enter an integer value, e.g. 23 for the number of steps.");
                Addsteps();
            }

            List_of_Steps = new Steps[Number_of_steps];

            for (int index = 0; index < Number_of_steps; index++)
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
            try
            {
                Number_of_ingredients = int.Parse(UserInput);
            }
            catch (FormatException )
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
            Console.WriteLine("\nIngredients: ");
            Console.ForegroundColor = ConsoleColor.White;

            string line = String.Format("{0,-15} {1,-15} {2,13}", "Ingredient ", "Quantity", "Unit of Measurement");
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

       

        public void scale_recipe() ///This method is responsible for scaling the recipe.
        {
            Console.WriteLine("\n\nDo you wish to scale the recipe? \nType in yes or no");
            UserInput = Console.ReadLine();

            if (UserInput.Equals("yes"))
            {
                
                scale = getScale_value();
                selectTypeofScale();     
            }
            else if (UserInput.Equals("no"))
            {
                Console.WriteLine("Final stage...");

            }
            else if (UserInput.Equals("yes") == false && UserInput.Equals("no") == false)
            {
                red_warningMessage("Please enter an yes or no. ");
                scale_recipe();
            }
        }

        private float getScale_value() //This method is responsible for getting the value, 0.5, 1, 2 or 3 for scaling the recipe 
        {
            float value =0f;

            Console.WriteLine("Enter the factor of scale to apply, e.g. 0.5");
                UserInput = Console.ReadLine();
                try
                {
                    value = float.Parse(UserInput);
                }
                catch (FormatException )
                {
                    red_warningMessage("Please enter a value, e.g. 2.5 or 0.5 ");
                    getScale_value();
                }
                return value; 
        }

        private void selectTypeofScale() //This method is to select whether the recipe should be scaled up or down.
        {
            Console.WriteLine("Do you wish to scale up or scale down the recipe? \n\nType in u for up or d for down");
            UserInput = Console.ReadLine();

            //This section of the method takes in the decision to scale up or down.
            if (UserInput.Equals("u"))
            {
                scale_up_ingredients(scale); 
            }
            else if (UserInput.Equals("d"))
            {
                scale_down_ingredients(scale); 
            }
            else
            {
                red_warningMessage("Type in u for up or d for down");
                selectTypeofScale();
            }

        }

        public void scale_up_ingredients(float scale)
        {
            scaleType = "u";

            for (int i = 0; i < List_of_ingredients.Length; i++)
            {
                List_of_ingredients[i].scale_up_ingredient(scale);
            }
        }public void scale_down_ingredients(float scale)
        {
            scaleType = "d";

            for (int i = 0; i < List_of_ingredients.Length; i++)
            {
                List_of_ingredients[i].scale_down_ingredient(scale);
            }
        }

       public void resetQuantities()
        {
            Console.WriteLine("\n\nDo you wish to return to the original scale of the {0} recipe", Title);
            red_warningMessage("Type in yes the original values, or anything else to progress. ");

            UserInput = Console.ReadLine();

            //This section of the method takes in the decision to scale up or down.
            if (UserInput.Equals("yes"))
            {
                if (scaleType.Equals("u"))
                {
                    for (int i = 0; i < List_of_ingredients.Length; i++)
                    {
                        List_of_ingredients[i].reset_quantity_after_down_scale(scale);
                    }
                }else if (scaleType.Equals("d"))
                {
                    for (int i = 0; i < List_of_ingredients.Length; i++)
                    {
                        List_of_ingredients[i].reset_quantity_after_up_scale(scale);
                    }
                }
                Console.WriteLine("This is the recipe with original quantities.");
            }
            
        }

         public void red_warningMessage(string message) //This method is to display warning messages in red.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;


        }


    }
}
