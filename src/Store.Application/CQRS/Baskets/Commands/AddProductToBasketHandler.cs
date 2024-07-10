using MediatR;
using Store.Application.Abstraction;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Commands
{
	public class AddProductToBasketHandler: IRequestHandler<AddProductToBasket, DomainResponseEntity<Basket>>
	{
		private readonly IBasketRepository _basketRepository;
		private readonly IProductsRepository _productsRepository;

		public AddProductToBasketHandler(IBasketRepository basketRepository, IProductsRepository productsRepository)
		{
			_basketRepository = basketRepository;
			_productsRepository = productsRepository;
		}

		public async Task<DomainResponseEntity<Basket>> Handle(AddProductToBasket request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
			/*
			DomainResponseEntity<Basket> domainResponseEntityBasket = new DomainResponseEntity<Basket>();
			var basket = await _basketRepository.GetByID(request.BasketId);
			if (basket == null)
				return domainResponseEntityBasket.ErrorDetail = "Basket Not Found";

			*/
		}
	}
}
