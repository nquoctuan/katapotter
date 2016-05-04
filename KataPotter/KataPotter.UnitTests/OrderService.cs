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
            if (order.Any())
            {
                var differentBooks = order.GroupBy(x => x.Name).Select(g => g.First());

                if (differentBooks.Count() == 2)
                {
                    var restOfList = order.Except(differentBooks);

                    return CalculateCostSecondLevel(differentBooks, restOfList);
                }

                return order.Sum(x => x.Price);
            }

            return 0;
        }

        /// <summary>
        /// Interesting about recursive method appear after the test case comes
        /// </summary>
        /// <param name="differentBooks"></param>
        /// <param name="restOfList"></param>
        /// <returns></returns>
        private static decimal CalculateCostSecondLevel(IEnumerable<Order> differentBooks, IEnumerable<Order> restOfList)
        {
            if (restOfList.Any())
            {
                var differentBooksSecondLevel = restOfList.GroupBy(x => x.Name).Select(g => g.First());

                if (differentBooksSecondLevel.Count() == 2)
                    return differentBooksSecondLevel.Sum(x => x.Price) * 0.95m + differentBooks.Sum(x => x.Price) * 0.95m;
                else
                    return differentBooks.Sum(x => x.Price) * 0.95m + restOfList.Sum(x => x.Price);
            }

            return differentBooks.Sum(x => x.Price) * 0.95m;
        }
    }
}