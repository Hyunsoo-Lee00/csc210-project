using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        CampusMap map = new CampusMap();
        map.AddLocation("MC", 0, 0);
        map.AddLocation("Hart", -80, 40);
        map.AddLocation("I-Center", -80, 0);
        map.AddLocation("Library", -20, 20);
        map.AddLocation("Romney", -20, 80);
        map.AddLocation("Smith", 20, 20);
        map.AddLocation("Taylor", 0, -40);
        map.AddLocation("Benson", 0, -80);
        map.AddLocation("STC", -80, -100);

        List<string> buildings = new List<string> { "Hart","I-Center","Library","Romney","Smith","Taylor","Benson","STC" };
        Dictionary<int, (string, double)> packages = new Dictionary<int, (string, double)>
        {
            {1, ("Food",1)}, {2, ("Food",2)}, {3, ("Food",3)},
            {4, ("Supplies",1)}, {5, ("Supplies",2)}, {6, ("Supplies",3)}
        };

        Battery battery = new Battery();
        Robot robot = new WheeledRobot("Robo1", 0, 0, 1.5, battery);
        DeliveryController controller = new DeliveryController();
        string currentLocation = "MC";

        while (true)
        {
            robot.ShowStatus(currentLocation);

            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Deliver Package");
            Console.WriteLine("2. Recharge Battery");
            Console.WriteLine("3. Show Delivery Records");
            Console.WriteLine("4. Exit");

            string menu = Console.ReadLine();

            if (menu == "1")
            {
                Console.WriteLine("\nChoose Destination:");
                for (int i = 0; i < buildings.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + buildings[i]);
                }

                int b;
                if (!int.TryParse(Console.ReadLine(), out b) || b < 1 || b > buildings.Count)
                {
                    continue;
                }

                string dest = buildings[b - 1];

                Console.WriteLine("\nChoose Package:");
                foreach (var p in packages)
                {
                    Console.WriteLine(p.Key + ". " + p.Value.Item1 + " (" + p.Value.Item2 + "kg)");
                }

                int pChoice;
                if (!int.TryParse(Console.ReadLine(), out pChoice) || !packages.ContainsKey(pChoice))
                {
                    continue;
                }

                var pkg = packages[pChoice];
                var coords = map.GetCoordinates(dest);
                double x = coords.X;
                double y = coords.Y;

                robot.ShowEstimate(x, y, pkg.Item2);

                Console.WriteLine("Start delivery? (y/n)");
                string confirm = Console.ReadLine().Trim().ToLower();
                if (confirm == "y")
                {
                    robot.MoveWithProgress(x, y, pkg.Item2);
                    currentLocation = dest;
                    controller.AddRecord(robot.Name, dest, pkg.Item1, pkg.Item2);
                }
            }
            else if (menu == "2")
            {
                battery.Recharge();
                Console.WriteLine("\nBattery recharged!");
            }
            else if (menu == "3")
            {
                controller.ShowRecords();
            }
            else if (menu == "4")
            {
                break;
            }
        }
    }
}