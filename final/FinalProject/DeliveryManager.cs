using System;
using System.Collections.Generic;

class DeliveryManager
{
    private CampusMap _map;
    private Battery _battery;
    private Robot _robot;
    private DeliveryController _controller;
    private string _currentLocation;
    private List<string> _buildings;
    private Dictionary<int, (string, double)> _packages;

    public DeliveryManager()
    {
        // 지도 생성
        _map = new CampusMap();
        _map.AddLocation("MC", 0, 0);
        _map.AddLocation("Hart", -80, 40);
        _map.AddLocation("I-Center", -80, 0);
        _map.AddLocation("Library", -20, 20);
        _map.AddLocation("Romney", -20, 80);
        _map.AddLocation("Smith", 20, 20);
        _map.AddLocation("Taylor", 0, -40);
        _map.AddLocation("Benson", 0, -80);
        _map.AddLocation("STC", -80, -100);

        _buildings = new List<string> { "Hart", "I-Center", "Library", "Romney", "Smith", "Taylor", "Benson", "STC" };

        _packages = new Dictionary<int, (string, double)>
        {
            {1, ("Food",1)}, {2, ("Food",2)}, {3, ("Food",3)},
            {4, ("Supplies",1)}, {5, ("Supplies",2)}, {6, ("Supplies",3)}
        };

        _battery = new Battery();
        _robot = new WheeledRobot("Robo1", 0, 0, 1.5, _battery);
        _controller = new DeliveryController();
        _currentLocation = "MC";
    }

    public void Run()
    {
        while (true)
        {
            _robot.ShowStatus(_currentLocation);

            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Deliver Package");
            Console.WriteLine("2. Recharge Battery");
            Console.WriteLine("3. Show Delivery Records");
            Console.WriteLine("4. Exit");

            string menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                DeliverPackage();
            }
            else if (menuChoice == "2")
            {
                _battery.Recharge();
                Console.WriteLine("\nBattery recharged!");
            }
            else if (menuChoice == "3")
            {
                _controller.ShowRecords();
            }
            else if (menuChoice == "4")
            {
                break;
            }
        }
    }

    private void DeliverPackage()
    {
        Console.WriteLine("\nChoose Destination:");
        for (int i = 0; i < _buildings.Count; i++)
        {
            Console.WriteLine((i + 1) + ". " + _buildings[i]);
        }

        int buildingChoice;
        if (!int.TryParse(Console.ReadLine(), out buildingChoice) || buildingChoice < 1 || buildingChoice > _buildings.Count)
        {
            return;
        }

        string destination = _buildings[buildingChoice - 1];

        Console.WriteLine("\nChoose Package:");
        foreach (var pkg in _packages)
        {
            Console.WriteLine(pkg.Key + ". " + pkg.Value.Item1 + " (" + pkg.Value.Item2 + "kg)");
        }

        int packageChoice;
        if (!int.TryParse(Console.ReadLine(), out packageChoice) || !_packages.ContainsKey(packageChoice))
        {
            return;
        }

        var packageSelected = _packages[packageChoice];
        var coords = _map.GetCoordinates(destination);
        double targetX = coords.X;
        double targetY = coords.Y;

        _robot.ShowEstimate(targetX, targetY, packageSelected.Item2);

        Console.WriteLine("Start delivery? (y/n)");
        string confirm = Console.ReadLine().Trim().ToLower();
        if (confirm == "y")
        {
            _robot.MoveWithProgress(targetX, targetY, packageSelected.Item2);
            _currentLocation = destination;
            _controller.AddRecord(_robot.Name, destination, packageSelected.Item1, packageSelected.Item2);
        }
    }
}