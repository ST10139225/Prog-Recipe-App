using System;
using System.Collections.Generic;
using System.Linq;
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
            UserInput = Console.ReadLine();
            int Number_of_steps = int.Parse(UserInput);
            string Instruction;
            for (int count = 0; count <= Number_of_steps; count++)
            {
                Console.WriteLine("Please enter step " + count + ": ");
                Instruction = Console.ReadLine();
                Steps instruction = new Steps(count, Instruction);
                List_of_Steps.Add(instruction);
            }
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

    }
}
