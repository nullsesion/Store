using MediatR;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketById : IRequest<DomainResponseEntity<Basket>>
	{
		public Guid BasketId { get; set; }
	}
}
