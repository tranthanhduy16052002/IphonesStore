using System.Collections.Generic;
namespace IphonesStore.Models.ViewModels
{
    public class IphonesListViewModel
    {
        public IEnumerable<Iphone> Iphones { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentGenre { get; set; }
    }
}