using MediatR;
using Store.Application.Abstraction;
using Store.Domain;

namespace Store.Application.CQRS.Products.Queries
{
	public class GetProductsHandler: IRequestHandler<GetProducts,ProductsVm>
	{
		private readonly IProductsRepository _productsRepository;

		public GetProductsHandler(IProductsRepository productsRepository)
		{
			_productsRepository = productsRepository;
		}

		public async Task<ProductsVm> Handle(GetProducts request, CancellationToken cancellationToken)
		{
			List<Product> p = await _productsRepository.GetAsync(cancellationToken, request.Page, request.PageSize);

			//add automapper
			List<ProductVm> products = p
				.Select(x => new ProductVm()
				{
					ProductId = x.ProductId
					, Title = x.Title
					, Price = x.Price
				})
				.ToList();

			return new ProductsVm() { Products = products };
		}
	}
}
