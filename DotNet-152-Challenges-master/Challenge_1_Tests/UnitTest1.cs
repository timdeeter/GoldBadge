using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Challenge_1;

namespace Challenge_1_Tests
{
    [TestClass]
    public class UnitTest1
    {
        MenuRepository TestingRepository;

        [TestInitialize]
        public void Initialize()
        {
            //-- Arrange
            TestingRepository = new MenuRepository();
            TestingRepository.AddItem(new MenuItem(1, "Test", "", "", 8.95m));
        }

        [TestMethod]
        public void MenuRepository_CanGetList_CountEquals1()
        {
            int count = TestingRepository.GetMenuItems().Count;

            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void MenuRepository_CanAddItems_ShouldAdd1()
        {
            //-- Act
            TestingRepository.AddItem(new MenuItem(2, "Test2", "", "", 10.00m));

            //-- Assert
            Assert.AreEqual(2, TestingRepository.GetMenuItems().Count);
        }

        [TestMethod]
        public void MenuRepository_CanRemoveItems_ShouldBe0()
        {
            TestingRepository.RemoveItem(1);

            Assert.AreEqual(0, TestingRepository.GetMenuItems().Count);
        }
    }
}
