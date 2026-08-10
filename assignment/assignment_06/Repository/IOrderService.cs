using assignment_06.Models;

namespace assignment_06.Repository
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        void DeleteOrder(int id);
        Order? GetOrderById(int id);
        List<Order> GetOrders();
        void UpdateOrder(Order order);
    }
}