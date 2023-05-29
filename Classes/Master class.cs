using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ST10139225_K_Baholo_Part1.Classes
{
    internal class Master_class //This class will act as the access point to create, edit, and delete and store recipes.
    {
        string userinput = "";
        int number_of_recipes = 0;

        List<Recipe> recipes = new List<Recipe>();


        public Master_class()
        {
            start();
            printAllRecipes();
            selectARecipe();
            DeleteData();
            addAnotherRecipe();

            restart_App();
        }

        public void start()// This method starts the application.
        {
            Console.WriteLine("Pleases enter the number of recipes you would like to enter");
            userinput = Console.ReadLine();
            try
            {
                number_of_recipes = int.Parse(userinput);
                if (number_of_recipes < 1) {
                    red_warningMessage("Please a number greater than 0");
                    start();
                }
                for (int i = 0; i < number_of_recipes; i++)
                {
                    AddRecipe();
                }

            }
            catch (FormatException)
            {
                red_warningMessage("Please the number, e.g. 12, of the recipes you want. ");
                start();

            }



        }

        public Recipe getRecipe(int index)// This method gets a recipe from the array.
        {
            return recipes[index];
        }

        public void selectARecipe() { //This method is for selecting a recipe to scale or edit.
            Recipe selectedRecipe = null;
            Console.WriteLine("Select the recipe you want to scale. \nEnter the name of the recipe: ");
            userinput = Console.ReadLine();
            try
            {
                selectedRecipe = getRecipe(findRecipe(userinput));

                //selectedRecipe.printRecipe();

                selectedRecipe.scale_recipe(); ;

                selectedRecipe.reset();

            }
            catch (Exception)
            {
                red_warningMessage("Please enter a name of an existing recipe.");
                selectARecipe();
            }






        }

        public void addAnotherRecipe()
        {
            Console.WriteLine("Do you want to enter a new recipe? \nEnter yes to proceed, anything else will make you progress:");
            userinput = Console.ReadLine();
            if (userinput.Equals("yes"))
            {
                AddRecipe();
                selectARecipe();
            }
            else
            {

            }
        }



        private int findRecipe(string title) //To find the recipe in the array.
        {
            int index = -1;
            for (int i = 0; i < recipes.Count; i++)
            {
                try
                {
                    if (recipes[i].Title.Equals(title))
                    {

                        index = i;

                    }
                }
                catch (NullReferenceException)
                {
                    red_warningMessage("Please re-enter value");
                    findRecipe(title);
                }
            }
            return index;
        }

        public void AddRecipe()// This method adds populates the recipes array.
        {
            
            
                recipes.Add(new Recipe());
            
        }

        private void printAllRecipes()
        {
            red_warningMessage("\n\n\n\nAll the recipes are:");
            foreach(Recipe recipe in recipes) 
             {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("\n"+recipe.Title+"\n");    
            }
                Console.ForegroundColor= ConsoleColor.White;


        }





        public void DeleteData()
        {
           
            Console.WriteLine("Do you want to delete all data? \nEnter yes to proceed:");
            userinput = Console.ReadLine();
            if (string.IsNullOrEmpty(userinput)||userinput.Equals("yes")==false)
            {
                red_warningMessage("Please the yes");
                DeleteData(); 
            }
            
            recipes.Clear();

            red_warningMessage("\n\nThere are no recipes to display.");
           
        }

        public void restart_App()
        {
            Console.WriteLine(" \nEnter 'yes' to enter a recipe, anything else will exit the program.");
            userinput = Console.ReadLine();
            if (string.IsNullOrEmpty(userinput) || userinput.Equals("yes") == false)
            {
                System.Environment.Exit(0); //To exit the recipe program.
            }
            else
                Console.Clear();
            start();
            printAllRecipes();
            selectARecipe();
            DeleteData();
            addAnotherRecipe();

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
