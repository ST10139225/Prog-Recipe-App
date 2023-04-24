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
            try
            {
                setQuantity();
            }catch(FormatException e)
            {
                Console.WriteLine("Please enter the quantity in numerical form: 1 or 1.25");
            }
            setUnit_of_meausurement();
            reset_quantity();




        }

        private void setName() //This method of setting the name of the ingredient. It has input validation.
        {
            String UserInput="";
            Console.WriteLine("Please enter the name of the ingredient:");

            UserInput = Console.ReadLine();
            if (UserInput != null)
            {
                Name_of_Ingredient = UserInput;
            }
            else
            {
                Console.WriteLine("Please enter a name of the ");
                setName();
            }

        }

        private void setQuantity() //This method is to set the quantity of the ingredient. It has input validation.
        {
            String UserInput = "";

            Console.WriteLine("Please enter the quantity for " + Name_of_Ingredient + ":");
            UserInput = Console.ReadLine();
            if (UserInput != null)
            {
               
                    Quanity_of_ingredient = float.Parse(UserInput);
               

            }
            else
            {
                Console.WriteLine("Please enter the quantity for " + Name_of_Ingredient + ":");

                setQuantity();
            }

        }

        private void setUnit_of_meausurement()
        {
            String UserInput = "";
            Console.WriteLine("Fill in the blank: "+Quanity_of_ingredient+" ________ of"+Name_of_Ingredient);
            UserInput = Console.ReadLine();

            if (validate_unit_of_measurement(UserInput) == true)
            {
                Unit_of_Measurement = UserInput;
            }
            else
            {
                Console.WriteLine("Please enter as unit of meaasurement: spoon or spoons, tea spoon or tea spoons, cup or cups, \n " +
                                  "g or grams, kg or kilograms, ml or milliliters, l or liter or liters");
                setUnit_of_meausurement();
            }

        }

        public string PrintIngredient()
            {
                string IngredientString = "Name: " + Name_of_Ingredient + "\nQuantity: " + Quanity_of_ingredient + "\nMeasurment(Unit)" + Unit_of_Measurement;

                return IngredientString;
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
        public void scale_up_ingredient(int Factor)
            {
                Scaled_quantity = Quanity_of_ingredient * Factor;
                if (Scaled_quantity >= 8 && Unit_of_Measurement.Equals("table spoon(s)"))
                {
                    Unit_of_Measurement = "Cup(s)";
                }
                if (Scaled_quantity >= 3 && Unit_of_Measurement.Equals("tea spoon(s)"))
                {
                    Unit_of_Measurement = "table spoon(s)";
                }
                if (Scaled_quantity >= 1000 && Unit_of_Measurement.Equals("ml"))
                {
                    Unit_of_Measurement = "litre(s)";
                }
                if (Scaled_quantity >= 1000 && Unit_of_Measurement.Equals("g"))
                {
                    Unit_of_Measurement = "kilogram(s)";
                }
            }
            public void scale_down_ingredient(int Factor)
            {
                Scaled_quantity = Quanity_of_ingredient % Factor;
                if (Scaled_quantity < 1 && Unit_of_Measurement.Equals("Cup(s)"))
                {
                    Unit_of_Measurement = "table spoon(s)";
                }
                if (Scaled_quantity < 3 && Unit_of_Measurement.Equals("table spoon(s)"))
                {
                    Unit_of_Measurement = "tea spoon(s)";
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
