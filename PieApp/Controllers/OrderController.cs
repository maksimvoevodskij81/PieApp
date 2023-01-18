using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PieApp.Models;

namespace PieApp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IShoppingCart _shoppingCart;
        public OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
        }
        public ActionResult Checkout() 
        {
          return View();
        }
        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty please add some pie first");
            }
            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckoutComplete");
                 
            }
            return View(order);
        }
        public ActionResult CheckoutComplete()
        {
            ViewBag.CheckoutComplete = "Thank you!";
            return View();
        }
    }
}
