namespace Store.Application.CQRS.Baskets.Commands
{
	public class BasketCreatorInfo: AbstractCreatorInfo
	{
		public Guid BasketId { get; set; }
	}
}
