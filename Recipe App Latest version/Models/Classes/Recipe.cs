using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Recipe_App_Latest_version.Classes
{
    //This is a class for recipes. 
    internal class Recipe
    {
        public String Title = "";//To store the name of the recipe.

        String UserInput = ""; //To store user input.

        public Steps[] List_of_Steps;         //To store all the steps.

        public Ingredients_v2[] List_of_ingredients; //To store all the ingredients.

        String scaleType = ""; //To store which type of scaling was choosen, whether it was an up scale or down scale.



        public Recipe()
        {
            
            /*
             Method were moved a new method, addRecipe.
             */


        }
        public void addRecipe() // this is the new method
        {
            setTitle();


        }

        public void setTitle() //This is a setter method for the title of a recipe.
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\nPlease enter a title for the recipe: ");
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

        public string getTitle()
        {
            return this.Title;  
        }

       

        

       



      

         public void red_warningMessage(string message) //This method is to display warning messages in red.
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White;


        }


    }
}
