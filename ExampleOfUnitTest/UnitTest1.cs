using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _01_Complete;
namespace _01_Complete
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetAge()
        {
            //Arrange
            DateTime bod = DateTime.Today;
            bod = bod.AddDays(7);
            bod = bod.AddYears(-24);
            Customer testCust = new Customer();
            testCust.DateOfBirth = bod;
            //The customer's 24th birthday is seven days away, 
            //so the age in years should be 23
            int expectedAge = 23;

            //Act
            int actualAge = testCust.GetAge();

            //Assert
            //Fail the test if the actual age and the expected age are
            //different
            Assert.IsTrue((actualAge==expectedAge), "Age not calculated correctly");

        }
    }
}
