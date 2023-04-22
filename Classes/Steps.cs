using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_K_Baholo_Part1.Classes
{
    internal class Steps
    {

        private int step_number;
        private string Description;

        public Steps(int Step_number, string description)
            {

                this.Description = description;
                this.step_number = Step_number;
            }

    public string getStep()
        {
            return "" + step_number + ".) " + Description + ".";
        }


     

    }
}
