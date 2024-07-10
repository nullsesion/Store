using MediatR;
using Store.Application.Abstraction;
using Store.Application.CQRS.Products.Queries;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketByIdHandler: IRequestHandler<GetBasketById, DomainResponseEntity<Basket>>
	{
		private readonly IBasketRepository _basketRepository;

		public GetBasketByIdHandler(IBasketRepository basketRepository)
		{
			_basketRepository = basketRepository;
		}

		public async Task<DomainResponseEntity<Basket>> Handle(GetBasketById request, CancellationToken cancellationToken)
		{
			DomainResponseEntity<Basket> basket = await _basketRepository.GetByID(request.BasketId, cancellationToken);
			return basket;
		}
	}
}
