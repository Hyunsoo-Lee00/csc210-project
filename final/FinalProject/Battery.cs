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