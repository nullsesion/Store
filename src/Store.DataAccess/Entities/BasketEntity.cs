namespace Store.DataAccess.Entities
{
	public class BasketEntity
	{
		public Guid BasketId { get; set; }

		public string? JsonProducts { get; set; }

		public bool Sealed { get; set; }

		public virtual ICollection<BasketProductEntity> BasketProducts { get; set; } = new List<BasketProductEntity>();
	}
}
