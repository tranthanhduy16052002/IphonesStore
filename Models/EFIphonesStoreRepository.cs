using System.Linq;
namespace IphonesStore.Models
{
    public class EFIphonesStoreRepository : IIphonesStoreRepository
    {
        private IphonesStoreDbContext context;
        public EFIphonesStoreRepository(IphonesStoreDbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<Iphone> Iphones => context.Iphones;
        public void CreateIphone(Iphone b)
        {
            context.Add(b);
            context.SaveChanges();
        }
        public void DeleteIphone(Iphone b)
        {
            context.Remove(b); context.SaveChanges();
        }
        public void SaveIphone(Iphone b)
        {
            context.SaveChanges();
        }
    }
}