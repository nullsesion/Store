using MediatR;
using Store.Application.Abstraction;
using Store.Application.CQRS.Products.Queries;
using Store.Domain;

namespace Store.Application.CQRS.Products.Commands;

public class CreateOrUpdateProductHandler: IRequestHandler<CreateOrUpdateProduct,Guid>
{
	private readonly IProductsRepository _productsRepository;

	public CreateOrUpdateProductHandler(IProductsRepository productsRepository)
	{
		_productsRepository = productsRepository;
	}

	public async Task<Guid> Handle(CreateOrUpdateProduct request, CancellationToken cancellationToken)
	{
		(Product product, string error) product = Product.Create(request.ProductId, request.Title, request.Price);
		if (!string.IsNullOrEmpty(product.error))
		{
			throw new Exception(product.error);
		}

		await _productsRepository.InsertOrUpdateAsync(product.product,cancellationToken);
		await _productsRepository.SaveAsync();

		return product.product.ProductId;
	}
}