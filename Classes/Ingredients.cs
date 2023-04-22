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
            Unit_of_Measurement = UserInput;




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
            public void set_unit_of_measurement()
            {
                int option_measurement = 0; //This variable will store the number of the option selected by the user as to which 
                                            //unit of measurement between tblspn, tsp, ml,g,and cups.



                Console.WriteLine("Please select the number for the unit of measurement \n");
                Console.WriteLine("Option 1: table spoon \n");
                Console.WriteLine("Option 2: tea spoon\n");
                Console.WriteLine("Option 3: ml\n");
                Console.WriteLine("Option 4: g\n");
                Console.WriteLine("Option 5: cups\n");
                option_measurement = int.Parse(Console.ReadLine());

                switch (option_measurement)
                {
                    case 1:
                        Unit_of_Measurement = "table spoon(s)";
                        break;
                    case 2:
                        Unit_of_Measurement = "tea spoon(s)";
                        break;
                    case 3:
                        Unit_of_Measurement = "ml";
                        break;
                    case 4:
                        Unit_of_Measurement = "g";
                        break;
                    case 5:
                    Unit_of_Measurement = "cups";
                        break;

                }

                Console.WriteLine("Please enter the name of the ingredient");
                Quanity_of_ingredient = int.Parse(Console.ReadLine());



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
