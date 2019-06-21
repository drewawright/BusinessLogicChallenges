using _06_GreenPlanRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class ProgramUI
    {
        private GreenPlanRepository _carsList = new GreenPlanRepository();

        public void Run()
        {
            SeedCarList();
            RunUI();
        }

        private void RunUI()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Green Plan Cars Database\n" +
                    "What would you like to do?\n" +
                    "1. See the full cars list\n" +
                    "2. Add a new car to the list\n" +
                    "3. Remove a car from the list\n" +
                    "4. Update a car on the list\n" +
                    "5. Exit");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        ShowList();
                        break;
                    case "2":
                        AddCar();
                        break;
                    case "3":
                        RemoveCar();
                        break;
                    case "4":
                        UpdateCarOnList();
                        break;
                    case "5":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 5\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowList()
        {
            Console.WriteLine("Which list would you like to see: \n" +
                "1. All cars\n" +
                "2. Electric cars\n" +
                "3. Hybrid cars\n" +
                "4. Gas cars");
            string listChoice = Console.ReadLine();
            List<ICar> carList = _carsList.GetCarsList();
            switch (listChoice)
            {
                case "1":
                    carList.Sort();
                    foreach (ICar car in carList)
                    {
                        Console.WriteLine($"{car.Make} {car.Model} {car.TypeOfFuel} {car.MPG} {car.Price} {car.NumberOfDrivers} ");
                    }
                    break;
                case "2":
                    Console.WriteLine("Electric Cars: ");
                    foreach (ICar eCar in carList)
                    {
                        if (eCar.TypeOfFuel == FuelType.Electric)
                        {
                            Console.WriteLine($"{eCar.Make} {eCar.Model} - {eCar.MPG} {eCar.Price} {eCar.NumberOfDrivers}");
                        }
                    }
                    break;
                case "3":
                    Console.WriteLine("Hybrid Cars: ");
                    foreach (ICar hCar in carList)
                    {
                        if (hCar.TypeOfFuel == FuelType.Hybrid)
                        {
                            Console.WriteLine($"{hCar.Make} {hCar.Model} - {hCar.MPG} {hCar.Price} {hCar.NumberOfDrivers}");
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine("Gas Cars: ");
                    foreach (ICar gCar in carList)
                    {
                        if (gCar.TypeOfFuel == FuelType.Gas)
                        {
                            Console.WriteLine($"{gCar.Make} {gCar.Model} - {gCar.MPG} {gCar.Price} {gCar.NumberOfDrivers}");
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Please enter a number between 1 and 4");
                    break;
            }
                                Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
        }

        private void AddCar()
        {
            Console.Write("Please enter the make of the car you'd like to add: ");
            string make = Console.ReadLine();
            Console.Write("Please enter the model of the car you'd like to add: ");
            string model = Console.ReadLine();
            Console.Write("How many miles per gallon does this car get? (or electric charge equivalent): ");
            double mpg = double.Parse(Console.ReadLine());
            Console.Write("What is the price of the car?: $");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("How many customers drive this car?: ");
            int numberOfDrivers = int.Parse(Console.ReadLine());
            Console.Write("Is this car electric, hybrid, or gas?: ");
            string carType = Console.ReadLine();
            if (carType.ToLower() == "electric")
            {
                ElectricCar eCar = new ElectricCar(make, model, mpg, price, numberOfDrivers);
                _carsList.AddCarToList(eCar);
            }
            else if(carType.ToLower() == "hybrid")
            {
                HybridCar hCar = new HybridCar(make, model, mpg, price, numberOfDrivers);
                _carsList.AddCarToList(hCar);
            }
            else if (carType.ToLower() == "gas")
            {
                GasCar gCar = new GasCar(make, model, mpg, price, numberOfDrivers);
                _carsList.AddCarToList(gCar);
            }
            else
            {
                Console.WriteLine("Please enter electric, hybrid, or gas");
            }
            Console.WriteLine("Car added\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void RemoveCar()
        {
            Console.WriteLine("Please enter the model name of the car you would like to remove:");
            string model = Console.ReadLine();
            _carsList.DeleteCarFromList(model);
            Console.WriteLine("Car removed from the list\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void UpdateCarOnList()
        {
            Console.Write("Please enter the current model name of the car you'd like to update: ");
            string oldModel = Console.ReadLine();
            Console.Write("Please enter the new make of the car you'd like to update: ");
            string make = Console.ReadLine();
            Console.Write("Please enter the new model of the car you'd like to update: ");
            string model = Console.ReadLine();
            Console.Write("How many miles per gallon does this updated car get? (or electric charge equivalent): ");
            double mpg = double.Parse(Console.ReadLine());
            Console.Write("What is the new price of the car?: $");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("How many customers now drive this car?: ");
            int numberOfDrivers = int.Parse(Console.ReadLine());
            Console.Write("What type of car is being updated (electric, hybrid, or gas)?: ");
            string carType = Console.ReadLine();
            if (carType.ToLower() == "electric")
            {
                ElectricCar eCar = new ElectricCar(make, model, mpg, price, numberOfDrivers);
                _carsList.UpdateCarOnList(oldModel, eCar);
            }
            else if (carType.ToLower() == "hybrid")
            {
                HybridCar hCar = new HybridCar(make, model, mpg, price, numberOfDrivers);
                _carsList.UpdateCarOnList(oldModel, hCar);
            }
            else if (carType.ToLower() == "gas")
            {
                GasCar gCar = new GasCar(make, model, mpg, price, numberOfDrivers);
                _carsList.UpdateCarOnList(oldModel, gCar);
            }
            else
            {
                Console.WriteLine("Please enter electric, hybrid, or gas");
            }
            Console.WriteLine("Car added\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedCarList()
        {
            HybridCar carOne = new HybridCar("Nissan", "Blend", 85.99d, 17500.50m, 3);
            HybridCar carTwo = new HybridCar("Toyota", "Prius", 85.00d, 18000.00m, 25);
            GasCar carThree = new GasCar("Nissan", "Versa", 32.5d, 140000.00m, 14);
            GasCar carFour = new GasCar("Scion", "xD", 26d, 135000.00m, 4);
            ElectricCar carFive = new ElectricCar("Tesla", "Model S", 154.0d, 390000.00m, 10);
            ElectricCar carSix = new ElectricCar("Chevrolet", "Bolt", 95.0d, 360000.00m, 25);

            _carsList.AddCarToList(carOne);
            _carsList.AddCarToList(carTwo);
            _carsList.AddCarToList(carThree);
            _carsList.AddCarToList(carFour);
            _carsList.AddCarToList(carFive);
            _carsList.AddCarToList(carSix);
        }
    }
}

