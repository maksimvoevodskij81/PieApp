using Microsoft.AspNetCore.Mvc;
using PieApp.Models;
using PieApp.ViewModels;

namespace PieApp.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart cart;

        public ShoppingCartSummary(IShoppingCart cart)
        {
            this.cart = cart;
        }
        public IViewComponentResult Invoke()
        {
            var item = cart.GetShoppingCartItems();
            cart.ShoppingCartItems = item;

            var shoppingCartViewModel = new ShoppingCartViewModel(cart, cart.GetShoppingCartTotal());
            return View(shoppingCartViewModel);
        }
    }
}
