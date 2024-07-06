namespace Store.Application.CQRS.Products.Commands
{
	public class ProductCreatorInfo: AbstractCreatorInfo
	{
		public Guid ProductId { get; set; }
	}
}
