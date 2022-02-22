using System.Collections.Generic;

namespace RestaurantApp
{
    public interface IKitchen
    {
        Order[] GetAllOrders();
    }
}