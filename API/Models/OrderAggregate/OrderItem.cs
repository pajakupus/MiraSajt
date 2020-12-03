namespace API.Models.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItemOrdered itemOrdered, decimal price, int quantity, string size)
        //
        {
            ItemOrdered = itemOrdered;
    
            Price = price;
            Quantity = quantity;
            Size = size;
        }

        public ProductItemOrdered ItemOrdered { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
        public string Size { get; set; }
    }
}