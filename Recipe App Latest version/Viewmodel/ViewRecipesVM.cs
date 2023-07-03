using Recipe_App_Latest_version.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Recipe_App_Latest_version.Viewmodel
{
    class ViewRecipesVM : ObservableObject
    {
        private readonly ObservableCollection<StepsVM> _stepsVMs;
        private readonly ObservableCollection<addIngredientVM> _ingredientsVMs;

        public ICommand Homescreen { get; }

        public ViewRecipesVM()
        {
            _stepsVMs= new ObservableCollection<StepsVM>();
            _ingredientsVMs = new ObservableCollection<addIngredientVM>();
        }

    }
}
