using System;
using System.Collections.Generic;
using _01_CafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_CafeRepositoryMethodsTests
{
    [TestClass]
    public class CafeRepositoryTests
    {
        private CafeRepository _cafeRepository;
        private MenuItem _menuItem;

        [TestInitialize]
        public void Arrange()
        {
            _cafeRepository = new CafeRepository();
            _menuItem = new MenuItem(1, "The Big One", "It's a real big one", "There's one and it's big", 1.00m);
            _cafeRepository.AddItemtoMenu(_menuItem);
        }

        [TestMethod]
        public void GetMenuListTest()
        {
            List<MenuItem> menuList = _cafeRepository.GetMenuList();

            Assert.IsInstanceOfType(menuList, typeof(List<MenuItem>));
        }

        [TestMethod]
        public void GetMenuItemByNameTest()
        {
            string name = "The Big One";
            MenuItem foundItem = _cafeRepository.GetItemByName(name);

            Assert.AreEqual(1.00m, foundItem.Price);
        }

        [TestMethod]
        public void AddItemToListTest()
        {
            _cafeRepository.AddItemtoMenu(_menuItem);

            int expected = 2;
            int actual = _cafeRepository.GetMenuList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteItemFromListTest()
        {
            _cafeRepository.DeleteMenuItem(_menuItem);

            int expected = 0;
            int actual = _cafeRepository.GetMenuList().Count;

            Assert.AreEqual(expected, actual);
        }

    }
}
