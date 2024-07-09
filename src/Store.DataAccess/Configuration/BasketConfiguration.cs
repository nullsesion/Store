using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Configuration
{
	public class BasketConfiguration: IEntityTypeConfiguration<BasketEntity>
	{
		public void Configure(EntityTypeBuilder<BasketEntity> builder)
		{
			builder.HasKey(e => e.BasketId).HasName("basket_pk");

			builder.ToTable("Basket");

			builder.Property(e => e.BasketId).ValueGeneratedNever();

			builder.Property(e => e.JsonProducts)
				.HasDefaultValueSql("'{}'::jsonb")
				.HasColumnType("jsonb");

			builder.Property(e => e.Sealed).HasDefaultValue(false);
		}
	}
}
