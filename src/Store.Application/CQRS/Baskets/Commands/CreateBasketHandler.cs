using MediatR;
using Store.Application.Abstraction;
using Store.Domain;

namespace Store.Application.CQRS.Baskets.Commands
{
	public class CreateBasketHandler: IRequestHandler<CreateBasket,BasketCreatorInfo>
	{
		private readonly IBasketRepository _basketRepository;

		public CreateBasketHandler(IBasketRepository basketRepository)
		{
			_basketRepository = basketRepository;
		}

		public async Task<BasketCreatorInfo> Handle(CreateBasket request, CancellationToken cancellationToken)
		{
			//request.BasketId
			Basket? res = await _basketRepository.Create(new Basket(request.BasketId));
			if (res == null)
			{
				BasketCreatorInfo basketCreatorInfo = new BasketCreatorInfo()
				{
					BasketId = Guid.Empty, 
					IsError = "Already exists",
				};
			}

			await _basketRepository.SaveAsync();

			return new BasketCreatorInfo()
			{
				BasketId = request.BasketId
			}; 
		}
	}
}
