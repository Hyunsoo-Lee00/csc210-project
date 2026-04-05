using System;

abstract class EnergySource
{
    protected double _level;

    public double Level
    {
        get { return _level; }
    }

    protected EnergySource(double initialLevel)
    {
        _level = initialLevel;
    }

    public abstract void Consume(double amount);

    public virtual void Recharge()
    {
        _level = 100;
    }

    public bool HasEnough(double required)
    {
        return _level >= required;
    }
}