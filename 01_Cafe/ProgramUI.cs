using _01_CafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    class ProgramUI
    {
        private CafeRepository _cafeRepository = new CafeRepository();

        public void Run()
        {
            SeedMenu();
            RunMenu();
        }

        public void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Komodo Cafe Menu System\n" +
                "Please enter the number of the task you would like to do\n" +
                "1). Display the menu\n" +
                "2). Add a new menu item\n" +
                "3). Remove a menu item\n" +
                "4). Exit");
            string userChoice = Console.ReadLine();


                switch (userChoice)
                {
                    case "1":
                        DisplayMenu();
                        break;
                    case "2":
                        AddItemToMenu();
                        break;
                    case "3":
                        RemoveItemFromMenu();
                        break;
                    case "4":
                        continueToRun = false;
                        Console.WriteLine("Goodbye, have a nice day\n" +
                            "Press any key to exit");
                        Console.ReadKey();
                        break;
                }
            }

        }

        public void DisplayMenu()
        {
            List<MenuItem> menu = _cafeRepository.GetMenuList();
            foreach (MenuItem item in menu)
            {
                Console.WriteLine($"#{item.MealNumber} - {item.MealName} - ${item.Price}\n" +
                    $"Description: {item.Description}");
                Console.Write("Ingredients: ");
                foreach(string ingredient in item.Ingredients)
                {
                    Console.Write($"{ingredient}, ");
                }
                Console.WriteLine(" \n" +
                    "---------");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        public void AddItemToMenu()
        {
            MenuItem newItem = new MenuItem();
            Console.Write("Enter the Meal Number of the item: ");
            newItem.MealNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the name of the new menu item:");
            newItem.MealName = Console.ReadLine();
            Console.WriteLine("Enter a description of the new menu item:");
            newItem.Description = Console.ReadLine();
            bool continueToAdd = true;
            while (continueToAdd)
            {
            Console.WriteLine("Enter an ingredient of the new menu item or type end to finish adding ingredients:");
                string ingredient = Console.ReadLine();
                if (ingredient.ToLower() != "end")
                {
                    newItem.Ingredients.Add(ingredient);
                }
                else
                {
                    Console.WriteLine("Finished adding ingredients");
                    continueToAdd = false;
                }
            }
            Console.WriteLine("Enter the price of the new menu item:");
            newItem.Price = decimal.Parse(Console.ReadLine());

            _cafeRepository.AddItemtoMenu(newItem);
        }

        public void RemoveItemFromMenu()
        {
            Console.WriteLine("Please enter the name of the item you want to remove:");
            string removeName = Console.ReadLine();
            MenuItem removeItem = _cafeRepository.GetItemByName(removeName);
            _cafeRepository.DeleteMenuItem(removeItem);
            Console.WriteLine("Item Removed\n" +
                "Press any key to continue...");
            Console.ReadKey();
        }


        public void SeedMenu()
        {
            MenuItem theBigOne = new MenuItem(1, "The Big One", "It's a real big one", new List<string> { "There's one and it's big" }, 1.00m);
            MenuItem theSmallOne = new MenuItem(2, "The Small One", "The Big One's little brother",new List<string> { "There's one and it's small" }, 5.00m);
            MenuItem hotDog = new MenuItem(3, "Hot Dog", "A hot dog with your choice of toppings", new List<string> { "Beef Hot Dog", "Bun", "Condiments as requested" }, 3.50m);

            _cafeRepository.AddItemtoMenu(theBigOne);
            _cafeRepository.AddItemtoMenu(theSmallOne);
            _cafeRepository.AddItemtoMenu(hotDog);
        }
    } 
}
