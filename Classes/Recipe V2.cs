using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_K_Baholo_Part1.Classes
{
    internal class Recipe_V2: Recipe 
    {
        public List<Steps> Steps_list = new List<Steps>();
        public List<Ingredients_v2>Ingredient_list =  new List<Ingredients_v2>();

        int which_menu = 0;//Determines which menu to display
        string[] options_main = new string[3];


        public Recipe_V2()
        {
            start();
        }

        //This is the target for the delegate which will be used in all the ingredients as they get stored in the lists..
         static void notifyUser(string alert)
        {
            Console.WriteLine(String.Format("\n\n{0,-24}{1,8}", "", ">>>>>ALERT<<<<<\n"));

            Console.WriteLine(String.Format("{0,12}{1,8}{2,2}\n\n",">>>>>> ",alert," <<<<<<"));
        }
        public void start()
        {
            Addingredients();
            Addsteps();
            printRecipe();
        }

        public int Displaymenu() //This is the method responsible for displaying the menu
        {
            string input = "";
           
            int choice = -1; // To store user's choice 
            
            if (which_menu == 0)
            {
                options_main[0] = "1.) Enter a recipe";
                options_main[1] = "2.) Select a recipe";
                options_main[2] = "3.) Clear data";
                
                


            }
            else if (which_menu == 1) // When the user chooses to select a recipe, the menu will present what the user can do to the recipe
            {
                options_main[0] = "1.) Scale recipe";
                options_main[1] = "2.) Delete recipe";
                options_main[2] = "3.) Edit recipe";

                

            }
            foreach (string option in options_main)
            {
                Console.WriteLine(option);
            }
            Console.WriteLine("Please select an option.");
            input = Console.ReadLine();
            try
            {
                choice = int.Parse(input);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please enter a number for the choice, not alphabetical values\n\n");
                Displaymenu();
            }
            if (input == null)
            {
                Console.WriteLine("Please enter your choice, 1, 2 or 3 from the option in the menu, no empty spaces please");
                Displaymenu();

            }
            else if (choice< 0 || choice > 4)
            {
               Console.WriteLine("Pleases select between 1 and 3");
                Displaymenu();

            }else
                which_menu = choice - 1;


            return choice-1;
        }

        public void printTheRecipe() 
        {
            Console.WriteLine(String.Format("********{0}********\n\n",Title));
            Console.WriteLine("********Ingredients********\n\n");

            foreach (Ingredients_v2 ingredient in Ingredient_list)
            {
                ingredient.printIngredient();
               
            }
            Console.WriteLine("********Steps********\n\n");

            foreach (Steps step in Steps_list)
            {
                Console.WriteLine(step.getStep());

                
            }
        }

        //This is to add steps to the step list:
        string userinput = "";
        private void Addsteps() //This method is responsible for adding steps.
        {
            int Number_of_steps = 0;
            Console.WriteLine("Please enter the number of steps:");
            userinput = Console.ReadLine();
            try
            {
                Number_of_steps = int.Parse(userinput);
            }
            catch (FormatException)
            {
                red_warningMessage("Please enter an integer value, e.g. 23 for the number of steps.");
                Addsteps();
            }


            for (int index = 0; index < Number_of_steps; index++)
            {
                Steps step = new Steps(index + 1);
                Steps_list.Add(step);
            }
        }


        //This method will add the ingredients to the ingredients list and this where the target for the delegate will be used:
        private void Addingredients()
        {
            int Number_of_ingredients = 0;
            Console.WriteLine("Please enter the number of ingredients:");
            userinput = Console.ReadLine();
            try
            {
                Number_of_ingredients = int.Parse(userinput);
            }
            catch (FormatException)
            {
                red_warningMessage("Please enter an integer value, e.g. 23 for the number of steps.");
                Addingredients();
            }


            for (int index = 0; index < Number_of_ingredients; index++)
            {
                Ingredients_v2 ingredient = new Ingredients_v2();
                ingredient.registeringCaloriesAlert(new Ingredients_v2.NotificationHandler(notifyUser)); // Target for delegate
                ingredient.check_Calories(ingredient.getcalories(), ingredient.Name_of_Ingredient, ingredient.Quanity_of_ingredient,ingredient.Unit_of_Measurement);
                Ingredient_list.Add(ingredient);

            }
        }

        public void printRecipe() //This method will display a selected recipe.
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n \n{0}:", Title);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nIngredients: ");
            Console.ForegroundColor = ConsoleColor.White;

            string line = String.Format("{0,-15} {1,-15} {2,-13} {3,10} {4,12}", "Ingredient ", "Quantity", "Unit of Measurement", "Calories", "Food group");
            Console.WriteLine(line);

            foreach (Ingredients_v2 ingredient in Ingredient_list)
            {

                ingredient.printIngredient();
            }


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n \nSteps: ");
            Console.ForegroundColor = ConsoleColor.White;

            foreach (Steps step in Steps_list)
            {
                Console.WriteLine("{0}", step.getStep());
            }
        }


    }
}
