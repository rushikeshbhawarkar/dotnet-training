//using aug_17_rest.Data;
//using aug_17_rest.Model;
//using aug_17_rest.Repository;
//using Microsoft.EntityFrameworkCore;

//namespace aug_17_rest.Services
//{
//    public class OrderService : IOrderService
//    {
//        private readonly AppDbContext context;
//        public OrderService(AppDbContext context)
//        {
//           this.context = context; 
//        }
//        List<Order> IOrderService.GetOrders()
//        {
//            //load orderItems for each order, load product details for each orderitem
//            return context.Orders.Include(o=>o.OrderItems!).ThenInclude(i=>i.Product).ToList();
//        }
//    }
//}
