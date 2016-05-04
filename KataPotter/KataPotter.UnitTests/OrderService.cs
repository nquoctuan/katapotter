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
            {
                var differentBooks = order.GroupBy(x => x.Name).Select(g => g.First());

                if (differentBooks.Count() == 2)
                {
                    var restOfList = order.Except(differentBooks);

                    if (restOfList.Any())
                        return differentBooks.Sum(x => x.Price) * 0.95m + restOfList.Sum(x => x.Price);

                    return differentBooks.Sum(x => x.Price) * 0.95m;
                }

                return order.Sum(x => x.Price);
            }

            return 0;
        }
    }
}