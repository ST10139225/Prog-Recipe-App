using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Recipe_App_Latest_version.Classes
{ 
    internal class Ingredients_v2 : Ingredients
    {

        string food_Groups;
        float calories;
        public delegate void NotificationHandler(string CaloriesAlert);
        private NotificationHandler Alert;



        public Ingredients_v2()
        {

            setcalories();
            setFood_groups();
            Console.WriteLine(String.Format("{0,-15} {1,-15} {2,-13} {3,14} {4,17}", "Ingredient ", "Quantity", "Unit of Measurement", "Calories", "Food group"));
            printIngredient();

        }
       public void setFood_groups()
        {
            Console.WriteLine("Enter the food group of the ingredient ");
            string userinput = Console.ReadLine();
            if (userinput == null|| userinput.Equals(""))
            {
                Console.WriteLine("Please enter the food groups, no empty spaces please\n\n");
                setFood_groups();
            }

            try
            {
              int i=  int.Parse(userinput);
                if ((i<=0)||(i>=0))
                {
                    Console.WriteLine("\n Do not enter a number as a food group, enter a name: 'Fish' ");
                    setFood_groups();
                }

            }
            catch (Exception ex)
            {
                food_Groups = userinput;
                
            }
        }
       
        public void setcalories()
        {
            Console.WriteLine("Enter the calories of the ingrdient");
            string userinput = Console.ReadLine();
            if (userinput == null)
            {
                Console.WriteLine("Please enter the calories, no empty spaces please");
                setcalories();
            }

            try
            {
                calories = float.Parse(userinput);

            }catch(Exception ex)
            {
                Console.WriteLine("Please enter a number for the calories, not alphabetical values\n\n");
                setcalories();
            }
        }   
        
       public string getFood_groups()
        {
            return food_Groups;
        }  
        public float getcalories()
        {
            return calories;                  
        }   

        public void printIngredient()
        {
            string line = String.Format("{0,-15} {1,-15} {2,-15} {3,13} {4,16}", Name_of_Ingredient, Scaled_quantity, Scaled_Unit_of_Measurement, getcalories(), getFood_groups());
            Console.WriteLine(line);

            
        }

        //The delegate to notify the user when the calories exceed 300.
        
        public void registeringCaloriesAlert(NotificationHandler Alertformat)
        {
            Alert  = Alertformat;
        }
        
        public void check_Calories(float Calories, string name, float quantity, string unit)
        {
            if(Calories > 300)
            {
                Alert?.Invoke("Be careful! Calories of "+quantity+" "+unit+" of "+name+" exceed 300");
            }else if (Calories == 300)
            {
                Alert?.Invoke("That was close! Calories of " + quantity + " " + unit + " of " + name + " are at max recommended amount");

            }
            else if (Calories < 300)
            {
                Alert?.Invoke("Staying lean! Calories of this " + quantity + " " + unit + " of " + name + " are of a good amount");

            }
        }
        



    }
}
