// See https://aka.ms/new-console-template for more information

using ST10139225_K_Baholo_Part1.Classes;

namespace ST10139225_K_Baholo_Part1.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            //This for decoration
            String instruction = @"
    
██████╗░███████╗░█████╗░██╗██████╗░███████╗      ░█████╗░██████╗░██████╗░
██╔══██╗██╔════╝██╔══██╗██║██╔══██╗██╔════╝      ██╔══██╗██╔══██╗██╔══██╗
██████╔╝█████╗░░██║░░╚═╝██║██████╔╝█████╗░░      ███████║██████╔╝██████╔╝
██╔══██╗██╔══╝░░██║░░██╗██║██╔═══╝░██╔══╝░░      ██╔══██║██╔═══╝░██╔═══╝░
██║░░██║███████╗╚█████╔╝██║██║░░░░░███████╗      ██║░░██║██║░░░░░██║░░░░░
╚═╝░░╚═╝╚══════╝░╚════╝░╚═╝╚═╝░░░░░╚══════╝      ╚═╝░░╚═╝╚═╝░░░░░╚═╝░░░░░
                    Use the Up/Dowen arrow or W/S or I/K keys";
            String[] options =
            {
            "Enter new Recipes",
            "Select a Recipe",
            "Clear all Data"
            };
            int choice = 0;

           MenuGUI r = new MenuGUI(instruction,options);

           choice= r.getSelectedOption();





        }
    }

}