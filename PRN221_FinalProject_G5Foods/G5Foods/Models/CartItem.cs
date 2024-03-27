namespace G5Foods.Models
{
    public class CartItem
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
		public string? Image { get; set; }
		public int? Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
