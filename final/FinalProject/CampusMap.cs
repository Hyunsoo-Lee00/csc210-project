using System.Collections.Generic;

class CampusMap
{
    private Dictionary<string, (double, double)> buildings = new();

    public void AddBuilding(string name, double x, double y) => buildings[name] = (x, y);

    public (double, double) GetCoordinates(string name) => buildings[name];
}