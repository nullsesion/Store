using MediatR;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Commands
{
	public class CreateBasket: IRequest<DomainResponseEntity<Basket>>
	{
		public Guid BasketId { get; set; }
	}
}
