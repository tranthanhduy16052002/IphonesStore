using System.Linq;
using Microsoft.AspNetCore.Mvc;
using IphonesStore.Models;
using IphonesStore.Models.ViewModels;

namespace IphonesStore.Controllers
{
    public class HomeController : Controller
    {
        private IIphonesStoreRepository repository;
        public int PageSize = 3;
        public HomeController(IIphonesStoreRepository repo)
        {
            repository = repo;
        }
        public IActionResult Index(string genre, int iphonePage = 1)
   => View(new IphonesListViewModel
   {
       Iphones = repository.Iphones
   .Where(p => genre == null || p.Genre == genre).OrderBy(p => p.IphoneID)
   .Skip((iphonePage - 1) * PageSize)
   .Take(PageSize),
       PagingInfo = new PagingInfo
       {
           CurrentPage = iphonePage,
           ItemsPerPage = PageSize,
           TotalItems = genre == null ?
   repository.Iphones.Count() :
   repository.Iphones.Where(e =>
   e.Genre == genre).Count()
       },
       CurrentGenre = genre
   });
    }
}
