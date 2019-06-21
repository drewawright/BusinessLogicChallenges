using System;
using System.Collections.Generic;
using _07_BarbecueRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07_BarbecueRepositoryTests
{
    [TestClass]
    public class BarbacueRepositoryTests
    {
        private BarbacueRepository _partyTestList;
        private Party _party;

        [TestInitialize]
        public void Arrange()
        {
            _partyTestList = new BarbacueRepository();
            _party = new Party(new DateTime(2019, 6, 15), new BurgerBooth(150, 25, 70), new TreatBooth(200, 30));
            _partyTestList.AddPartyToList(_party);
        }

        [TestMethod]
        public void GetPartyListTest()
        {
            Assert.IsInstanceOfType(_partyTestList.GetPartyList(), typeof(List<Party>));
        }

        [TestMethod]
        public void GetPartyFromListTest()
        {
            Party party = _partyTestList.GetPartyFromList(new DateTime(2019, 6, 15));

            Assert.IsInstanceOfType(party, typeof(Party));
        }

        [TestMethod]
        public void AddPartyToListTest()
        {
            Party partyTwo = new Party(new DateTime(2019, 5, 5), new BurgerBooth(125, 30, 50), new TreatBooth(150, 45));
            _partyTestList.AddPartyToList(partyTwo);

            int expected = 2;
            int actual = _partyTestList.GetPartyList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeletePartyFromListTest()
        {
            _partyTestList.DeletePartyFromList(new DateTime(2019, 6, 15));

            int expected = 0;
            int actual = _partyTestList.GetPartyList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetBoothTest()
        {
            Booth gotBooth = _partyTestList.GetBooth(new DateTime(2019, 6, 15), "burger");

            Assert.IsInstanceOfType(gotBooth, typeof(BurgerBooth));
        }

        [TestMethod]
        public void UpdateBoothTest()
        {
            TreatBooth newTreatBooth = new TreatBooth(99, 45);

            _partyTestList.UpdateBooth(new DateTime(2019, 6, 15), newTreatBooth, "treat");

            Booth updatedBooth = _partyTestList.GetBooth(new DateTime(2019, 6, 15), "treat");
            TreatBooth actual = (TreatBooth)updatedBooth;
            Assert.AreEqual(99, actual.IceCreamTickets);
            Assert.AreEqual(45, actual.PopcornTickets);
        }

        [TestMethod]
        public void GetTotalCostTest()
        {
            Party partyTwo = new Party(new DateTime(2019, 5, 5), new BurgerBooth(125, 30, 50), new TreatBooth(150, 45));
            _partyTestList.AddPartyToList(partyTwo);

            List<Party> partyList = _partyTestList.GetPartyList();

            decimal actual = _partyTestList.GetCostOfAllParties(partyList);
            decimal expected = _party.TotalPartyCost + partyTwo.TotalPartyCost;

            Assert.AreEqual(expected, actual);
        }
    }
}
