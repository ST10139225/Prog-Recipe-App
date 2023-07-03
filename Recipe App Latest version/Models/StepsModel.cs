using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App_Latest_version.Models
{
    class StepsModel
    {

        public int step_number;
        public string Description;

        public StepsModel()
        {
            
        }

        public void setDescription(String UserInput) //This is setter method for the description of the step.
        { 
            
            UserInput = Console.ReadLine();

            if (UserInput != null && UserInput.Equals("") != true)
            {
                this.Description = UserInput;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red; //To change color to show invalid input.
                Console.WriteLine("Not empty space please!!");

                setDescription( UserInput);

            }
        }
        public void setStep_number(int step_number)
        {
            this.step_number = step_number;
        }

        public string getStep()
        {
            return  Description ;
        }



    }
}
