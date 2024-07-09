namespace Store.DataAccess.Entities
{
	public class BasketProductEntity
	{
		public Guid BasketId { get; set; }
		//public virtual BasketEntity BasketEntity { get; set; } = null!;
		public Guid ProductId { get; set; }
		//public virtual ProductEntity ProductEntity { get; set; } = null!;
		public uint Count { get; set; }
	}
}
