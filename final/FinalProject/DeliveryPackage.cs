class DeliveryPackage
{
    private string _type;
    private double _weight;

    public string Type
    {
        get { return _type; }
    }

    public double Weight
    {
        get { return _weight; }
    }

    public DeliveryPackage(string type, double weight)
    {
        _type = type;
        _weight = weight;
    }
}