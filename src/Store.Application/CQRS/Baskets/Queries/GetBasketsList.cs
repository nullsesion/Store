using MediatR;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketsList: AbstractRequestPages, IRequest<BasketsVm>
	{

	}
}
