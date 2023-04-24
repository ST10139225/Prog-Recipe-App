// See https://aka.ms/new-console-template for more information

using ST10139225_K_Baholo_Part1.Classes;

namespace ST10139225_K_Baholo_Part1.Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Steps> list= new List<Steps>();    
            for (int i = 1; i < 5; i++)
            {
                Steps s = new Steps(i);
               list.Add(s);
            }

            foreach(Steps s in list)
            {
                Console.WriteLine(s.getStep());
            }
        }
    }

}