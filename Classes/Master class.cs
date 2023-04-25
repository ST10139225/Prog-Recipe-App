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

            userinput= Console.ReadLine();
            if (string.IsNullOrEmpty(userinput))
            {
                red_warningMessage("Please the number, e.g. 12, of the recipes you want. ");
                start();
            }
            try
            {
                number_of_recipes= int.Parse(userinput);    
            }catch(FormatException e)
            {
                red_warningMessage("Please the number, e.g. 12, of the recipes you want. ");
                start();

            }

           recipes= new Recipe[number_of_recipes];  

        }

        public void red_warningMessage(string message) //This method is to display warning messages in red.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;


        }


    }
}
