using Recipe_App_Latest_version.Core;
using Recipe_App_Latest_version.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App_Latest_version.Viewmodel
{
    class addIngredientVM : ObservableObject
    {
        Ingrdient _ingredient;
        public addIngredientVM(Ingrdient ingredient)
        {
            _ingredient = ingredient;
        }
        public string Name_of_Ingredient => _ingredient.getIngName(); //To store the name of an ingredient
        public float Quanity_of_ingredient => _ingredient.getIngQ(); //To store the quantity of an ingredient
        public string Unit_of_Measurement => _ingredient.getIngunit();  //To store the unit of measurement of an ingredient
        public float Calories => _ingredient.getIngCal();


    
}
}
