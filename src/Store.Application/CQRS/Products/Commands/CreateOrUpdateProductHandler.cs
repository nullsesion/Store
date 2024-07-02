using MediatR;
using Store.Application.Abstraction;
using Store.Application.CQRS.Products.Queries;
using Store.Domain;

namespace Store.Application.CQRS.Products.Commands;

public class CreateOrUpdateProductHandler: IRequestHandler<CreateOrUpdateProduct, ProductCreatorInfo>
{
	private readonly IProductsRepository _productsRepository;

	public CreateOrUpdateProductHandler(IProductsRepository productsRepository)
	{
		_productsRepository = productsRepository;
	}

	public async Task<ProductCreatorInfo> Handle(CreateOrUpdateProduct request, CancellationToken cancellationToken)
	{
		(Product product, string error) product = Product.Create(request.ProductId, request.Title, request.Price);
		if (!string.IsNullOrEmpty(product.error))
		{
			return new ProductCreatorInfo()
			{
				ProductId = Guid.Empty
				, IsError = product.error
			};
		}

		await _productsRepository.InsertOrUpdateAsync(product.product,cancellationToken);
		await _productsRepository.SaveAsync();

		return new ProductCreatorInfo() { ProductId = product.product.ProductId };
	}
}