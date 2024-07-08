using MediatR;
using Store.Application.Abstraction;
using Store.Application.CQRS.Products.Queries;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketByIdHandler: IRequestHandler<GetBasketById, DomainResponseEntity<Basket>>
	{
		private readonly IBasketRepository _basketRepositor;

		public GetBasketByIdHandler(IBasketRepository basketRepositor)
		{
			_basketRepositor = basketRepositor;
		}

		public async Task<DomainResponseEntity<Basket>> Handle(GetBasketById request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
			/*
			await Task.Delay(100);
			BasketVm basketVm = new BasketVm()
			{
				BasketId = request.BasketId
				, Products = new List<ProductVm>()
			};
			return basketVm;
			*/
		}
	}
}
