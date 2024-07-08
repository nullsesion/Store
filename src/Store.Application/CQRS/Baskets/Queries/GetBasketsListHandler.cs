using MediatR;
using Store.Application.Abstraction;
using Store.Application.CQRS.Products.Queries;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketsListHandler: IRequestHandler<GetBasketsList, DomainResponseEntity<Basket>>
	{
		private readonly IBasketRepository _basketRepository;

		public GetBasketsListHandler(IBasketRepository basketRepository)
		{
			_basketRepository = basketRepository;
		}

		public async Task<DomainResponseEntity<Basket>> Handle(GetBasketsList request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
			/*
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
			*/
		}
	}
}
