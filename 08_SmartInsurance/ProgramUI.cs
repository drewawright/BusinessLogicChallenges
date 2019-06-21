using _08_SmartInsuranceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08_SmartInsurance
{
    class ProgramUI
    {
        private SmartInsuranceRepository _insuranceRepo = new SmartInsuranceRepository();
        public void Run()
        {
            SeedDriverDict();
            RunUI();
        }

        private void RunUI()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Smart Insurance Pilot Program\n" +
                    "What would you like to do today?\n" +
                    "1. See a list of all drivers and their status\n" +
                    "2. See details on a specific driver\n" +
                    "3. Add a new driver to the program\n" +
                    "4. Edit a current driver\n" +
                    "5. Remove a driver from the program\n" +
                    "6. See average driving statistics of program drivers\n" +
                    "7. Exit");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        ShowAllDrivers();
                        break;
                    case "2":
                        ShowOneDriver();
                        break;
                    case "3":
                        AddDriver();
                        break;
                    case "4":
                        UpdateDriver();
                        break;
                    case "5":
                        DeleteDriver();
                        break;
                    case "6":
                        ShowAverage();
                        break;
                    case "7":
                        continueToRun = false;
                        break;
                    case "8":
                        Console.WriteLine("Please enter a number between 1 and 7\n" +
                            "Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllDrivers()
        {
            Console.WriteLine("Driver ID      Driver Name         Safety Status");
            Dictionary<int, Driver> driverList = _insuranceRepo.GetFullDriverDict();
            foreach(KeyValuePair<int, Driver> driver in driverList)
            {
                Console.WriteLine($"{driver.Key}           {driver.Value.DriverName, 15}            {driver.Value.DriverClass}");
            }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void ShowOneDriver()
        {
            Console.Write("Please enter the ID of the driver you would like to view: ");
            int driverID = int.Parse(Console.ReadLine());
            Driver driver = _insuranceRepo.GetOneDriver(driverID);
            Console.WriteLine($"Driver ID: {driver.DriverID}\n" +
                $"Name: {driver.DriverName}\n" +
                $"Monthly Premium: ${driver.Premium}\n" +
                $"Safety Status: {driver.DriverClass}\n" +
                $"Safety Score: {driver.SafetyScore}\n" +
                $"Percentage of time speeding: {driver.DriverData.SpeedingFrequency}%\n" +
                $"Percentage of time out of lane: {driver.DriverData.OutOfLaneFrequency}%\n" +
                $"Percentage of time following too closely: {driver.DriverData.FollowingTooCloselyFrequency}%\n" +
                $"Number of times rolling through stop signs: {driver.DriverData.TimesRollingThroughStopSign}\n" +
                $"----------------------------------------------------------" +
                $"Press any key to continue...");
            Console.ReadKey();
        }

        private void AddDriver()
        {
            Console.Write("Please enter the Driver ID: ");
            int driverID = int.Parse(Console.ReadLine());
            Console.Write("Enter the name of the Driver:");
            string driverName = Console.ReadLine();
            Console.Write("Enter the percentage of time speeding as a whole number: ");
            int timeSpeeding = int.Parse(Console.ReadLine());
            Console.Write("Enter the percentage of time spent out of lane: ");
            int timeOutOfLane = int.Parse(Console.ReadLine());
            Console.Write("Enter the percentage of time following too closely: ");
            int timeClose = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of times rolling through stop signs: ");
            int rollingStop = int.Parse(Console.ReadLine());
            Driver newDriver = new Driver(driverID, driverName, new DriverData(timeSpeeding, timeOutOfLane, timeClose, rollingStop));
            _insuranceRepo.AddDriverToDict(newDriver);
            Console.WriteLine($"{newDriver.DriverName} has a safety score of {newDriver.SafetyScore}.\n" +
                $"They are a {newDriver.DriverClass} driver. Their premium will be {newDriver.Premium}\n" +
                $"Press any key to continue...");
            Console.ReadKey();
        }

        public void UpdateDriver() 
        {
            Console.Write("Enter the current ID of the driver to update: ");
            int oldID = int.Parse(Console.ReadLine());
            Console.WriteLine("Would you like to update: \n" +
                "1. The full driver entry\n" +
                "2. Just the data for a specific driver");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.Write("Enter the new Driver ID: ");
                    int newID = int.Parse(Console.ReadLine());
                    Console.Write("Enter the new Driver Name: ");
                    string newName = Console.ReadLine();
                    Console.Write("Enter the percentage of time speeding as a whole number: ");
                    int timeSpeeding = int.Parse(Console.ReadLine());
                    Console.Write("Enter the percentage of time spent out of lane: ");
                    int timeOutOfLane = int.Parse(Console.ReadLine());
                    Console.Write("Enter the percentage of time following too closely: ");
                    int timeClose = int.Parse(Console.ReadLine());
                    Console.Write("Enter the number of times rolling through stop signs: ");
                    int rollingStop = int.Parse(Console.ReadLine());
                    Driver newDriver = new Driver(newID, newName, new DriverData(timeSpeeding, timeOutOfLane, timeClose, rollingStop));
                    _insuranceRepo.EditDriver(oldID, newDriver);
                    break;
                case "2":
                    Console.Write("Enter the percentage of time speeding as a whole number: ");
                    int newSpeeding = int.Parse(Console.ReadLine());
                    Console.Write("Enter the percentage of time spent out of lane: ");
                    int newOutOfLane = int.Parse(Console.ReadLine());
                    Console.Write("Enter the percentage of time following too closely: ");
                    int newClose = int.Parse(Console.ReadLine());
                    Console.Write("Enter the number of times rolling through stop signs: ");
                    int newRollingStop = int.Parse(Console.ReadLine());
                    DriverData newData = new DriverData(newSpeeding, newOutOfLane, newClose, newRollingStop);
                    break;
                default:
                    Console.WriteLine("Please enter 1 or 2");
                    break;
            }
            Console.WriteLine("Driver updated\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void DeleteDriver()
        {
            Console.Write("Enter the ID of the driver to remove: ");
            int deleteID = int.Parse(Console.ReadLine());
            _insuranceRepo.RemoveDriverFromDict(deleteID);
            Console.WriteLine("Driver deleted\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        private void ShowAverage()
        {
            List<DriverData> driverData = _insuranceRepo.GetDriverData();
            DriverData average = _insuranceRepo.GetAverageData(driverData);
            Driver averageDriver = new Driver(999999, "average", average);
            Console.WriteLine($"On average our drivers are {averageDriver.DriverClass}.\n" +
                $"Average percentage of time speeding: {average.SpeedingFrequency}%\n" +
                $"Average percentage of time spent out of lane: {average.OutOfLaneFrequency}%\n" +
                $"Average percentage of time spent following too closely: {average.FollowingTooCloselyFrequency}%\n" +
                $"Average number of times rolling through stop signs: {average.TimesRollingThroughStopSign}\n" +
                $"Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedDriverDict()
        {
            Driver driverOne = new Driver(00001, "John Smith", new DriverData(10, 1, 3, 5));
            Driver driverTwo = new Driver(00002, "Eric Jones", new DriverData(5, 0, 1, 2));
            Driver driverThree = new Driver(00003, "John Smith-Jones", new DriverData(3, 3, 1, 1));

            _insuranceRepo.AddDriverToDict(driverOne);
            _insuranceRepo.AddDriverToDict(driverTwo);
            _insuranceRepo.AddDriverToDict(driverThree);
        }
    }
}
