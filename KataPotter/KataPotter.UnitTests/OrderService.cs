using System;
using System.Linq;
using System.Collections.Generic;

namespace KataPotter.UnitTests
{
    internal class OrderService
    {
        public OrderService()
        {
        }

        internal decimal CalculateCost(List<Order> order)
        {
            if (order.Count > 0)
                return 8;

            return 0;
        }
    }
}