using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeRepository
{
    public class MenuItem
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<string> Ingredients { get; set; }
        public decimal Price { get; set; }

        public MenuItem()
        {
            Ingredients = new List<string>();
        }

        public MenuItem(int mealNumber, string mealName, string description, List<string> ingredients, decimal price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
