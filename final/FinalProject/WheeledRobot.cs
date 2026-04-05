using System;
using System.Threading;

class WheeledRobot : Robot
{
    public WheeledRobot(string name, double x, double y, double speed, Battery battery)
        : base(name, x, y, speed, battery)
    {
    }

    public override void MoveWithProgress(double targetX, double targetY, double weight)
    {
        double distance = GetDistance(targetX, targetY);
        double usage = distance * 0.1 + distance * weight * 0.02;

        if (!_battery.HasEnough(usage))
        {
            Console.WriteLine("\nNot enough battery! Needed: " + usage.ToString("F2") +
                              "%, Current: " + _battery.Level.ToString("F2") + "%");
            return;
        }

        Console.WriteLine("\nWheeled Robot moving...\n");
        for (int i = 1; i <= 10; i++)
        {
            Thread.Sleep(300);
            Console.WriteLine("Progress: " + (i * 10) + "%");
        }

        _battery.Drain(distance, weight);
        Console.WriteLine("\nArrived! Distance: " + distance.ToString("F2") +
                          " m, Battery left: " + _battery.Level.ToString("F2") + "%");

        _x = targetX;
        _y = targetY;
    }
}