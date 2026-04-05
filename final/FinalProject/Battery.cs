using System;

abstract class EnergySource
{
    protected double _level;

    public double Level
    {
        get
        {
            return _level;
        }
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
        if (_level >= required)
        {
            return true;
        }
        return false;
    }
}

class Battery : EnergySource
{
    public Battery() : base(100) { }

    public override void Consume(double amount)
    {
        _level -= amount;
        if (_level < 0)
        {
            _level = 0;
        }
    }

    public void Drain(double distance, double weight)
    {
        double usage = distance * 0.1 + distance * weight * 0.02;
        Consume(usage);
    }
}