using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_K_Baholo_Part1.Classes
{
    internal class Ingredients
    {
            private string Name_of_Ingredient; //To store the name of an ingredient
            private float Quanity_of_ingredient; //To store the quantity of an ingredient
            private string Unit_of_Measurement;  //To store the unit of measurement of an ingredient
        private float Scaled_quantity; //To store the scaled quantity of an ingredient

        public Ingredients()
        {
            setName();
            setQuantity();
            setUnit_of_meausurement();
            reset_quantity();




        }

        private void setName() //This method of setting the name of the ingredient. It has input validation.
        {
            Console.ForegroundColor = ConsoleColor.White; //To change color to show invalid input.

            String UserInput ="";
            Console.WriteLine("Please enter the name of the ingredient:");

            UserInput = Console.ReadLine();
            if (UserInput != null && UserInput.Equals("")!=true)
            {
                Name_of_Ingredient = UserInput;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; //To change color to show invalid input.
                Console.WriteLine("Not empty space please!!");
       
                setName();


            }

        }

        private void setQuantity() //This method is to set the quantity of the ingredient. It has input validation.
        {
            Console.ForegroundColor = ConsoleColor.White; //To change color to show invalid input.

            String UserInput = "";

            Console.WriteLine("Please enter the quantity for " + Name_of_Ingredient + ":");
            UserInput = Console.ReadLine();
            if (UserInput != null)
            {
                try
                {
                    Quanity_of_ingredient = float.Parse(UserInput);
                }
                catch (FormatException e)
                {
                    Console.ForegroundColor = ConsoleColor.Red; //To change color to show invalid input.

                    Console.WriteLine("Please enter the quantity in numerical form: 1 or 1.25");
                    setQuantity();
                }


            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; //To change color to show invalid input

                Console.WriteLine("Please enter the quantity for " + Name_of_Ingredient + ":");
                setQuantity();

            }

        }

        private void setUnit_of_meausurement()
        {
            Console.ForegroundColor = ConsoleColor.White; //To change color to show invalid input.

            String UserInput = "";
            Console.WriteLine("Fill in the blank: "+Quanity_of_ingredient+" ________ of "+Name_of_Ingredient);
            UserInput = Console.ReadLine();

            if (validate_unit_of_measurement(UserInput) == true)
            {
                Unit_of_Measurement = UserInput;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; //To change color to show invalid input.

                
                Console.WriteLine("Please enter as unit of meaasurement: spoon or spoons, tea spoon or tea spoons, cup or cups, \n " +
                                  "g or grams, kg or kilograms, ml or milliliters, l or liter or liters");
                setUnit_of_meausurement();


            }

        }

        public void PrintIngredient()
            {
            string line = String.Format("{0,-15} {1,-15} {2,-13}", Name_of_Ingredient, Quanity_of_ingredient, Unit_of_Measurement);
            Console.WriteLine(line);

               
            }


            public void reset_quantity()
            {
                Scaled_quantity = Quanity_of_ingredient;

            }
            public Boolean validate_unit_of_measurement(string userinput)
            {
                /*
                 This method will be used to ensure that the user enters the correct unit of measurement.
                 */

            bool CorrectInput= false;

            if ((String.Equals(userinput, "Spoon", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "Spoons", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "tea spoon", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "tea spoons", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "cup", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "cups", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "g", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "grams", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "kg", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "kilograms", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "ml", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "milliliters", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "l", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "liter", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "liters", StringComparison.OrdinalIgnoreCase)))
                CorrectInput = true;

            return CorrectInput;
            }
        public void scale_up_ingredient(float Factor) 
            {
            /* This is the first out of the two methods responsible for changing unit of measurements accordingly when the recipe is
            scaled. For example, our one tablespoon of sugar will become two tablespoons of sugar
            if the factor is 2.
            */
            Scaled_quantity = Quanity_of_ingredient * Factor;
                if (Scaled_quantity >= 16 && Unit_of_Measurement.Equals("table spoon")|| Unit_of_Measurement.Equals("table spoons"))
                {
                    Unit_of_Measurement = "cups";
                }
                if (Scaled_quantity >= 3 && Unit_of_Measurement.Equals("tea spoon") || Unit_of_Measurement.Equals("tea spoons"))
                {
                    Unit_of_Measurement = "table spoons";
                }
                if (Scaled_quantity >= 1000 && Unit_of_Measurement.Equals("ml") || Unit_of_Measurement.Equals("milliliters"))
                {
                    Unit_of_Measurement = "litres";
                }
                if (Scaled_quantity >= 1000 && Unit_of_Measurement.Equals("g") || Unit_of_Measurement.Equals("grams"))
                {
                    Unit_of_Measurement = "kilograms";
                }
            }
            public void scale_down_ingredient(float Factor)
            {
            //This is the second out of two methods responsible for changing the unit of measurement according to the scaled quantity.
                Scaled_quantity = Quanity_of_ingredient % Factor;
            float value = 0; 
                if (Scaled_quantity < 1 && Unit_of_Measurement.Equals("cup") || Unit_of_Measurement.Equals("cups"))
                {

                    Unit_of_Measurement = "table spoon(s)";
                }
                if (Scaled_quantity < 1 && Unit_of_Measurement.Equals("table spoon") || Unit_of_Measurement.Equals("table spoons"))
                {
                    Unit_of_Measurement = "tea spoons";
                }
                if (Scaled_quantity < 1000 && Unit_of_Measurement.Equals("litre(s)"))
                {
                    Unit_of_Measurement = "ml";
                }
                if (Scaled_quantity < 1000 && Unit_of_Measurement.Equals("kilogram(s)"))
                {
                    Unit_of_Measurement = "g";
                }

            }
        }
        
}
