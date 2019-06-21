using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_CafeRepository
{
    public class CafeRepository
    {
        public List<MenuItem> _menuItems = new List<MenuItem>();

        public List<MenuItem> GetMenuList()
        {
            return _menuItems;
        }

        public MenuItem GetItemByName(string name)
        {
            foreach (MenuItem item in _menuItems)
            {
                if (name.ToLower() == item.MealName.ToLower())
                {
                    return item;
                }
            }
            return null;
        }

        public void AddItemtoMenu(MenuItem item)
        {
            _menuItems.Add(item);
        }

        public void DeleteMenuItem(MenuItem item)
        {
            _menuItems.Remove(item);
        }
    }
}
