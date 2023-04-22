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
        int Number_of_steps = 0;
        List<Steps> List_of_Steps = new List<Steps>();


        private void Addsteps()
        {
            string Instruction;
            for (int count = 0; count <= Number_of_steps; count++)
            {
                Console.WriteLine("Please enter step " + count + ": ");
                Instruction = Console.ReadLine();
                Steps instruction = new Steps(count, Instruction);
                List_of_Steps.Add(instruction);
            }
        }

    }
}
