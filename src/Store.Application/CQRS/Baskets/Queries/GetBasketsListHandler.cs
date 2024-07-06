using MediatR;
using Store.Application.CQRS.Products.Queries;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketsListHandler: IRequestHandler<GetBasketsList, BasketsVm>
	{
		public async Task<BasketsVm> Handle(GetBasketsList request, CancellationToken cancellationToken)
		{
			await Task.Delay(100);
			BasketVm basketVm = new BasketVm()
			{
				BasketId = Guid.Empty
				,Products = new List<ProductVm>()
			};
			BasketsVm basketsVm = new BasketsVm()
			{
				Baskets = new List<BasketVm>() { basketVm }
			};
			return basketsVm;
		}
	}
}
