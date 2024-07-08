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
			//request.BasketId
			DomainResponseEntity<Basket> b = Basket.Create(request.BasketId);
			
			Basket? res = await _basketRepository.Create(b.Entity);
			var basketCreatorInfo = new DomainResponseEntity<Basket>();
			if (res == null)
				basketCreatorInfo.ErrorDetail = "Error create Basket";
			else
				basketCreatorInfo.IsSuccess = true;

			await _basketRepository.SaveAsync();

			return basketCreatorInfo;
		}
	}
}
