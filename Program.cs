// See https://aka.ms/new-console-template for more information

using ST10139225_K_Baholo_Part1.Classes;

namespace ST10139225_K_Baholo_Part1.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Recipe> list= new List<Recipe>();    
            for (int i = 0; i <1; i++)
            {
                Recipe s = new Recipe();
               list.Add(s);
            }

            foreach(Recipe s in list)
            {
                s.printRecipe();
            }
        }
    }

}