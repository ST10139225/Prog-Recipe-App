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
                catch (FormatException)
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

            Scaled_quantity = Quanity_of_ingredient;

        }


        public void PrintIngredient()
            {
            string line = String.Format("{0,-15} {1,-15} {2,-13}", Name_of_Ingredient, Scaled_quantity, Unit_of_Measurement);
            Console.WriteLine(line);

               
            }


            public void reset_quantity_after_up_scale(float factor) //This method is used return original values after scaling up.
            {
            scale_down_ingredient(factor);

            }
            public void reset_quantity_after_down_scale(float factor) //This method is used return original values after scaling down.
        {
            scale_up_ingredient(factor);

            }

            public void setUnit_of_meausurement()
            {
            /*
             This method will be used to ensure that the user enters the correct unit of measurement.
             */
            Console.ForegroundColor = ConsoleColor.White; //To change color to show invalid input.

            String userinput = "";
            Console.WriteLine("Fill in the blank: " + Quanity_of_ingredient + " ________ of " + Name_of_Ingredient);
            userinput = Console.ReadLine();



            if ((String.Equals(userinput, "Spoon", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "Spoons", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "tbs", StringComparison.OrdinalIgnoreCase)))//Shorten version of table spoon
                Unit_of_Measurement = "spoon(s)";
             else if(
                (String.Equals(userinput, "tea spoons", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "tsp", StringComparison.OrdinalIgnoreCase)))//Shorten version of tea spoon
                Unit_of_Measurement = "tea spoon(s)";
            else if ( 
               (String.Equals(userinput, "cup", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "cups", StringComparison.OrdinalIgnoreCase)))
                Unit_of_Measurement = "cup(s)";
            else if (
                (String.Equals(userinput, "g", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "grams", StringComparison.OrdinalIgnoreCase)))
                Unit_of_Measurement = "grams";
            else if (
                (String.Equals(userinput, "kg", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "kilograms", StringComparison.OrdinalIgnoreCase)))
                Unit_of_Measurement = "kilogram(s)";
            else if (
                (String.Equals(userinput, "ml", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "milliliters", StringComparison.OrdinalIgnoreCase)))
                Unit_of_Measurement = "milliliters";
            else if (
                (String.Equals(userinput, "l", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "liter", StringComparison.OrdinalIgnoreCase)) ||
                (String.Equals(userinput, "liters", StringComparison.OrdinalIgnoreCase)))
                Unit_of_Measurement = "liter(s)";
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; //To change color to show invalid input.


                Console.WriteLine("Please enter as unit of meaasurement: spoons, tea spoon , cups, \n " +
                                  "grams, kilograms, milliliters, liters");
                setUnit_of_meausurement();


            }

            
            }
        public void scale_up_ingredient(float Factor) 
            {
            /* This is the first out of the two methods responsible for changing unit of measurements accordingly when the recipe is
            scaled. For example, our one tablespoon of sugar will become two tablespoons of sugar
            if the factor is 2.
            */
            float value = 0; //This value will be used for conversion. e.g. 16 tbs = 1 cup.

            if (Unit_of_Measurement.Equals("spoon(s)"))
            {
                Scaled_quantity = Quanity_of_ingredient * Factor;

                if (Scaled_quantity >= 16)
                {
                    Unit_of_Measurement = "cup(s)";
                    value = Scaled_quantity/16;
                    Scaled_quantity = value;



                }
            }
            else if (Unit_of_Measurement.Equals("tea spoon(s)"))
            {
                Scaled_quantity = Quanity_of_ingredient * Factor;

                if (Scaled_quantity >= 3)
                {
                    Unit_of_Measurement = "spoon(s)";
                    value = Scaled_quantity / 3;
                    Scaled_quantity = value;
                }
            }
            else if (Unit_of_Measurement.Equals("milliliters"))
            {
                Scaled_quantity = Quanity_of_ingredient * Factor;

                if (Scaled_quantity >= 1000)
                {
                    Unit_of_Measurement = "liter(s)";
                    value = Scaled_quantity / 1000;
                    Scaled_quantity = value;
                }
            }
            else if ( Unit_of_Measurement.Equals("grams"))
            {
                Scaled_quantity = Quanity_of_ingredient * Factor;

                if (Scaled_quantity >= 1000)
                {
                    Unit_of_Measurement = "kilogram(s)";
                    value = Scaled_quantity / 1000;
                    Scaled_quantity = value;
                }
            }


        }
        public void scale_down_ingredient(float Factor)
            {
            //This is the second out of two methods responsible for changing the unit of measurement according to the scaled quantity.

            float value = 0;
            if (Unit_of_Measurement.Equals("cup(s)"))
            {

                Scaled_quantity = Quanity_of_ingredient / Factor;

                if (Scaled_quantity < 1)
                {

                    value = Scaled_quantity * 16;
                    Scaled_quantity = value;
                    Unit_of_Measurement = "spoon(s)";


                }
            }else if (Unit_of_Measurement.Equals("spoon(s)"))
            {
                Scaled_quantity = Quanity_of_ingredient / Factor;

                if (Scaled_quantity < 1)
                {
                    Unit_of_Measurement = "tea spoon(s)";
                    value = Scaled_quantity * 3;
                    Scaled_quantity = value;
                }
            }else if ( Unit_of_Measurement.Equals("liter(s)"))
            {
                Scaled_quantity = Quanity_of_ingredient / Factor;

                if (Scaled_quantity < 1)
                {
                    value = Scaled_quantity * 1000;
                    Scaled_quantity = value;
                    Unit_of_Measurement = "milliliters";

                }
            }
            else if (Unit_of_Measurement.Equals("kilogram(s)"))
            {
                Scaled_quantity = Quanity_of_ingredient / Factor;

                if (Scaled_quantity < 1)
                {
                    Unit_of_Measurement = "grams";
                    value = Scaled_quantity * 1000;
                    Scaled_quantity = value;
                }
            }
            

            }
       
        }
        
}
