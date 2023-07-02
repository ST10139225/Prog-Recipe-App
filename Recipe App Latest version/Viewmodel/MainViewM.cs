using Recipe_App_Latest_version.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App_Latest_version.Viewmodel
{
    internal class MainViewM : ObservableObject
    {
        public MainViewM() {

            AddRecipeViewM = new AddRecipe();
            RecipedetailsVM = new RecipeDetailsVM();

            CurrentView = AddRecipeViewM;

            AddRecipeCommand = new RelayCommand(o =>
            {
                CurrentView = AddRecipeViewM;
            }
            );
            AddRecipeDetailsCommand = new RelayCommand(o =>
            {
                CurrentView = RecipedetailsVM;
            }
            );
        }
        public AddRecipe AddRecipeViewM { get; set; }   // To add the recipe view where user enters the name and number of ingredients and steps.
        public RecipeDetailsVM RecipedetailsVM { get; set; } // To add the recipe view where user enters the details of the recipe.
                                                     

        public RelayCommand AddRecipeCommand { get; set; }
        public RelayCommand AddRecipeDetailsCommand { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;
                onPropertyChanged(); //To change views
            }
        }


    }
}
