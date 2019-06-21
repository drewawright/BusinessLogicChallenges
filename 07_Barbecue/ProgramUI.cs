using _07_BarbecueRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_Barbecue
{
    class ProgramUI
    {
        private BarbacueRepository _partyRepo = new BarbacueRepository();

        public void Run()
        {
            SeedPartyList();
            RunUI();
        }

        private void RunUI()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Party Management System\n" +
                    "What would you like to do today?\n" +
                    "1. See a list of all past parties\n" +
                    "2. Show cost breakdown for a specific party\n" +
                    "3. Add a new party\n" +
                    "4. Edit an existing party\n" +
                    "5. Remove a party from the list\n" +
                    "6. Exit");
                string userChoice = Console.ReadLine();
                switch (userChoice)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        Breakdown();
                        break;
                    case "3":
                        AddNewParty();
                        break;
                    case "4":
                        EditParty();
                        break;
                    case "5":
                        DeleteParty();
                        break;
                    case "6":
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

        public void ShowAll()
        {
            List<Party> partyList = _partyRepo.GetPartyList();
            foreach(Party party in partyList)
            {
                Console.WriteLine($"Party Date: {party.PartyDate.Month}/{party.PartyDate.Day}/{party.PartyDate.Year}\n" +
                    $"Burger Booth - Tickets Used: {party.BurgerBooth.TicketsTaken} -- Total Cost of Supplies: ${party.BurgerBooth.TotalCost}\n" +
                    $"Treat Booth - Tickets used: {party.TreatBooth.TicketsTaken} -- Total Cost of Supplies: ${party.TreatBooth.TotalCost}\n" +
                    $"Total Cost of Party: ${party.TotalPartyCost}\n" +
                    $"----------------------");
            }
            decimal costOfAll = _partyRepo.GetCostOfAllParties(partyList);
            Console.WriteLine($"Total Cost of All Parties: ${costOfAll}\n" +
                $"Press any key to contine...");
            Console.ReadKey();
        }

        public void Breakdown()
        {
            Console.Write("Please enter the date of the party you would like to examine: ");
            DateTime partyDate = DateTime.Parse(Console.ReadLine());
            Party party = _partyRepo.GetPartyFromList(partyDate);
            Console.WriteLine($"For the party on {party.PartyDate.Month}/{party.PartyDate.Day}/{party.PartyDate.Year}:\n" +
                $"The Burger Booth took in {party.BurgerBooth.TicketsTaken} tickets.\n" +
                $"Hamburger Tickets - {party.BurgerBooth.HamburgerTickets} for a cost of ${party.BurgerBooth.CostOfHamburgers}\n" +
                $"Veggie Burger Tickets - {party.BurgerBooth.VeggieBurgerTickets} for a cost of ${party.BurgerBooth.CostOfVeggieBurgers}\n" +
                $"Hot Dog Tickets - {party.BurgerBooth.HotDogTickets} for a cost of ${party.BurgerBooth.CostOfHotDogs}\n" +
                $" \n" +
                $"The Treat Booth took in {party.TreatBooth.TicketsTaken} tickets.\n" +
                $"Ice Cream Tickets - {party.TreatBooth.IceCreamTickets} for a cost of ${party.TreatBooth.CostPerGallonOfIceCream}\n" +
                $"Popcorn Tickets - {party.TreatBooth.PopcornTickets} for a cost of ${party.TreatBooth.CostPerBagOfPopcorn}\n" +
                $"The total cost of the party was ${party.TotalPartyCost} and {party.TotalTicketsTaken} tickets were used.\n" +
                $"Press any key to continue...");
            Console.ReadKey();
        }

        public void AddNewParty()
        {
            Console.Write("Enter the date of the party: ");
            DateTime partyDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter the number of hamburger tickets taken: ");
            int hamburgerTickets = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of veggie burger tickets taken: ");
            int veggieBurgerTickets = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of hot dog tickets taken: ");
            int hotdogTickets = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of ice cream tickets taken: ");
            int iceCreamTickets = int.Parse(Console.ReadLine());
            Console.Write("Enter the number of popcorn tickets taken: ");
            int popcornTickets = int.Parse(Console.ReadLine());
            Party newParty = new Party(partyDate, new BurgerBooth(hamburgerTickets, veggieBurgerTickets, hotdogTickets), new TreatBooth(iceCreamTickets, popcornTickets));
            _partyRepo.AddPartyToList(newParty);
            Console.WriteLine("Party added\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        public void EditParty()
        {
            Console.Write("Enter the date of the party to update: ");
            DateTime updateDate = DateTime.Parse(Console.ReadLine());
            Console.Write("Enter the type of booth to update (burger or treat): ");
            string boothType = Console.ReadLine();
            if (boothType.ToLower() == "burger")
            {
                Console.Write("Enter the number of hamburger tickets taken: ");
                int hamburgerTickets = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of veggie burger tickets taken: ");
                int veggieBurgerTickets = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of hot dog tickets taken: ");
                int hotdogTickets = int.Parse(Console.ReadLine());
                BurgerBooth updateBurgerBooth = new BurgerBooth(hamburgerTickets, veggieBurgerTickets, hotdogTickets);
                _partyRepo.UpdateBooth(updateDate, updateBurgerBooth, boothType);
            }
            else if(boothType.ToLower() == "treat")
            {
                Console.Write("Enter the number of ice cream tickets taken: ");
                int iceCreamTickets = int.Parse(Console.ReadLine());
                Console.Write("Enter the number of popcorn tickets taken: ");
                int popcornTickets = int.Parse(Console.ReadLine());
                TreatBooth updateTreatBooth = new TreatBooth(iceCreamTickets, popcornTickets);
                _partyRepo.UpdateBooth(updateDate, updateTreatBooth, boothType);
            }
            Console.WriteLine("Party updated\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        public void DeleteParty()
        {
            Console.Write("Please enter the date of the party to remove: ");
            DateTime deleteDate = DateTime.Parse(Console.ReadLine());
            _partyRepo.DeletePartyFromList(deleteDate);
            Console.WriteLine("Party removed\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }

        public void SeedPartyList()
        {
            Party partyOne = new Party(new DateTime(2019, 5, 5), new BurgerBooth(125, 30, 50), new TreatBooth(150, 45));
            Party partyTwo = new Party(new DateTime(2019, 6, 15), new BurgerBooth(150, 25, 70), new TreatBooth(200, 30));
            Party partyThree = new Party(new DateTime(2019, 6, 3), new BurgerBooth(200, 75, 42), new TreatBooth(259, 60));

            _partyRepo.AddPartyToList(partyOne);
            _partyRepo.AddPartyToList(partyTwo);
            _partyRepo.AddPartyToList(partyThree);
        }
    }
}
