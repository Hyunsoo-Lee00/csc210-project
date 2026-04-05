class Customer
{
    private string _location;

    public string Location
    {
        get { return _location; }
    }

    public Customer(string location)
    {
        _location = location;
    }
}