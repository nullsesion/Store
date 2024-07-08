using MediatR;

namespace Store.Application.CQRS.Products.Queries
{
	public class GetProducts: AbstractRequestPages, IRequest<ProductsVm>
	{

	}
}
