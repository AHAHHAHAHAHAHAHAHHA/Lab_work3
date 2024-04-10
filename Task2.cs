using System;

class Bus
{
    public string NumberPlate { get; set; }
    public int Seats { get; set; }
    public double FuelConsumption { get; set; }

    public Bus(string numberPlate, int seats, double fuelConsumption)
    {
        NumberPlate = numberPlate;
        Seats = seats;
        FuelConsumption = fuelConsumption;
    }

    public override string ToString()
    {
        return $"Автобус з номерним знаком {NumberPlate}, кількістю місць {Seats} та споживанням пального {FuelConsumption} л/100км";
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Bus other = (Bus)obj;
        return NumberPlate == other.NumberPlate;
    }

    public override int GetHashCode()
    {
        return NumberPlate.GetHashCode();
    }
}

class ShuttleBus : Bus
{
    public int PassengerCapacity { get; set; }

    public ShuttleBus(string numberPlate, int seats, double fuelConsumption, int passengerCapacity) 
        : base(numberPlate, seats, fuelConsumption)
    {
        PassengerCapacity = passengerCapacity;
    }

    public override string ToString()
    {
        return base.ToString() + $" і вмістимістю для пасажирів {PassengerCapacity}";
    }
}

class BusStation
{
    private Bus[] buses;

    public BusStation(Bus[] buses)
    {
        this.buses = buses;
    }

    public int TotalBuses()
    {
        return buses.Length;
    }

    public void SortBusesBySeats()
    {
        Array.Sort(buses, (x, y) => x.Seats.CompareTo(y.Seats));
    }

    public Bus FindBusByNumberPlate(string numberPlate)
    {
        foreach (var bus in buses)
        {
            if (bus.NumberPlate == numberPlate)
            {
                return bus;
            }
        }
        return null;
    }

    public Bus FindBusByFuelConsumption(double fuelConsumption)
    {
        foreach (var bus in buses)
        {
            if (bus.FuelConsumption == fuelConsumption)
            {
                return bus;
            }
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Bus[] buses = {
            new Bus("AB1234CD", 50, 15.5),
            new ShuttleBus("EF5678GH", 30, 20.0, 20),
            new Bus("IJ9012KL", 40, 18.2),
            new ShuttleBus("MN3456OP", 25, 22.5, 15)
        };

        BusStation station = new BusStation(buses);

        Console.WriteLine($"Загальна кількість автобусів на станції: {station.TotalBuses()}");
        station.SortBusesBySeats();
        Console.WriteLine("Сортування автобусів за кількістю місць завершено.");

        Console.WriteLine("\nПошук автобусу за номерним знаком:");
        string searchNumberPlate = "AB1234CD";
        Bus foundBus = station.FindBusByNumberPlate(searchNumberPlate);
        if (foundBus != null)
            Console.WriteLine($"Знайдено автобус: {foundBus}");
        else
            Console.WriteLine($"Автобус з номерним знаком {searchNumberPlate} не знайдено.");

        Console.WriteLine("\nПошук автобусу за параметрами споживання пального:");
        double searchFuelConsumption = 20.0;
        foundBus = station.FindBusByFuelConsumption(searchFuelConsumption);
        if (foundBus != null)
            Console.WriteLine($"Знайдено автобус: {foundBus}");
        else
            Console.WriteLine($"Автобус з параметром споживання пального {searchFuelConsumption} не знайдено.");
    }
}

