using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe_App_Latest_version.Classes
{
    internal class Menu
    {
        public int openUpMenu(int Count)
        {
            //This for decoration
            String instruction = @"
    
██████╗░███████╗░█████╗░██╗██████╗░███████╗      ░█████╗░██████╗░██████╗░
██╔══██╗██╔════╝██╔══██╗██║██╔══██╗██╔════╝      ██╔══██╗██╔══██╗██╔══██╗
██████╔╝█████╗░░██║░░╚═╝██║██████╔╝█████╗░░      ███████║██████╔╝██████╔╝
██╔══██╗██╔══╝░░██║░░██╗██║██╔═══╝░██╔══╝░░      ██╔══██║██╔═══╝░██╔═══╝░
██║░░██║███████╗╚█████╔╝██║██║░░░░░███████╗      ██║░░██║██║░░░░░██║░░░░░
╚═╝░░╚═╝╚══════╝░╚════╝░╚═╝╚═╝░░░░░╚══════╝      ╚═╝░░╚═╝╚═╝░░░░░╚═╝░░░░░
                    
                there are currently " + Count + " recipes available to view" +
                "\n             (Use the Up/Dowen arrow or W/S or I/K keys)";
            String[] options =
            {
            "Enter new Recipes",
            "Select a Recipe",
            "Clear all Data",
            "Exit"
            };
            int choice = 0;

            MenuGUI r = new MenuGUI(instruction, options, "");

            choice = r.getSelectedOption();
            return choice;

        }

        public int openUpSecondMenu(string lines) //This will show the second menu after adding a recipe.
        {
            //This for decoration
            String instruction = @"
    
                        Use the Up/Dowen arrow or W/S or I/K keys";
            String[] options =
            {
            "Scale recipe",
            "reset recipe",
            "Delete recipe",
            "back to main",
            "display recipe"
            };
            int choice = 0;

            MenuGUI r = new MenuGUI(instruction, options, "");

            choice = r.getSelectedOption();
            return choice;

        }
    }
}
