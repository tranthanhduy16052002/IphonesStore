using System.Linq;
namespace IphonesStore.Models
{
    public interface IIphonesStoreRepository
    {
        IQueryable<Iphone> Iphones { get; }
        void SaveIphone(Iphone b);
        void CreateIphone(Iphone b);
        void DeleteIphone(Iphone b);
    }
}