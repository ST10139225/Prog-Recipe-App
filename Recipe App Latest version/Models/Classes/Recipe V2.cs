using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Recipe_App_Latest_version.Classes
{
    internal class Recipe_V2
    { /*
    {
        public List<Steps> Steps_list = new List<Steps>();
        public List<Ingredients_v2>Ingredient_list =  new List<Ingredients_v2>();

        int which_menu = 0;//Determines which menu to display
        string[] options_main = new string[3];

        // This is to keep track of the total calories of a recipe.
        float total_Calories = 0;
        public delegate void alertManager(string alert);

        private alertManager calorie_Checker; 

        public void registerAlert(alertManager calorie_checker)
        {
            calorie_Checker= calorie_checker;
        }

        public void check_Total_Calories()
        {
            if (total_Calories > 300)
            {
                calorie_Checker?.Invoke("Be careful! total_Calories of " + getTitle() + " exceed 300");
            }
            else if (total_Calories == 300)
            {
                calorie_Checker?.Invoke("That was close! total_Calories of " + getTitle() + " are at max recommended amount");

            }
            else if (total_Calories < 300)
            {
                calorie_Checker?.Invoke("Staying lean! total_Calories of this " + getTitle() + " are of a good amount");

            }
        }
        //end of calorie delegate
        public Recipe_V2()
        {
            start();
        }

        //This is the target for the delegate which will be used in all the ingredients as they get stored in the lists..
         static void notifyUser(string alert)
        {
            Console.WriteLine("--------------------------------------------------------------------------------------");

            Console.WriteLine(String.Format("\n\n{0,-24}{1,10}", "", ">>>>>ALERT<<<<<\n"));

            Console.WriteLine(String.Format("{0,12}{1,8}{2,2}\n\n",">>>>>> ",alert," <<<<<<"));
            Console.WriteLine("--------------------------------------------------------------------------------------");


        }
        public void start()
        {
            setTitle();
            Addingredients();
            Addsteps();
            printRecipe();
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
                total_Calories += ingredient.getcalories();
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

            string line = String.Format("{0,-15} {1,-15} {2,-13} {3,10} {4,12}", "Ingredient ", "Quantity", "Unit of Measurement", "total_Calories", "Food group");
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

        float Scale = 0;
        public void scale_recipe() ///This method is responsible for scaling the recipe.
        {
            float scale = 0; //This variable stores the factor of scale.

            scale = getScale_value();
            Scale = scale;
            selectTypeofScale(Scale);

        }

        private float getScale_value() //This method is responsible for getting the value, 0.5, 1, 2 or 3 for scaling the recipe 
        {
            float value = 0f;

            Console.WriteLine("Enter the factor of scale to apply, e.g. 0.5");
            UserInput = Console.ReadLine();
            try
            {
                value = float.Parse(UserInput);
            }
            catch (FormatException)
            {
                red_warningMessage("Please enter a value, e.g. 2.5 or 0.5 ");
                getScale_value();
            }
            return value;
        }

        string UserInput = "";
        private void selectTypeofScale(float scale) //This method is to select whether the recipe should be scaled up or down.
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
                selectTypeofScale(scale);
            }
        }


        public void scale_up_ingredients(float scale)
        {
            

            for (int i = 0; i < Ingredient_list.Count; i++)
            {
                Ingredient_list.ElementAt(i).scale_up_ingredient(scale);
            }
        }
        public void scale_down_ingredients(float scale)
        {

            for (int i = 0; i < Ingredient_list.Count; i++)
            {
                Ingredient_list.ElementAt(i).scale_down_ingredient(scale);
            }
        }


        public void reset()
        {
            Console.WriteLine("Do you wish to reset the recipe? \n\nType in 'yes' or 'no'");
            UserInput = Console.ReadLine();

            //This section of the method takes in the decision to scale up or down.
            if (UserInput.Equals("yes"))
            {
                for (int i = 0; i < Ingredient_list.Count; i++)
                {
                    Ingredient_list.ElementAt(i).reset();
                }
                //printRecipe();

            }
            else Console.WriteLine("\n");
        }















        */
    }
}
