using System;
using System.Collections.Generic;

class DeliveryRecord
{
    public string RobotName;
    public string Destination;
    public string PackageType;
    public double PackageWeight;
    public DateTime Time;
}

class DeliveryController
{
    private List<DeliveryRecord> _records = new List<DeliveryRecord>();

    public void AddRecord(string robotName, string destination, string packageType, double packageWeight)
    {
        DeliveryRecord record = new DeliveryRecord();
        record.RobotName = robotName;
        record.Destination = destination;
        record.PackageType = packageType;
        record.PackageWeight = packageWeight;
        record.Time = DateTime.Now;

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
            foreach (DeliveryRecord r in _records)
            {
                Console.WriteLine(r.Time + ": " + r.RobotName + " delivered " +
                                  r.PackageType + " (" + r.PackageWeight + "kg) to " + r.Destination);
            }
        }
        Console.WriteLine("========================\n");
    }
}