using Store.Domain;

namespace Store.Application.Abstraction;

public interface IProductsRepository
{
	Task<List<Product>> GetAsync(CancellationToken cancellationToken, int Page, int PageSize);
	Task<Guid> InsertOrUpdateAsync(Product product, CancellationToken cancellationToken);
	Task SaveAsync();
}