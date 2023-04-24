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

        public Steps(int step_number)
            {
            setStep_number(step_number);

            setDescription();
            }

        public void setDescription() //This is setter method for the description of the step.
        {
            Console.WriteLine("Please enter the description for step: {0}", step_number);
             
            Console.ForegroundColor = ConsoleColor.White; //To change color to show invalid input.

            String UserInput = "";
            UserInput = Console.ReadLine();

            if (UserInput != null && UserInput.Equals("") != true)
            {
                this.Description = UserInput;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; //To change color to show invalid input.
                Console.WriteLine("Not empty space please!!");

                setDescription();

            }
        }
        public void setStep_number(int step_number)
        {
            this.step_number = step_number;
        }

    public string getStep()
        {
            return "" + step_number + ".) " + Description + ".";
        }


     

    }
}
