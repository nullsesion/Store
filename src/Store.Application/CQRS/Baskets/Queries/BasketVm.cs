using Store.Application.CQRS.Products.Queries;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class BasketVm
	{
		public Guid BasketId { get; set; }
		public List<ProductVm> Products { get; set; }
	}
}
