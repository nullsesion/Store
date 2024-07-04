namespace Store.DataAccess.Entities
{
	public class BasketEntity
	{
		public Guid BasketId { get; set; }
		public string JsonProducts { get; set;} = String.Empty;
		public bool Sealed { get; set; } = false;
	}
}
