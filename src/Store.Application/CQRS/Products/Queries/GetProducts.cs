using MediatR;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Products.Queries
{
	public class GetProducts: AbstractRequestPages, IRequest<DomainResponseEntity<List<Product>>>
	{

	}
}
