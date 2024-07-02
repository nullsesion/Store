using Microsoft.EntityFrameworkCore;
using Store.Application.Abstraction;
using Store.DataAccess.Entities;
using Store.Domain;

namespace Store.DataAccess.Repositories;

public class ProductsRepository: AbstractRepository, IProductsRepository
{
	public ProductsRepository(StoreDbContext storeDbContext) : base(storeDbContext)
	{
	}

	public async Task<List<Product>> GetAsync(CancellationToken cancellationToken, int Page = 1, int PageSize = 10)
	{
		List<ProductEntity> productEntities = await _storeDbContext.ProductEntities
			.AsNoTracking()
			.Skip(PageSize * (Page - 1 > 0 ? Page - 1 : 0))
			.Take(PageSize)
			.ToListAsync();

		List<Product> products = productEntities
			.Select(x => Product.Create(x.ProductId, x.Title, x.Price).product)
			.ToList();
		return products;
	}

	public async Task<Guid> InsertOrUpdateAsync(Product product, CancellationToken cancellationToken)
	{
		ProductEntity productEntity = new ProductEntity()
		{
			ProductId = product.ProductId,
			Title = product.Title,
			Price = product.Price,
		};
		await _storeDbContext.ProductEntities.AddAsync(productEntity, cancellationToken);
		return product.ProductId;
	}

	public async Task SaveAsync() => await _storeDbContext.SaveChangesAsync();
}