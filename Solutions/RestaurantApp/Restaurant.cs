using System;
using System.Linq;

namespace RestaurantApp
{
    public class Restaurant
    {
        private readonly IKitchen _kitchen;

        public Restaurant(IKitchen kitchen)
        {
            _kitchen = kitchen;
        }

        public int GetTableNumberWithHighestTotal()
        {
            return _kitchen.GetAllOrders()
                .GroupBy(o => o.TableNumber)
                .Select(go => new { TableNumber = go.Key, SumTotalPrice = go.Sum(o => o.TotalPrice) })
                .OrderByDescending(stp => stp.SumTotalPrice)
                .First().TableNumber;
        }

        public int GetTableNumberWithHighestOrderCount()
        {
            return _kitchen.GetAllOrders()
                .GroupBy(o => o.TableNumber)
                .OrderByDescending(go => go.Count())
                .First().Key;
        }

        public decimal GetAverageOrderPrice()
        {
            return _kitchen.GetAllOrders()
                .Average(o => o.TotalPrice);
        }
    }
}