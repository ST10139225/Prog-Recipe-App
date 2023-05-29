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

        public void start()
        {
            int choice = -1;
            choice = Displaymenu();
            if(choice == 0) {
                addRecipe();
                foreach(Steps step in List_of_Steps)
                {
                    Steps_list.Add(step);
                }foreach(Ingredients_v2 ingredient in List_of_ingredients)
                {
                    Ingredient_list.Add(ingredient);
                }

            }

           printTheRecipe();
            if(choice == 1) {
                which_menu = 2;
                Displaymenu();  
            }
            if(choice == 2) { }
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
                Console.WriteLine(ingredient.printIngredient());
               
            }
            Console.WriteLine("********Steps********\n\n");

            foreach (Steps step in Steps_list)
            {
                Console.WriteLine(step.getStep());

                
            }
        }
        
        
    }
}
