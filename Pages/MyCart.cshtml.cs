using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using IphonesStore.MyTagHelper;
using IphonesStore.Models;
using System.Linq;
namespace IphonesStore.Pages
{
    public class MyCartModel : PageModel
    {
        private IIphonesStoreRepository repository;
        public MyCartModel(IIphonesStoreRepository repo, MyCart myCartService)
        {
            repository = repo;
            myCart = myCartService;
        }
        public MyCart myCart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(long iphoneId, string returnUrl)
        {
            Iphone iphone = repository.Iphones
            .FirstOrDefault(b => b.IphoneID == iphoneId);
            myCart.AddItem(iphone, 1);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPostRemove(long iphoneId, string returnUrl)
        {
            myCart.RemoveLine(myCart.Lines.First(cl =>
            cl.Iphone.IphoneID == iphoneId).Iphone);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}