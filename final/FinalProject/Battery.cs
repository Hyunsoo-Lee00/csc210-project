using System;

class Battery
{
    private double level;

    public double Level
    {
        get
        {
            return level;
        }
    }

    public Battery()
    {
        level = 100;
    }

    public void Drain(double distance, double weight)
    {
        double usage = distance * 0.1 + distance * weight * 0.02;
        level -= usage;
        if (level < 0)
        {
            level = 0;
        }
    }

    public bool HasEnough(double required)
    {
        return level >= required;
    }

    public void Recharge()
    {
        level = 100;
    }
}