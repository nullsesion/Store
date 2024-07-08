using MediatR;
using Store.Application.Abstraction;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Products.Queries
{
	public class GetProductsHandler: IRequestHandler<GetProducts, DomainResponseEntity<List<Product>>>
	{
		private readonly IProductsRepository _productsRepository;

		public GetProductsHandler(IProductsRepository productsRepository)
		{
			_productsRepository = productsRepository;
		}

		public async Task<DomainResponseEntity<List<Product>>> Handle(GetProducts request, CancellationToken cancellationToken)
		{
			List<Product> p = await _productsRepository.GetAsync(cancellationToken, request.Page, request.PageSize);

			DomainResponseEntity<List<Product>> listProducts = new DomainResponseEntity<List<Product>>();
			if (p == null || p.Count == 0)
				listProducts.ErrorDetail = "Not Found";
			else
				listProducts.Entity = p;

			return listProducts;
		}
	}
}
