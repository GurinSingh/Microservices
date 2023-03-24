namespace Basket.Api.Entities
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            
        }
        public ShoppingCart(string userName)
        {
            this.UserName = UserName;
        }
        public string UserName { get; set; }
        public List<ShoppingCartItem> Items { get; set; } = new();
        public decimal TotalPrice { get {
                decimal totalPrice = 0;
                foreach (ShoppingCartItem item in Items)
                    totalPrice += item.Price * item.Quantity;
                
                return totalPrice;
            } }
    }
}
