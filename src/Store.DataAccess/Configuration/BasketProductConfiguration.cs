using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Configuration
{
	public class BasketProductConfiguration: IEntityTypeConfiguration<BasketProductEntity>
	{
		public void Configure(EntityTypeBuilder<BasketProductEntity> builder)
		{
			builder.HasKey(e => new { e.ProductId, e.BasketId });

			builder.ToTable("BasketProduct");

			builder.HasOne(d => d.BasketEntity).WithMany(p => p.BasketProducts)
					.HasForeignKey(d => d.BasketId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("basketproduct_basket_fk");

			builder.HasOne(d => d.ProductEntity).WithMany(p => p.BasketProducts)
					.HasForeignKey(d => d.ProductId)
					.OnDelete(DeleteBehavior.ClientSetNull)
					.HasConstraintName("basketproduct_product_fk");

			builder.Property(e => e.Count).HasColumnName("Count");
		}
	}
}
