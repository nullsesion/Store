using MediatR;
using Store.Application.Abstraction;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Commands
{
	public class CreateBasketHandler: IRequestHandler<CreateBasket, DomainResponseEntity<Basket>>
	{
		private readonly IBasketRepository _basketRepository;

		public CreateBasketHandler(IBasketRepository basketRepository)
		{
			_basketRepository = basketRepository;
		}

		public async Task<DomainResponseEntity<Basket>> Handle(CreateBasket request, CancellationToken cancellationToken)
		{
			DomainResponseEntity<Basket> b = Basket.Create(request.BasketId);
			DomainResponseEntity<Basket> basketCreatorInfo = await _basketRepository.Create(b.Entity, cancellationToken);
			if (basketCreatorInfo.IsSuccess)
			{
				await _basketRepository.SaveAsync();
				return basketCreatorInfo;
			}

			return basketCreatorInfo;
		}
	}
}
