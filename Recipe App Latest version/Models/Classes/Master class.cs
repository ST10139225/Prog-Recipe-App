using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Recipe_App_Latest_version.Classes
{
   public class Master_class //This class will act as the access point to create, edit, and delete and store recipes.
    {
        string userinput = "";
        int number_of_recipes = 0;
        Menu menu;


         List<Recipe_V2> recipes = new List<Recipe_V2>();

        int quite = 1;
        int choice = 0;

        public Master_class()
        {
            ///This is part 2 changes
            ///
           menu = new Menu();
            startMenu();
           
        }

        public void startMenu()
        {
            if (quite != 0)
            {
                choice = menu.openUpMenu(recipes.Count);

            }
            else
                System.Environment.Exit(0);


            if (choice == 0)
            {
                Console.Clear();
                start();

            }
            else if (choice == 1)
            {
                selectARecipe();


            }
            else if (choice == 2)
            {
                DeleteData();

            }
            else if (choice == 3)
            {
                quite = 0;

            }
        }
        private void start()// This method starts the application.
        {
            Console.WriteLine("Pleases enter the number of recipes you would like to enter");
            userinput = Console.ReadLine();
            try
            {
                number_of_recipes = int.Parse(userinput);
                if (number_of_recipes < 1)
                {
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
            Console.WriteLine("Do you want to exit to main menu? Yes or no");
            string UserInput = Console.ReadLine();

            if (UserInput.Equals("yes"))
            {
                startMenu();


            }
            else if (UserInput.Equals("no"))
            {
                Console.WriteLine("Final stage...");
                System.Environment.Exit(0);

            }
            else if (UserInput.Equals("yes") == false && UserInput.Equals("no") == false)
            {
                red_warningMessage("Please enter an yes or no. ");
                System.Environment.Exit(0);
            }
           
            

        




        }

        
       

        //For the delegate
        static void notifyUser(string alert)
        {
            Console.WriteLine(String.Format("\n\n{0,-24}{1,8}", "", ">>>>>ALERT<<<<<\n"));

            Console.WriteLine(String.Format("{0,12}{1,8}{2,2}\n\n", ">>>>>> ", alert, " <<<<<<"));
        }





        /// <summary>
        /// /////////////////End of part 2 changes
        /// </summary>

        private void start_old()// This method starts the application.
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

         Recipe_V2 getRecipe(int index)// This method gets a recipe from the array.
        {
            return recipes.ElementAt(index);
        }

        //A short prompt to break the logic
        public void shortPropmt()
        {
            Console.WriteLine("Do you want to exit to main menu? yes or no");
            string UserInput = Console.ReadLine();

            if (UserInput.Equals("yes"))
            {
                startMenu();


            }
            else if (UserInput.Equals("no"))
            {
                Console.WriteLine("Final stage...");
                System.Environment.Exit(0);

            }
            else
            {
                red_warningMessage("Please enter an yes or no. ");
                shortPropmt();
            }

        }

        string line = "";
        
        public void selectARecipe() { //This method is for selecting a recipe to scale or edit.

                foreach (Recipe_V2 recipe in recipes)
            {
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                Console.WriteLine(String.Format("{0,32}{1,15}", "", recipe.getTitle()));
                Console.WriteLine("------------------------------------------------------------------------------------------------");
                line += "\n" + recipe.getTitle();
            }
            Recipe_V2 selectedRecipe = null;
            Console.WriteLine("Select the recipe you want to scale. \nEnter the name of the recipe: ");
            userinput = Console.ReadLine();
            try
            {
                selectedRecipe = getRecipe(findRecipe(userinput));

                selectedRecipe.printRecipe();
                
                choice = menu.openUpSecondMenu(line);
                if (choice == 0)
                {

                    selectedRecipe.scale_recipe();
                    selectedRecipe.printRecipe();
                    shortPropmt();
                    

                }else if (choice == 1)
                {
                    selectedRecipe.reset();
                    selectedRecipe.printRecipe();
                    shortPropmt();


                }
                else if (choice == 2)
                {
                    Console.WriteLine("Removed" + selectedRecipe.getTitle() + " from your recipes");

                    recipes.Remove(selectedRecipe);
                    printAllRecipes();
                    shortPropmt();


                }
                else if (choice == 3)
                {
                    startMenu();

                } else if (choice == 4)
                {
                    selectedRecipe.registerAlert(new Recipe_V2.alertManager(notifyUser));
                    selectedRecipe.check_Total_Calories();
                    selectedRecipe.printRecipe();
                    shortPropmt();

                }




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
                    if (recipes.ElementAt(i).Title.Equals(title))
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
            Recipe_V2 recipe = new Recipe_V2();
            recipe.registerAlert(new Recipe_V2.alertManager(notifyUser));
                recipes.Add(recipe);
            
            
        }
    List<string> recipesTitles;
        public void printAllRecipes()
        {
            red_warningMessage("\n\n\n\nAll the recipes are:");
            
            foreach(Recipe_V2 recipe in recipes) 
             {
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("\n"+recipe.Title+"\n"); 
               
            }
          


        }
        //To order the list of recipes
        public void SortedList()
        {
             
            for (int i = 0; i < recipes.Count; i++)
            {
                recipesTitles.Add(recipes.ElementAt(i).getTitle());
            }
            recipesTitles.Sort();   
            List<Recipe_V2> tempRec = new List<Recipe_V2>();
            foreach(string r in recipesTitles)
            {
                Recipe_V2 tempRecipe = getRecipe(findRecipe(r));
                tempRec.Add(tempRecipe);
            }
            if (tempRec.Count == recipes.Count)
            {
                recipes.Clear();
            }
            foreach (Recipe_V2 temprecipe in tempRec)
            {
                
                recipes.Add(temprecipe);

            }
            tempRec.Clear();


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
