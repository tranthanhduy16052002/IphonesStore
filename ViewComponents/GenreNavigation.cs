using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IphonesStore.Models;
namespace IphonesStore.ViewComponents
{
    public class GenreNavigation : ViewComponent
    {
        private IIphonesStoreRepository repository;
        public GenreNavigation(IIphonesStoreRepository repo)
        {
            repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedGenre = RouteData?.Values["genre"];
            return View(repository.Iphones
            .Select(x => x.Genre)
            .Distinct()
            .OrderBy(x => x));
        }
    }
}