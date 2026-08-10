using aug_07.Data;
using aug_07.Model;
using aug_07.Repository;
using Microsoft.EntityFrameworkCore;

namespace aug_07.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;
        public OrderService(AppDbContext context)
        {
           this.context = context; 
        }
        List<Order> IOrderService.GetOrders()
        {
            //load orderItems for each order, load product details for each orderitem
            return context.Orders.Include(o=>o.OrderItems!).ThenInclude(i=>i.Product).ToList();
        }
    }
}
