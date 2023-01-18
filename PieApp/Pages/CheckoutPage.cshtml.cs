using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PieApp.Models;

namespace PieApp.Pages
{
    public class CheckoutPageModel : PageModel
    {
        [BindProperty]
        public Order Order { get; set; }
        private readonly IShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public CheckoutPageModel(IShoppingCart shoppingCart, IOrderRepository orderRepository)
        {
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
                return Page();

            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty please add some pie first");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(Order);
                _shoppingCart.ClearCart();
                return RedirectToPage("CheckoutCompletePage");

            }
            return Page();
        }
    }
}
