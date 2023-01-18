namespace PieApp.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PieAppDbContext _pieAppDbContext;
        private readonly IShoppingCart _shoppingCart;

        public OrderRepository(PieAppDbContext pieAppDbContext, IShoppingCart shoppingCart)
        {
            _pieAppDbContext = pieAppDbContext;
            _shoppingCart = shoppingCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            List<ShoppingCartItem>? shoppingCartItems = _shoppingCart.ShoppingCartItems;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDetails = new List<OrderDetail>();
            foreach (ShoppingCartItem? shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    Price = shoppingCartItem.Pie.Price,
                    PieId = shoppingCartItem.Pie.PieId
                };
                order.OrderDetails.Add(orderDetail);
            }
            _pieAppDbContext.Orders.Add(order);
            _pieAppDbContext.SaveChanges();
        }
    }
}
