using System.Collections.Generic;

abstract class Map
{
    public abstract void AddLocation(string name, double x, double y);
    public abstract (double X, double Y) GetCoordinates(string name);
}

class CampusMap : Map
{
    private Dictionary<string, (double X, double Y)> _locations = new Dictionary<string, (double X, double Y)>();

    public override void AddLocation(string name, double x, double y)
    {
        _locations[name] = (x, y);
    }

    public override (double X, double Y) GetCoordinates(string name)
    {
        return _locations[name];
    }
}