
using system;
public abstract class ToolVehicle
{
    // Instance properties
    public int VehicleID { get; set; }
    public string RegNo { get; set; }
    public string Model { get; set; }
    public string Brand { get; set; }
    public decimal BasePrice { get; set; }
    public string VehicleType { get; set; }

    // Static properties
    public static int TotalVehicles { get; private set; }
    public static int TotalTaxPayingVehicles { get; private set; }
    public static int TotalNonTaxPayingVehicles { get; private set; }
    public static decimal TotalTaxCollected { get; private set; }

    // Constructor
    public ToolVehicle(int vehicleID, string regNo, string model, string brand, decimal basePrice, string vehicleType)
    {
        VehicleID = vehicleID;
        RegNo = regNo;
        Model = model;
        Brand = brand;
        BasePrice = basePrice;
        VehicleType = vehicleType;
        TotalVehicles++;
    }

    // Abstract method to be implemented by derived classes

    public abstract void PayTax();

    // Method to be called when a vehicle passes without paying tax

    public void PassWithoutPaying()
    {
        TotalNonTaxPayingVehicles++;
    }

    // Method to update the tax statistics
    protected void UpdateTaxStatistics(decimal taxAmount)
    {
        TotalTaxCollected += taxAmount;
        TotalTaxPayingVehicles++;
    }
}


//Car Class


public class Car : ToolVehicle
{
    public Car(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Car")
    {
    }

    // Override PayTax method
    public override void PayTax()
    {
        decimal taxAmount = 2m; // Tax amount for cars is $2
        UpdateTaxStatistics(taxAmount);
    }
}


//bike class

public class Bike : ToolVehicle
{
    public Bike(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Bike")
    {
    }

    // Override PayTax method
    public override void PayTax()
    {
        decimal taxAmount = 1m; // Tax amount for bikes is $1
        UpdateTaxStatistics(taxAmount);
    }
}


//heavy_big vehicle


public class HeavyVehicle : ToolVehicle
{
    public HeavyVehicle(int vehicleID, string regNo, string model, string brand, decimal basePrice)
        : base(vehicleID, regNo, model, brand, basePrice, "Heavy Vehicle")
    {
    }

    // Override PayTax method
    public override void PayTax()
    {
        decimal taxAmount = 4m; // Tax amount for heavy vehicles is $4
        UpdateTaxStatistics(taxAmount);
    }
}



//Testing the Implementation


public class Program
{
    public static void Main()
    {
        Car car1 = new Car(1, "ABC456", "TOYOTA", "landcruser", 80000);
        Car car2 = new Car(2, "ABC456", "extreme", "toyota corola", 80000);
        Car car3= new Car(3, "ABC456", "city", "honda", 80000);
        Bike bike1 = new Bike(4, "XYZ789", "honda", "cd 125", 2000);
        Bike bike2 = new Bike(5, "XYZ655", "yamaha", "r2", 2000);
        Bike bike3 = new Bike(6, "XYZ789", "honda", "cd 150", 2000);
        Bike bike4 = new Bike(7, "XYZ655", "suzuki", "150", 2000);
        HeavyVehicle heavyVehicle1 = new HeavyVehicle(7, "LMN456", "mazda", "truck", 120000);
        HeavyVehicle heavyVehicle2 = new HeavyVehicle(8, "LMN456", "mazda", "buldozer", 120000);


        car1.PassWithoutPaying();
        car2.PayTax();
        car3.PayTax();

        bike1.PassWithoutPaying();
        bike2.PayTax();
        heavyVehicle1.PayTax();
        heavyVehicle2.PayTax();

        Console.WriteLine("Total Vehicles: " + ToolVehicle.TotalVehicles);
        Console.WriteLine("Total Tax Paying Vehicles: " + ToolVehicle.TotalTaxPayingVehicles);
        Console.WriteLine("Total Non-Tax Paying Vehicles: " + ToolVehicle.TotalNonTaxPayingVehicles);
        Console.WriteLine("Total Tax Collected: " + ToolVehicle.TotalTaxCollected);
        
    }
}

