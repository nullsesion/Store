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

	public async Task<List<Product>> GetAsync(CancellationToken cancellationToken, int page = 1, int pageSize = 10)
	{
		List<ProductEntity> productEntities = await _storeDbContext.ProductEntities
			.AsNoTracking()
			.Skip(pageSize * (page - 1 > 0 ? page - 1 : 0))
			.Take(pageSize)
			.ToListAsync(cancellationToken);

		List<Product> products = productEntities
			.Select(x => Product.Create(x.ProductId, x.Title, x.Price).product)
			.ToList();
		return products;
	}

	public async Task<Guid> InsertOrUpdateAsync(Product product, CancellationToken cancellationToken)
	{
		ProductEntity? productEntityFromDb =
			await _storeDbContext.ProductEntities.FirstOrDefaultAsync(x => x.ProductId == product.ProductId, cancellationToken);
		if (productEntityFromDb is null)
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
		productEntityFromDb.Price = product.Price;
		productEntityFromDb.Title = product.Title;
		return product.ProductId;
	}

	public async Task SaveAsync() => await _storeDbContext.SaveChangesAsync();
}