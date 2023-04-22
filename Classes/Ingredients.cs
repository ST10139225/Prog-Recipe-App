using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_K_Baholo_Part1.Classes
{
    internal class Ingredients
    {
            private string Name_of_Ingredient;
            private float Quanity_of_ingredient;
            private string Unit_of_Measurement;
            private float Scaled_quantity;

        public Ingredients()
        {
            String UserInput = "";
            Console.WriteLine("Please enter the name of the ingredient:");
            UserInput= Console.ReadLine();
            Name_of_Ingredient = UserInput;
            
            Console.WriteLine("Please enter the quantity for "+Name_of_Ingredient+":");
            UserInput = Console.ReadLine();
            Quanity_of_ingredient = float.Parse(UserInput);


            Console.WriteLine("Please enter the unit of measurement for the quantity of: " + Quanity_of_ingredient);
            UserInput = Console.ReadLine();

            if (set_unit_of_measurement(UserInput) == true)
            {
                Unit_of_Measurement = UserInput;
            }
            else
            {
                Console.WriteLine("Please enter as unit of meaasurement: spoon or spoons, tea spoon or tea spoons, cup or cups, \n " +
                                  "g or grams, kg or kilograms, ml or milliliters, l or liter or liters");
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
            public Boolean set_unit_of_measurement(string userinput)
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




()








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
