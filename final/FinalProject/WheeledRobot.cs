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
        double time = distance / Speed;
        double usage = distance * 0.1 + distance * weight * 0.02;

        if (!Battery.HasEnough(usage))
        {
            Console.WriteLine($"\n Not enough battery! Needed: {usage:F2}%, Current: {Battery.Level:F2}%");
            return;
        }

        Console.WriteLine("\n Wheeled Robot moving...\n");
        for (int i = 1; i <= 10; i++)
        {
            Thread.Sleep(300);
            Console.WriteLine($"Progress: {i * 10}%");
        }

        Battery.Drain(distance, weight);
        Console.WriteLine($"\n Arrived! Distance: {distance:F2} m, Time: {time:F2} s, Battery left: {Battery.Level:F2}%");

        X = targetX;
        Y = targetY;
    }
}