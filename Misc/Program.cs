using System;

namespace Misc
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.Write("\n\t1.HeightChecker");
                Console.Write("\n\t2.LongPressedName");
                Console.Write("\n\t3."); 
                Console.Write("\n\t4.");
                Console.Write("\n\t0:Exit\nEnter Choice: ");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        HeightChecker.Demo();
                        break;
                    case "2":
                        LongPressedName.Demo();
                        break;
                    case "3":
                        HeightChecker.Demo();
                        break;
                    case "4":
                        HeightChecker.Demo();
                        break;
                    case "0":
                        return;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }            
            
        }
    }
}
