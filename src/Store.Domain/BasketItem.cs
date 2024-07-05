namespace Store.Domain
{
	public class BasketItem
	{
		public Product Product { get; set; }
		public uint Count { get; set; } = 1;
	}
}
