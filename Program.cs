using System;
using System.Threading;
using TechAssessment.Models;

namespace TechAssessment
{
    class Program
    {
        public static void Main()
        {
            string input = "";
            Colony colony = new Colony(10, 10, 10, 10);
            while (true)
            {
                Console.Clear();

                Console.WriteLine(colony.Display());

                Console.WriteLine("press enter to update colony once, q and confirm to exit");
                input = Console.ReadLine();
                if (input.Equals(""))
                    colony.Update();
                else if (input.Equals("q"))
                    break;
            }

        }
    }
}
