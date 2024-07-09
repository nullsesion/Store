using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Configuration
{
	public class BasketConfiguration: IEntityTypeConfiguration<BasketEntity>
	{
		public void Configure(EntityTypeBuilder<BasketEntity> builder)
		{
			builder.ToTable("Basket");

			builder.HasKey(e => e.BasketId).HasName("basket_pk");

			builder.Property(e => e.BasketId)
				.ValueGeneratedNever()
				.HasColumnName("BasketId");

			builder.Property(e => e.JsonProducts)
				.IsRequired(false)
				.HasColumnType("jsonb");

			builder.Property(e => e.Sealed)
				.HasDefaultValue(false);

			//builder.Property(e => e.ProductEntities);
			//builder.HasMany<BasketProductEntity>();
		}
	}
}
