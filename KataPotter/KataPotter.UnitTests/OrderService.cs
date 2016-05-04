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
                if (order.GroupBy(x => x.Name).Count() == 1)
                    return order.Sum(x => x.Price);
                else
                return order.Sum(x => x.Price) * 0.95m;

            return 0;
        }
    }
}