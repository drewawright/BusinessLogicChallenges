using System;
using System.Collections.Generic;
using _02_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsRepositoryTests
{
    [TestClass]
    public class ClaimsRepositoryMethodsTests
    {
        private ClaimsRepository _claimsQueue;
        private Claim _claim;

        [TestInitialize]
        public void Arrange()
        {
            _claimsQueue = new ClaimsRepository();
            _claim = new Claim(1, ClaimType.Car, "Backed into garage door", 100.00m, new DateTime(2019, 1, 14), new DateTime(2019, 3, 15));
            _claimsQueue.AddClaimToQueue(_claim);
        }

        [TestMethod]
        public void ClaimPOCOTest()
        {
            Claim firstClaim = new Claim(1, ClaimType.Car, "Backed into garage door", 100.00m, new DateTime(2019, 1, 14), new DateTime(2019, 3, 15));

            Assert.AreEqual(1, firstClaim.ClaimID);
            Assert.AreEqual(ClaimType.Car, firstClaim.TypeOfClaim);
            Assert.AreEqual("Backed into garage door", firstClaim.Description);
            Assert.AreEqual(100.00m, firstClaim.ClaimAmount);
            Assert.AreEqual(new DateTime(2019, 1, 14), firstClaim.DateOfIncident);
            Assert.AreEqual(new DateTime(2019, 3, 15), firstClaim.DateOfClaim);
            Assert.AreEqual(false, firstClaim.IsValid);
        }

        [TestMethod]
        public void GetClaimsListTest()
        {
            //Queue<Claim> newClaimsQueue = _claimsQueue.GetClaimsList();

            Assert.IsInstanceOfType(_claimsQueue.GetClaimsList(), typeof(Queue<Claim>));
        }

        [TestMethod]
        public void AddClaimToQueueTest()
        {
            Claim secondClaim = new Claim(2, ClaimType.Home, "Son backed into garage door", 200.00m, new DateTime(2019, 1, 14), new DateTime(2019, 3, 15));
            _claimsQueue.AddClaimToQueue(secondClaim);

            int expected = 2;
            int actual = _claimsQueue.GetClaimsList().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetClaimFromQueueTest()
        {
            //Claim claim = _claimsQueue.GetClaimFromQueue();

            Assert.IsInstanceOfType(_claimsQueue.GetClaimFromQueue(), typeof(Claim));
        }

        [TestMethod]
        public void ActOnClaimTest()
        {
            _claimsQueue.ActOnClaim();

            int expected = 0;
            int actual = _claimsQueue.GetClaimsList().Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
