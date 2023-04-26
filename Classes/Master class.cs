using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ST10139225_K_Baholo_Part1.Classes
{
    internal class Master_class //This class will act as the access point to create, edit, and delete and store recipes.
    {
        string userinput = "";
        int number_of_recipes = 0;

        Recipe[] recipes;


        public Master_class()
        {
            start();
            DeleteData();
            restart_App();
        }

        public void start()// This method starts the application.
        {
            Console.WriteLine("Pleases enter the number of recipes you would like to enter");
            userinput= Console.ReadLine();
            try
            {  
                number_of_recipes= int.Parse(userinput);
                if(number_of_recipes<1){
                red_warningMessage("Please a number greater than 0");
                start();
                }
                populateArray(number_of_recipes);
                
            }
            catch(FormatException )
            {
                red_warningMessage("Please the number, e.g. 12, of the recipes you want. ");
                start();

            }

           

        }

        public Recipe getRecipe(int index)// This method gets a recipe from the array.
        {
            return recipes[index];
        }

        public void selectARecipe(){
            
        }

        public void populateArray(int number)// This method adds populates the recipes array.
        {
            recipes = new Recipe[number];
            for (int i = 0; i < number; i++)
            {
                recipes[i] = new Recipe();
            }
        }





        public void DeleteData()
        {
           
            Console.WriteLine("Do you want to delete all data? \nEnter yes to proceed:");
            userinput = Console.ReadLine();
            if (string.IsNullOrEmpty(userinput)||userinput.Equals("yes")==false)
            {
                red_warningMessage("Please the either yes");
                DeleteData(); 
            }
            

            for(int i =0; i<number_of_recipes;i++) {
                recipes[i] = null;

            }

            red_warningMessage("\n\nThere are no recipes to display.");
           
        }

        public void restart_App()
        {
            Console.WriteLine(" \nEnter 'new' to enter a recipe, anything else will exit the program.");
            userinput = Console.ReadLine();
            if (string.IsNullOrEmpty(userinput) || userinput.Equals("new") == false)
            {
                System.Environment.Exit(0); //To exit the recipe program.
            }
            else
                Console.Clear();
            start();
            DeleteData();
            restart_App();

        }



        public void red_warningMessage(string message) //This method is to display warning messages in red.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;


        }


    }
}
