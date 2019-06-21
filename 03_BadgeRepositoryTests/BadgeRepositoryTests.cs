using System;
using System.Collections.Generic;
using _03_BadgeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgeRepositoryTests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        private BadgeRepository _badgeRepo;
        private Badge _badge;

        [TestInitialize]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepository();
            _badge = new Badge(12345, new List<string> { "A2", "A3", "B7" });
            _badgeRepo.AddBadgetoList(_badge);
        }

        [TestMethod]
        public void GetBadgeListTest()
        {
            Assert.IsInstanceOfType(_badgeRepo.GetBadgeList(), typeof(Dictionary<int, List<string>>));
        }

        [TestMethod]
        public void AddBadgeToListTest()
        {
            Badge badgeTwo = new Badge(23456, new List<string> { "A4", "B7" });
            _badgeRepo.AddBadgetoList(badgeTwo);

            int expected = 2;
            int actual = _badgeRepo.GetBadgeList().Count;

            Assert.AreEqual(expected, actual);
        }

            [TestMethod]
        public void GetBadgeFromListTest()
        {
            Badge testBadge = _badgeRepo.GetBadgeFromList(12345);

            Assert.AreEqual(testBadge.DoorsAccessible, _badge.DoorsAccessible);
            Assert.IsInstanceOfType(_badgeRepo.GetBadgeFromList(12345), typeof(Badge));
        }

        [TestMethod]
        public void AddDoorToBadge()
        {
            _badgeRepo.AddDoorToBadge(12345, "B8");
            Badge badge = _badgeRepo.GetBadgeFromList(12345);
            int expected = 4;
            int actual = badge.DoorsAccessible.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveDoorFromBadgeTest()
        {
            _badgeRepo.RemoveDoorFromBadge(12345, "B7");
            Badge badge = _badgeRepo.GetBadgeFromList(12345);
            int expected = 2;
            int actual = badge.DoorsAccessible.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RemoveAllDoorsFromBadge()
        {
            _badgeRepo.RemoveAllDoorsFromBadge(12345);
            Badge badge = _badgeRepo.GetBadgeFromList(12345);

            Assert.AreEqual(0, badge.DoorsAccessible.Count);
        }
    }
}
