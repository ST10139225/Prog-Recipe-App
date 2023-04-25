using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_K_Baholo_Part1.Classes
{
    internal class Master_class //This class will act as the access point to create, edit, and delete and store recipes.
    {
        Recipe[] recipes;

        public Master_class()
        {
            start();


        }

        public void start()
        {
            Console.WriteLine("Pleases enter the number of recipes you would like to enter");
            string userinput = "";
            int number_of_recipes = 0;


            if (string.IsNullOrEmpty(userinput))
            {
                red_warningMessage("Please the number, e.g. 12, of the recipes you want. ");
            }
            try
            {
                number_of_recipes= int.Parse(userinput);    
            }catch(FormatException e)
            {
                red_warningMessage("Please the number, e.g. 12, of the recipes you want. ");

            }

            for (int i = 0; i < number_of_recipes; i++)
            {
                Recipe recipe = new Recipe();
                recipes[i] = recipe;
            }

            foreach (Recipe recipe in recipes)
            {
                recipe.printRecipe();
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
