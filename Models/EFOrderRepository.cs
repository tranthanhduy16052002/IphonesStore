using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace IphonesStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {
        private IphonesStoreDbContext context;
        public EFOrderRepository(IphonesStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Order> Orders => context.Orders
        .Include(o => o.Lines)
        .ThenInclude(l => l.Iphone);
        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Iphone));
            if (order.OrderID == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}