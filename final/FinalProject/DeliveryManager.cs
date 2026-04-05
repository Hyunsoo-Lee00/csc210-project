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

            switch (menuChoice)
            {
                case "1":
                    DeliverPackage();
                    break;
                case "2":
                    _battery.Recharge();
                    Console.WriteLine("\nBattery recharged!");
                    break;
                case "3":
                    _controller.ShowRecords();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    private void DeliverPackage()
    {
        string destination = ChooseDestination();
        if (destination == null) return;

        DeliveryPackage packageSelected = ChoosePackage();
        if (packageSelected == null) return;

        var coords = _map.GetCoordinates(destination);
        _robot.ShowEstimate(coords.X, coords.Y, packageSelected.Weight);

        Console.WriteLine("Start delivery? (y/n)");
        if (Console.ReadLine().Trim().ToLower() != "y") return;

        _robot.MoveWithProgress(coords.X, coords.Y, packageSelected.Weight);
        _controller.AddRecord(_robot.Name, destination, packageSelected.Type, packageSelected.Weight);

        ReturnToMC();
    }

    private string ChooseDestination()
    {
        Console.WriteLine("\nChoose Destination:");
        for (int i = 0; i < _buildings.Count; i++)
            Console.WriteLine($"{i + 1}. {_buildings[i]}");

        if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > _buildings.Count)
            return null;

        return _buildings[choice - 1];
    }

    private DeliveryPackage ChoosePackage()
    {
        Console.WriteLine("\nChoose Package:");
        foreach (var pkg in _packages)
            Console.WriteLine($"{pkg.Key}. {pkg.Value.Item1} ({pkg.Value.Item2}kg)");

        if (!int.TryParse(Console.ReadLine(), out int choice) || !_packages.ContainsKey(choice))
            return null;

        var selected = _packages[choice];
        return new DeliveryPackage(selected.Item1, selected.Item2);
    }

    private void ReturnToMC()
    {
        var mcCoords = _map.GetCoordinates("MC");
        Console.WriteLine("\nReturning to MC for next delivery...");
        _robot.MoveWithProgress(mcCoords.X, mcCoords.Y, 0);
        _currentLocation = "MC";
    }
}