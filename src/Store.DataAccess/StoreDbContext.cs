using Microsoft.EntityFrameworkCore;
using Store.Application.Abstraction;
using Store.DataAccess.Configuration;
using Store.DataAccess.Entities;

namespace Store.DataAccess
{

	public class StoreDbContext: DbContext, IStoreDbContext
	{
		public StoreDbContext(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new ProductConfiguration());
			builder.ApplyConfiguration(new BasketConfiguration());
			builder.ApplyConfiguration(new BasketProductConfiguration());
			base.OnModelCreating(builder);
		}
		public DbSet<ProductEntity> ProductEntities { get; set; }
		public DbSet<BasketEntity> BasketEntity { get; set; }
		public DbSet<BasketProductEntity> BasketProductEntities { get; set; }

	}
}
