using System;
using System.Collections.Generic;

class DeliveryRecord
{
    private string _robotName;
    private string _destination;
    private string _packageType;
    private double _packageWeight;
    private DateTime _time;

    public string RobotName
    {
        get { return _robotName; }
    }

    public string Destination
    {
        get { return _destination; }
    }

    public string PackageType
    {
        get { return _packageType; }
    }

    public double PackageWeight
    {
        get { return _packageWeight; }
    }

    public DateTime Time
    {
        get { return _time; }
    }

    public DeliveryRecord(string robotName, string destination, string packageType, double packageWeight)
    {
        _robotName = robotName;
        _destination = destination;
        _packageType = packageType;
        _packageWeight = packageWeight;
        _time = DateTime.Now;
    }
}

class DeliveryController
{
    private List<DeliveryRecord> _records = new List<DeliveryRecord>();

    public void AddRecord(string robotName, string destination, string packageType, double packageWeight)
    {
        DeliveryRecord record = new DeliveryRecord(robotName, destination, packageType, packageWeight);
        _records.Add(record);
    }

    public void ShowRecords()
    {
        Console.WriteLine("\n=== Delivery Records ===");
        if (_records.Count == 0)
        {
            Console.WriteLine("No deliveries yet.");
        }
        else
        {
            foreach (DeliveryRecord record in _records)
            {
                Console.WriteLine(record.Time + ": " + record.RobotName + " delivered " +
                                  record.PackageType + " (" + record.PackageWeight + "kg) to " + record.Destination);
            }
        }
        Console.WriteLine("========================\n");
    }
}