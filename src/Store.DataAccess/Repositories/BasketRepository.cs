
namespace Store.DataAccess.Repositories
{
	public class BasketRepository : AbstractRepository
	{
		public BasketRepository(StoreDbContext storeDbContext) : base(storeDbContext)
		{
		}

		/*
		public Task<List<Basket>> GetAsync(CancellationToken cancellationToken, int Page, int PageSize)
		{
			throw new NotImplementedException();
		}

		public Task<Guid> InsertOrUpdateAsync(Basket basket, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		*/
		public async Task SaveAsync() => await _storeDbContext.SaveChangesAsync();
	}
}
