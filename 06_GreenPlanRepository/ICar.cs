using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlanRepository
{
    public enum FuelType
    {
        Electric=1,
        Hybrid,
        Gas,
    }

    public interface ICar : IComparable<ICar>
    {
        string Make { get; set; }
        string Model { get; set; }
        double MPG { get; set; }
        decimal Price { get; set; }
        int NumberOfDrivers { get; set; }
        FuelType TypeOfFuel { get; }
    }

    public class ElectricCar : ICar, IComparable<ICar>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double MPG { get; set; }
        public decimal Price { get; set; }
        public int NumberOfDrivers { get; set; }
        public FuelType TypeOfFuel { get { return FuelType.Electric; } }

        public ElectricCar() { }

        public ElectricCar(string make, string model, double mpg, decimal price, int numberOfDrivers)
        {
            Make = make;
            Model = model;
            MPG = mpg;
            Price = price;
            NumberOfDrivers = numberOfDrivers; 
        }

        public int CompareTo(ICar other)
        {
            int ret = TypeOfFuel.CompareTo(other.TypeOfFuel);
            return ret;
        }
    }

    public class HybridCar : ICar, IComparable<ICar>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double MPG { get; set; }
        public decimal Price { get; set; }
        public int NumberOfDrivers { get; set; }
        public FuelType TypeOfFuel { get { return FuelType.Hybrid; } }

        public HybridCar() { }

        public HybridCar(string make, string model, double mpg, decimal price, int numberOfDrivers)
        {
            Make = make;
            Model = model;
            MPG = mpg;
            Price = price;
            NumberOfDrivers = numberOfDrivers;
        }

        public int CompareTo(ICar other)
        {
            int ret = TypeOfFuel.CompareTo(other.TypeOfFuel);
            return ret;
        }
    }

    public class GasCar : ICar, IComparable<ICar>
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double MPG { get; set; }
        public decimal Price { get; set; }
        public int NumberOfDrivers { get; set; }
        public FuelType TypeOfFuel { get { return FuelType.Gas; } }

        public GasCar() { }

        public GasCar(string make, string model, double mpg, decimal price, int numberOfDrivers)
        {
            Make = make;
            Model = model;
            MPG = mpg;
            Price = price;
            NumberOfDrivers = numberOfDrivers;
        }

        public int CompareTo(ICar other)
        {
            int ret = TypeOfFuel.CompareTo(other.TypeOfFuel);
            return ret;
        }
    }
}
