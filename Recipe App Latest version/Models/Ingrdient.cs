using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App_Latest_version.Models
{
    public class Ingrdient
    {
        public string Name_of_Ingredient; //To store the name of an ingredient
        public float Quanity_of_ingredient; //To store the quantity of an ingredient
        public string Unit_of_Measurement;  //To store the unit of measurement of an ingredient
        public float Calories;  //To store the number of calories of an ingredient


        public void setIngName(string name)
        {
            Name_of_Ingredient= name;
        } 
        public void setIngQ(float quantity)
        {
            Quanity_of_ingredient = quantity;
        } 
        public void setIngCal(float cals)
        {
            Calories = cals;
        } 
        public void setIngunit(string unit_of_Measurement)
        {
            Unit_of_Measurement = unit_of_Measurement;
        }

        
        public string getIngName()
        {
            return Name_of_Ingredient;
        } 
        public float getIngQ()
        {
            return Quanity_of_ingredient;
        }
        public float getIngCal()
        {
            return Calories ;
        }
        public string getIngunit()
        {
            return Unit_of_Measurement;
        }


    }
}
