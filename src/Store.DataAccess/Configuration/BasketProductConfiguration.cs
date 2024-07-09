using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Configuration
{
	public class BasketProductConfiguration: IEntityTypeConfiguration<BasketProductEntity>
	{
		public void Configure(EntityTypeBuilder<BasketProductEntity> builder)
		{
			builder.ToTable("BasketProduct");
			builder.HasKey(e => new { e.ProductId, e.BasketId });

			builder.HasIndex(e => e.ProductId, "IX_BasketProduct_productid");

			builder.HasIndex(e => new { e.BasketId, e.ProductId }, "basketproduct_basketid_idx").IsUnique();

			builder.Property(e => e.BasketId).HasColumnName("BasketId");
			builder.Property(e => e.ProductId).HasColumnName("ProductId");
			builder.Property(e => e.Count).HasColumnName("Count");

			/*
			builder.HasOne(d => d.BasketEntity).WithMany()
				.HasForeignKey(d => d.BasketId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("basketproduct_basket_fk");

			builder.HasOne(d => d.ProductEntity).WithMany()
				.HasForeignKey(d => d.ProductId)
				.OnDelete(DeleteBehavior.ClientSetNull)
				.HasConstraintName("basketproduct_product_fk");
			*/
		}
	}
}
