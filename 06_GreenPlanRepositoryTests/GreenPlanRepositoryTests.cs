using System;
using System.Collections.Generic;
using _06_GreenPlanRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_GreenPlanRepositoryTests
{
    [TestClass]
    public class GreenPlanRepositoryTests
    {
        private GreenPlanRepository _carsList;
        private ICar _car;

        [TestInitialize]
        public void Arrange()
        {
            _carsList = new GreenPlanRepository();
            _car = new HybridCar("Toyota", "Prius", 85.00d, 18000.00m, 25);
            _carsList.AddCarToList(_car);
        }

        [TestMethod]
        public void GetCarsListTest()
        {
            Assert.IsInstanceOfType(_carsList.GetCarsList(), typeof(List<ICar>));
        }

        [TestMethod]
        public void GetCarFromListTest()
        {
            var car = _carsList.GetCarFromList("Prius");

            Assert.AreEqual("Toyota", car.Make);
            Assert.AreEqual("Prius", car.Model);
            Assert.AreEqual(85.00d, car.MPG);
            Assert.IsInstanceOfType(car, typeof(ICar));
        }

        [TestMethod]
        public void AddCarToListTest()
        {
            GasCar carTwo = new GasCar("Nissan", "Versa", 32.5d, 140000.00m, 14);
            _carsList.AddCarToList(carTwo);

            int expected = 2;
            int actual = _carsList.GetCarsList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UpdateCarOnListTest()
        {
            HybridCar carThree = new HybridCar("Nissan", "Blend", 85.99d, 17500.50m, 3);
            _carsList.UpdateCarOnList("Prius", carThree);

            var actual = _carsList.GetCarFromList("Blend");

            Assert.AreEqual(carThree.MPG, actual.MPG);
            Assert.AreEqual(carThree.NumberOfDrivers, actual.NumberOfDrivers);
            Assert.AreEqual(carThree.Price, actual.Price);
        }

        [TestMethod]
        public void DeleteCarFromListTest()
        {
            _carsList.DeleteCarFromList("Prius");

            int expected = 0;
            int actual = _carsList.GetCarsList().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
