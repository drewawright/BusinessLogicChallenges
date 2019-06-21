using System;
using System.Collections.Generic;
using _04_OutingsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _04_OutingsRepositoryTests
{
    [TestClass]
    public class OutingsRepositoryTest
    {
        private OutingsRepository _outingsRepo;
        private Outing _outing;

        [TestInitialize]
        public void Arrange()
        {
            _outingsRepo = new OutingsRepository();
            _outing = new Outing("Golf", new DateTime(2019, 3, 17), 125);
            _outingsRepo.AddOutingToList(_outing);
        }

        [TestMethod]
        public void GetOutingsListTest()
        { 
            Assert.IsInstanceOfType(_outingsRepo.GetListOfOutings(), typeof(List<Outing>));
        }

        [TestMethod]
        public void AddOutingToListTest()
        {
            Outing outing = new Outing("Amusement Park", new DateTime(2019, 5, 25), 35);
            _outingsRepo.AddOutingToList(outing);

            int expected = 2;
            int actual = _outingsRepo.GetListOfOutings().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCostOfAllOutingsTest()
        {
            Outing outing = new Outing("Amusement Park", new DateTime(2019, 5, 25), 35);
            _outingsRepo.AddOutingToList(outing);

            decimal expected = (125m * 75m) + (35m * 100m);
            decimal actual = _outingsRepo.GetCostOfAllOutings();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetCostOfOutingsTypeTest()
        {
            Outing outing = new Outing("Amusement Park", new DateTime(2019, 5, 25), 35);
            Outing outingTwo = new Outing("Golf", new DateTime(2019, 4, 7), 25);
            _outingsRepo.AddOutingToList(outing);
            _outingsRepo.AddOutingToList(outingTwo);

            decimal expected = 150m * 75.00m;
            decimal actual = _outingsRepo.GetCostOfOutingsType(OutingType.Golf);

            Assert.AreEqual(expected, actual);
        }
    }
}
