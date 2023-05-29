using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ST10139225_K_Baholo_Part1.Classes
{ 
    internal class Ingredients_v2 : Ingredients
    {

        string food_Groups;
        int calories; 

        public Ingredients_v2()
        {

            setcalories();
            setFood_groups();
            Console.WriteLine(printIngredient());


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
                    Console.WriteLine("\n\n");
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
                calories = int.Parse(userinput);

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
        public int getcalories()
        {
            return calories;                  
        }   

        public string printIngredient()
        {
            Console.WriteLine("Ingredient: \n\n");
            string line = String.Format("{0,-15} {1,-15} {2,-13} {3,-13} {4,-13}", Name_of_Ingredient, Scaled_quantity, Scaled_Unit_of_Measurement, getcalories(), getFood_groups());

            return line;
        }


        



    }
}
