namespace Store.DataAccess.Repositories
{
	public class AbstractRepository
	{
		protected readonly StoreDbContext _storeDbContext;

		public AbstractRepository(StoreDbContext storeDbContext)
		{
			_storeDbContext = storeDbContext;
		}

		private bool _disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_storeDbContext.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
