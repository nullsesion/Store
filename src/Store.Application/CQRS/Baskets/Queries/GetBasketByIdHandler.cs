using MediatR;
using Store.Application.Abstraction;
using Store.Application.CQRS.Products.Queries;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketByIdHandler: IRequestHandler<GetBasketById, BasketVm>
	{
		private readonly IBasketRepository _basketRepositor;

		public GetBasketByIdHandler(IBasketRepository basketRepositor)
		{
			_basketRepositor = basketRepositor;
		}

		public async Task<BasketVm> Handle(GetBasketById request, CancellationToken cancellationToken)
		{
			await Task.Delay(100);
			BasketVm basketVm = new BasketVm()
			{
				BasketId = request.BasketId
				, Products = new List<ProductVm>()
			};
			return basketVm;
		}
	}
}
