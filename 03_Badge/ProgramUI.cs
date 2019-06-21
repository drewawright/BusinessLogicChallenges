using _03_BadgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badge
{
    class ProgramUI
    {
        private BadgeRepository _badgeRepo = new BadgeRepository();
        public void Run()
        {
            SeedBadgeList();
            RunUI();
        }

        private void RunUI()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome Security Admin, what would you like to do?\n" +
                    "1. Add a badge\n" +
                    "2. Edit a badge\n" +
                    "3. List all badges\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddBadgeToList();
                        break;
                    case "2":
                        EditBadge();
                        break;
                    case "3":
                        ListAllBadges();
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

        private void AddBadgeToList()
        {
            Badge badge = new Badge();
            Console.Write("What is the number for this badge: ");
            badge.BadgeID = int.Parse(Console.ReadLine());
            bool continueToAddDoor = true;
            List<string> doorsList = new List<string>();
            while (continueToAddDoor)
            {
                Console.Write("List a door this badge needs access to: ");
                string addDoor = Console.ReadLine();
                doorsList.Add(addDoor);
                Console.Write("Any other doors(y/n)? ");
                string confirm = Console.ReadLine();
                if (confirm == "n")
                {
                    continueToAddDoor = false;
                }
            }
            badge.DoorsAccessible = doorsList;
            _badgeRepo.AddBadgetoList(badge);
            Console.WriteLine("Badge added, press any key to continue...");
            Console.ReadKey();
        }

        private void EditBadge()
        {
            Console.Write("What is the number of the badge to update? ");
            int badgeInput = int.Parse(Console.ReadLine());
            Badge badge = _badgeRepo.GetBadgeFromList(badgeInput);
            Console.Write($"Badge {badgeInput} has acces to doors ");
            foreach (string door in badge.DoorsAccessible)
            {
                Console.Write($"{door}, ");
            }
            Console.WriteLine(" \n" +
                "What would you like to do?\n" +
                "   1. Add a Door\n" +
                "   2. Remove a Door");
            string userChoice = Console.ReadLine();
            switch (userChoice)
            {
                case "1":
                    Console.Write("Enter a door to add: ");
                    string addDoor = Console.ReadLine();
                    _badgeRepo.AddDoorToBadge(badgeInput, addDoor);
                    Console.WriteLine("Door added\n" +
                        $"Badge {badgeInput} now has access to doors ");
                    foreach (string door in badge.DoorsAccessible)
                    {
                        Console.Write($"{door}, ");
                    }
                    Console.WriteLine(" \n" +
                        "Press any key to continue....");
                    Console.ReadKey();
                    break;

                case "2":
                    Console.WriteLine("Would you like to: \n" +
                        "   1. Remove one door\n" +
                        "   2. Remove all doors");
                    string removeChoice = Console.ReadLine();
                    if (removeChoice == "1")
                    {
                        Console.Write("Enter a door to remove: ");
                        string removeDoor = Console.ReadLine();
                        _badgeRepo.RemoveDoorFromBadge(badgeInput, removeDoor);
                        Console.Write("Door removed.\n" +
                            $"Badge {badgeInput} now has access to doors ");
                        foreach (string door in badge.DoorsAccessible)
                        {
                            Console.Write($"{door}, ");
                        }
                    }
                    else
                    {
                        _badgeRepo.RemoveAllDoorsFromBadge(badgeInput);
                        Console.WriteLine("All doors removed");
                    }

                    Console.WriteLine(" \n" +
                        "Press any key to continue...");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Please enter 1 or 2");
                    break;
            }
        }

        private void ListAllBadges()
        {
            Console.WriteLine("Badge #           Door Access");
            Dictionary<int, List<string>> badgeList = _badgeRepo.GetBadgeList();
            foreach(KeyValuePair<int, List<string>> badge in badgeList)
            {
                Console.Write($"{badge.Key}            ");
                foreach (string door in badge.Value)
                {
                    Console.Write($"{door}, ");
                }
                Console.WriteLine("");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private void SeedBadgeList()
        {
            Badge badgeOne = new Badge(12345, new List<string> { "A1", "A2", "B7" });
            Badge badgeTwo = new Badge(12346, new List<string> { "A4", "A5", "B7" });
            Badge badgeThree = new Badge(12347, new List<string> { "A3", "A6", "B7" });

            _badgeRepo.AddBadgetoList(badgeOne);
            _badgeRepo.AddBadgetoList(badgeTwo);
            _badgeRepo.AddBadgetoList(badgeThree);
        }
    }
}
