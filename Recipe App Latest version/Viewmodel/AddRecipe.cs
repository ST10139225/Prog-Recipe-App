using Recipe_App_Latest_version.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Recipe_App_Latest_version.Viewmodel
{
    internal class AddRecipe : ObservableObject
    {


		private string _recipName;

		
        public string RecipeName
		{
			get { return _recipName; }
			set { _recipName = value; 
			onPropertyChanged(nameof(RecipeName));		
			}
		}

		public ICommand SubmitCommand { get; set; }
		public ICommand CancelCommand { get; set; }


       public AddRecipe()
		{

		}

	}
}
