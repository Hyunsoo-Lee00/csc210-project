using System;

abstract class Robot
{
    public string Name;
    protected double X, Y;
    protected double Speed;
    protected Battery Battery;

    public Robot(string name, double x, double y, double speed, Battery battery)
    {
        Name = name;
        X = x;
        Y = y;
        Speed = speed;
        Battery = battery;
    }

    public abstract void MoveWithProgress(double targetX, double targetY, double weight);

    public double GetDistance(double x, double y) => Math.Sqrt(Math.Pow(x - X, 2) + Math.Pow(y - Y, 2));

    public void ShowStatus(string location)
    {
        Console.WriteLine($"\n=== Robot Status ===");
        Console.WriteLine($"Location: {location}");
        Console.WriteLine($"Position: ({X:F0}, {Y:F0})");
        Console.WriteLine($"Battery: {Battery.Level:F2}%");
        Console.WriteLine("======================\n");
    }

    public void ShowEstimate(double targetX, double targetY, double weight)
    {
        double distance = GetDistance(targetX, targetY);
        double time = distance / Speed;
        double usage = distance * 0.1 + distance * weight * 0.02;

        Console.WriteLine("\n--- Estimated Info ---");
        Console.WriteLine($"Distance: {distance:F2} m");
        Console.WriteLine($"Estimated Time: {time:F2} s");
        Console.WriteLine($"Battery Usage: {usage:F2}%");
        Console.WriteLine("----------------------\n");
    }
}