using MediatR;
using Store.Application.Abstraction;
using Store.Domain;

namespace Store.Application.CQRS.Baskets.Commands
{
	public class CreateBasketHandler: IRequestHandler<CreateBasket,BasketCreatorInfo>
	{
		private readonly IBasketRepository _basketRepositor;

		public CreateBasketHandler(IBasketRepository basketRepositor)
		{
			_basketRepositor = basketRepositor;
		}

		public async Task<BasketCreatorInfo> Handle(CreateBasket request, CancellationToken cancellationToken)
		{
			Basket basket = new Basket(request.BasketId);
			await Task.Delay(100);
			BasketCreatorInfo basketCreatorInfo = new BasketCreatorInfo()
			{
				BasketId = Guid.Empty
				, IsError = "Not Implementation"
			};
			return basketCreatorInfo;
		}
	}
}
