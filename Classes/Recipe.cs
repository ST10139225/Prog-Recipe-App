using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_K_Baholo_Part1.Classes
{
    //This is a class for recipes. 
    internal class Recipe
    {
        //To store all the steps
        String UserInput = "";
        List<Steps> List_of_Steps = new List<Steps>();
        List<Ingredients>List_of_ingredients= new List<Ingredients>();


        private void Addsteps()
        {
            Console.WriteLine("Please enter the number of steps:");
         
        }

        private void Addingredients()
        {
            Console.WriteLine("Please enter the number of ingredients:");
            UserInput = Console.ReadLine();
            int Number_of_ingredients = int.Parse(UserInput);
            for (int count = 0; count <= Number_of_ingredients; count++)
            { 
                Ingredients ingredient = new Ingredients();
                List_of_ingredients.Add(ingredient);
            }
        }

        public void printRecipe()
        {
            Console.WriteLine("Ingredients: ");
            int counter = 0;
            foreach(Ingredients i in List_of_ingredients)
            {
                counter++;
                Console.WriteLine("{0}.) {1}.", counter, i.PrintIngredient());
            }
            counter= 0;
            Console.WriteLine("Steps: ");
            foreach (Steps step in List_of_Steps)
            {
                counter++;
                Console.WriteLine("{0}.) {1}.", counter, step.getStep());
            }
        }

    }
}
