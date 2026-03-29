using System;
using System.Collections.Generic;

class DeliveryController
{
    private List<DeliveryRecord> records = new();

    public void AddRecord(string robotName, string destination, string packageType, double packageWeight)
    {
        records.Add(new DeliveryRecord
        {
            RobotName = robotName,
            Destination = destination,
            PackageType = packageType,
            PackageWeight = packageWeight,
            Time = DateTime.Now
        });
    }

    public void ShowRecords()
    {
        Console.WriteLine("\n===  Delivery Records ===");
        if (records.Count == 0)
        {
            Console.WriteLine("No deliveries yet.");
        }
        else
        {
            foreach (var r in records)
                Console.WriteLine($"{r.Time}: {r.RobotName} delivered {r.PackageType} ({r.PackageWeight}kg) to {r.Destination}");
        }
        Console.WriteLine("============================\n");
    }

    private class DeliveryRecord
    {
        public string RobotName;
        public string Destination;
        public string PackageType;
        public double PackageWeight;
        public DateTime Time;
    }
}