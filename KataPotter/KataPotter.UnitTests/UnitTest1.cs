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
                new Order { BookId = 1, Name = "Harry1", Price = 8 }
            };

            decimal actual = target.CalculateCost(order);
            decimal expected = 8;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_2_Identical_Book_Total_Cost_Should_Be_16()
        {
            var target = new OrderService();
            var order = new List<Order>
            {
                new Order { BookId = 1, Name = "Harry1", Price = 8 },
                new Order { BookId = 1, Name = "Harry1", Price = 8 }
            };

            decimal actual = target.CalculateCost(order);
            decimal expected = 16;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_2_Different_Book_Total_Cost_Should_Be_15_dot_2()
        {
            var target = new OrderService();
            var order = new List<Order>
            {
                new Order { BookId = 1, Name = "Harry1", Price = 8 },
                new Order { BookId = 2, Name = "Harry2", Price = 8 }
            };

            decimal actual = target.CalculateCost(order);
            decimal expected = 15.2m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_3_Identical_Book_Total_Cost_Should_24()
        {
            var target = new OrderService();
            var order = new List<Order>
            {
                new Order { BookId = 1, Name = "Harry1", Price = 8 },
                new Order { BookId = 2, Name = "Harry2", Price = 8 }
            };

            decimal actual = target.CalculateCost(order);
            decimal expected = 15.2m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test_Buy_3_Book_With_2_Identical_One_Total_Cost_Should_Be_23_dot_2()
        {
            var target = new OrderService();
            var order = new List<Order>
            {
                new Order { BookId = 1, Name = "Harry1", Price = 8 },
                new Order { BookId = 1, Name = "Harry1", Price = 8 },
                new Order { BookId = 2, Name = "Harry2", Price = 8 }
            };

            decimal actual = target.CalculateCost(order);
            decimal expected = 15.2m;

            Assert.AreEqual(expected, actual);
        }
    }
}
