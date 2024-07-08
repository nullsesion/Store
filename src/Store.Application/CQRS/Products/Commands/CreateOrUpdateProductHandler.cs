using MediatR;
using Store.Application.Abstraction;
using Store.Application.CQRS.Products.Queries;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Products.Commands;

public class CreateOrUpdateProductHandler: IRequestHandler<CreateOrUpdateProduct, DomainResponseEntity<Product>>
{
	private readonly IProductsRepository _productsRepository;

	public CreateOrUpdateProductHandler(IProductsRepository productsRepository)
	{
		_productsRepository = productsRepository;
	}

	public async Task<DomainResponseEntity<Product>> Handle(CreateOrUpdateProduct request, CancellationToken cancellationToken)
	{
		DomainResponseEntity<Product> product = Product.Create(request.ProductId, request.Title, request.Price);
		if (product.IsSuccess)
		{
			await _productsRepository.InsertOrUpdateAsync(product.Entity, cancellationToken);
			await _productsRepository.SaveAsync();
		}

		return product;
	}
}