using MediatR;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketsList: AbstractRequestPages, IRequest<DomainResponseEntity<Basket>>
	{

	}
}
