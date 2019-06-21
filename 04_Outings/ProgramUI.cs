using _04_OutingsRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings
{
    public class ProgramUI
    {
        private OutingsRepository _outingsRepo = new OutingsRepository();

        public void Run()
        {
            SeedList();
            RunUI();
        }

        private void RunUI()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Outings Management System\n" +
                    "What would you like to do?\n" +
                    "1. Show a List of All Outings\n" +
                    "2. Add a new Outing\n" +
                    "3. Display the Cost of Outings\n" +
                    "4. Exit");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        ShowAllOutings();
                        break;
                    case "2":
                        AddOutingToList();
                        break;
                    case "3":
                        CalculateCost();
                        break;
                    case "4":
                        continueToRun = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a number between 1 and 4");
                        break;
                }
            }
        }

        private void ShowAllOutings()
        {
            Console.WriteLine("Type of Outing   Date    Nubmer Attending    Cost per Person Total Cost ");
            List<Outing> outingsList = _outingsRepo.GetListOfOutings();
            foreach (Outing outing in outingsList)
            {
                Console.WriteLine($"{outing.OutingTypeName}     {outing.EventDate}  {outing.NumberAttending}    ${outing.CostPerPerson}  ${outing.TotalCost} ");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void AddOutingToList()
        {
            Outing newOuting = new Outing();
            Console.Write("What type of outing would you like to add (Golf, Bowling, Amusement Park, or Concert)? ");
            newOuting.OutingTypeName = Console.ReadLine();
            Console.Write("What is the date of the outing? ");
            newOuting.EventDate = DateTime.Parse(Console.ReadLine());
            Console.Write("How many people will be attending? ");
            newOuting.NumberAttending = int.Parse(Console.ReadLine());
            Console.WriteLine($"This {newOuting.OutingTypeName} for {newOuting.NumberAttending} people on {newOuting.EventDate} will cost ${newOuting.CostPerPerson} per person for a total of {newOuting.TotalCost}\n" +
                $"Press any key to continue...");
            _outingsRepo.AddOutingToList(newOuting);
            Console.ReadKey();
        }

        private void CalculateCost()
        {
            Console.WriteLine("Would you like to calculate the cost for:\n" +
                "1. All outings\n" +
                "2. All outings of a certain type"  );
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    decimal allCost = _outingsRepo.GetCostOfAllOutings();
                    Console.WriteLine($"The cost of all outings is ${allCost}.");
                    break;
                case "2":
                    Console.WriteLine("Which type of outing would you like to know the current total cost of?\n" +
                        "Enter the number of your choice\n" +
                        "1 = Golf, 2 = Bowling, 3 = Amusement Park, 4 = Concert");
                    int userEventType = int.Parse(Console.ReadLine());
                    decimal typeCost = _outingsRepo.GetCostOfOutingsType((OutingType)userEventType);
                    Console.WriteLine($"The cost of all {(OutingType)userEventType} outings is {typeCost}");
                    break;
                default:
                    Console.WriteLine("Please enter 1 or 2");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedList()
        {
            Outing outingOne = new Outing("Golf", new DateTime(2019, 3, 17), 125);
            Outing outingTwo = new Outing("Amusement Park", new DateTime(2019, 5, 25), 35);
            Outing outingThree = new Outing("Golf", new DateTime(2019, 4, 7), 25);
            _outingsRepo.AddOutingToList(outingOne);
            _outingsRepo.AddOutingToList(outingTwo);
           _outingsRepo.AddOutingToList(outingThree);
        }
    }
}
