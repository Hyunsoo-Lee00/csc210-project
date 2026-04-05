using System;

abstract class Robot
{
    protected string _name;
    protected double _x;
    protected double _y;
    protected double _speed;
    protected Battery _battery;

    public string Name
    {
        get { return _name; }
    }

    protected Robot(string name, double x, double y, double speed, Battery battery)
    {
        _name = name;
        _x = x;
        _y = y;
        _speed = speed;
        _battery = battery;
    }

    public abstract void MoveWithProgress(double targetX, double targetY, double weight);

    public double GetDistance(double x, double y)
    {
        double dx = x - _x;
        double dy = y - _y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public void ShowStatus(string location)
    {
        Console.WriteLine("\n=== Robot Status ===");
        Console.WriteLine("Location: " + location);
        Console.WriteLine("Position: (" + _x.ToString("F0") + ", " + _y.ToString("F0") + ")");
        Console.WriteLine("Battery: " + _battery.Level.ToString("F2") + "%");
        Console.WriteLine("======================\n");
    }

    public void ShowEstimate(double targetX, double targetY, double weight)
    {
        double distance = GetDistance(targetX, targetY);
        double time = distance / _speed;
        double usage = distance * 0.1 + distance * weight * 0.02;

        Console.WriteLine("\n--- Estimated Info ---");
        Console.WriteLine("Distance: " + distance.ToString("F2") + " m");
        Console.WriteLine("Estimated Time: " + time.ToString("F2") + " s");
        Console.WriteLine("Battery Usage: " + usage.ToString("F2") + "%");
        Console.WriteLine("----------------------\n");
    }
}