namespace Store.DataAccess.Entities
{
	public class BasketEntity
	{
		public Guid BasketId { get; set; }
		public string? JsonProducts { get; set;}
		public bool Sealed { get; set; } = false;
		public List<ProductEntity> ProductEntities { get; set; }
		public List<BasketProductEntity> BasketProductEntities { get; set; }
	}
}
