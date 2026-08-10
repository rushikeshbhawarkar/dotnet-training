// 3. Services/OrderService.cs
using assignment_06.Data;
using assignment_06.Models;
using assignment_06.Repository;

namespace assignment_06.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

        public OrderService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            context.orders.Add(order);
            context.SaveChanges();
        }

        public void DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Order? GetOrderById(int id)
        {
            return context.orders.Find(id);
        }

        public List<Order> GetOrders()
        {
            return context.orders.ToList();
        }

        public void UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}