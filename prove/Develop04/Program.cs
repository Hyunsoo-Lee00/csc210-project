using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Breathing b = new Breathing();
                b.Run();
            }
            else if (choice == "2")
            {
                Reflection r = new Reflection();
                r.Run();
            }
            else if (choice == "3")
            {
                Listing l = new Listing();
                l.Run();
            }
            else if (choice == "4")
            {
                break;
            }
        }
    }
}