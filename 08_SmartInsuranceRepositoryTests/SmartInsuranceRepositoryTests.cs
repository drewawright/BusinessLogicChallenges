using System;
using System.Collections.Generic;
using _08_SmartInsuranceRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08_SmartInsuranceRepositoryTests
{
    [TestClass]
    public class SmartInsuranceRepositoryTests
    {
        private SmartInsuranceRepository _insuranceRepo;
        private Driver _driver;

        [TestInitialize]
        public void Arrange()
        {
            _insuranceRepo = new SmartInsuranceRepository();
            _driver = new Driver(00001, "John Smith", new DriverData(10, 1, 3, 5));
            _insuranceRepo.AddDriverToDict(_driver);
        }

        [TestMethod]
        public void GetFullDriverDictTest()
        {
            Assert.IsInstanceOfType(_insuranceRepo.GetFullDriverDict(), typeof(Dictionary<int, Driver>));
        }

        [TestMethod]
        public void GetDriverDataTest()
        {
            Assert.IsInstanceOfType(_insuranceRepo.GetDriverData(), typeof(List<DriverData>));
        }

        [TestMethod]
        public void GetOneDriverTest()
        {
            Assert.IsInstanceOfType(_insuranceRepo.GetOneDriver(00001), typeof(Driver));
        }

        [TestMethod]
        public void GetOneDriversDataTest()
        {
            Assert.IsInstanceOfType(_insuranceRepo.GetOneDriversData(00001), typeof(DriverData));
        }

        [TestMethod]
        public void AddDriverToDictTest()
        {
            Driver driver = new Driver(00002, "Eric Jones", new DriverData(5, 0, 1, 2));
            _insuranceRepo.AddDriverToDict(driver);

            int expected = 2;
            int actual = _insuranceRepo.GetFullDriverDict().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EditDriverTest()
        {
            Driver newDriver = new Driver(00001, "John Smith-Jones", new DriverData(3, 3, 1, 1));
            _insuranceRepo.EditDriver(00001, newDriver);

            Driver actual = _insuranceRepo.GetOneDriver(00001);

            Assert.AreEqual(newDriver.DriverName, actual.DriverName);
            Assert.AreEqual(newDriver.DriverData.SpeedingFrequency, actual.DriverData.SpeedingFrequency);
        }

        [TestMethod]
        public void EditDriverDataTest()
        {
            DriverData newData = new DriverData(12, 15, 25, 8);
            _insuranceRepo.EditDriverData(00001, newData);

            DriverData actual = _insuranceRepo.GetOneDriversData(00001);

            Assert.AreEqual(newData.SpeedingFrequency, actual.SpeedingFrequency);
            Assert.AreEqual(newData.TimesRollingThroughStopSign, actual.TimesRollingThroughStopSign);
        }

        [TestMethod]
        public void RemoveDriverTest()
        {
            _insuranceRepo.RemoveDriverFromDict(00001);

            int expected = 0;
            int actual = _insuranceRepo.GetFullDriverDict().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAverageDataTest()
        {
            Driver newDriver = new Driver(00003, "John Smith-Jones", new DriverData(3, 3, 1, 1));
            Driver driver = new Driver(00002, "Eric Jones", new DriverData(5, 0, 1, 2));

            _insuranceRepo.AddDriverToDict(newDriver);
            _insuranceRepo.AddDriverToDict(driver);
            List<DriverData> dataList = _insuranceRepo.GetDriverData();

            DriverData averageData = _insuranceRepo.GetAverageData(dataList);

            Assert.AreEqual(6, averageData.SpeedingFrequency);
        }
    }
}
