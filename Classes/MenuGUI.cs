using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ST10139225_K_Baholo_Part1.Classes
{
    internal class MenuGUI
    {

        /*
         This class enables you to be able to interact with menu with your arrow keys.
         */
        private string instructions;
        private string[] menuItems;
        private int choosenOption=0;
        string lines;

        public MenuGUI(String commands, string[]options, string Lines)
        {
            instructions= commands;
            menuItems= options;
            lines= Lines;
        }

        public void display()
        {
            
            string currentChoice="";
            string backindicator = "<<<";
            string frontindicator = ">>>";

            Console.WriteLine(instructions);

            for(int i =0; i< menuItems.Length; i++) // This is to highlight the active menu item according to arrows.
            {

                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                if (choosenOption == i)
                {
                    Console.ForegroundColor= ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                     backindicator = ">>>";
                     frontindicator = "<<<";
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    backindicator = "<<<";
                    frontindicator = ">>>";
                }
                currentChoice = menuItems[i];

                Console.WriteLine(String.Format("{0}{1}{2}", backindicator, currentChoice
                    , frontindicator));
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(lines);

        }
        public int getSelectedOption() //This method determines which arrow was pressed by the user.
        {
            ConsoleKey cKey = ConsoleKey.O; //Just to initialize the variable which willl store the key pressed.
            while(cKey != ConsoleKey.Enter)
            {
                Console.Clear(); 
                display();  
                ConsoleKeyInfo cKeyInfo= Console.ReadKey(true);
                cKey= cKeyInfo.Key; 
                /*
                 The reason I used many different keys, is to improve user experience.
                 */
                if(cKey== ConsoleKey.UpArrow|| cKey == ConsoleKey.W || cKey == ConsoleKey.I||cKey==ConsoleKey.RightArrow)
                {
                    choosenOption --;
                    if (choosenOption <0)
                    {
                        choosenOption++;
                        
                    }

                }
                if(cKey== ConsoleKey.DownArrow|| cKey == ConsoleKey.S || cKey == ConsoleKey.K||cKey==ConsoleKey.LeftArrow)
                {
                    choosenOption++;
                    if (choosenOption > menuItems.Length-1)
                    {
                        choosenOption--;
                    }
                       


                }
            }
            return choosenOption;
        }


    }
}
