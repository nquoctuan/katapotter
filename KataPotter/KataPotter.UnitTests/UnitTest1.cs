using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace KataPotter.UnitTests
{
    [TestClass]
    public class KataPotterTest
    {
        [TestMethod]
        public void Test_Buy_0_Book_Total_Cost_Should_Be_0()
        {
            //arrange
            var target = new OrderService();

            var order = new List<Order>();


            //act
            decimal actual = target.CalculateCost(order);
            decimal expected = 0;

            //assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_1_Book_Total_Cost_Should_Be_8()
        {
            var target = new OrderService();
            var order = new List<Order>
            {
                new Order { BookId = 1, Name = "Harry1" }
            };

            decimal actual = target.CalculateCost(order);
            decimal expected = 8;

            Assert.AreEqual(expected, actual);
        }
    }
}
