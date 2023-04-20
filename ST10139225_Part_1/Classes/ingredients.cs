using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_Part_1.Classes
{
    internal class ingredients
    {
        public string Name; //Stores the name of the ingredient
        public float quantity;//To store the original quantity of the ingredient
        public float Scaled_quantity; //To store the scaled quantity of the ingredient
        public string Unit_of_measurement; // To store the unit of measurement

        
        public ingredients() {

            string UserInput = null; // To store user input.
            // To capture the name of the ingredient.
            Console.WriteLine("Please enter the name of ingredient:");
            UserInput =  Console.ReadLine();
            Name = UserInput;

            // To capture the quantity of the ingredient.
            Console.WriteLine("Please enter the quantity of "+ Name+":");
            UserInput = Console.ReadLine();
            quantity = float.Parse(UserInput);

            

            // To store the Unit of measurement for the ingredient.
            Console.WriteLine("Please enter the quantity of ");
            UserInput = Console.ReadLine();
            Unit_of_measurement = UserInput;

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();


        }

        // To capture the scaled quanity of the ingredient.

        public void scaleUp(float multiple)
        {
            Scaled_quantity = quantity * multiple;

        }
        // To capture the scaled quanity of the ingredient.

        public void scaleDown(float multiple)
        {
            Scaled_quantity = quantity / multiple;

        }

    }

  
}
