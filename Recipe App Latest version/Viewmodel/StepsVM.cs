using Recipe_App_Latest_version.Core;
using Recipe_App_Latest_version.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App_Latest_version.Viewmodel
{
    class StepsVM: ObservableObject
    {
        public StepsModel _stepsModel;
        int i;
        public int step_number;
        public string Description;

        public StepsVM(StepsModel step) {
        
            _stepsModel = step;
        }

    }
}
