using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_3;

namespace Challenge_3_Tests
{
    [TestClass]
    public class UnitTest1
    {
        public OutingRepository outingRepository;
        [TestInitialize]
        public void TestInitialize()
        {
            outingRepository = new OutingRepository();
        }

        [TestMethod]
        public void Outings_CanAddOuting_ShouldBe1()
        {
            //-- This also covers the getOutings method.
            outingRepository.addOuting(new Outings(1, DateTime.Now, 20.00m, 15));

            int expected = 1;
            int actual = outingRepository.getOutings().Count;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Outings_CanGetOutingsByType_ShouldBe2()
        {
            outingRepository.addOuting(new Outings(1, DateTime.Now, 20.00m, 15));
            outingRepository.addOuting(new Outings(1, DateTime.Now, 20.00m, 15));
            outingRepository.addOuting(new Outings(3, DateTime.Now, 20.00m, 15));

            int expected = 2;
            int actual = outingRepository.getOutingsByType(1).Count;

            Assert.AreEqual(expected, actual);
        }
    }
}
