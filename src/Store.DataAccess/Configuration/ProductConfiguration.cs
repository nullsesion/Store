using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataAccess.Entities;
using Store.Domain;

namespace Store.DataAccess.Configuration
{
	public class ProductConfiguration: IEntityTypeConfiguration<ProductEntity>
	{
		public void Configure(EntityTypeBuilder<ProductEntity> builder)
		{
			builder.HasKey(e => e.ProductId).HasName("product_pk");

			builder.ToTable("Product");

			builder.Property(e => e.ProductId)
				.ValueGeneratedNever();
			builder.Property(e => e.Title)
				.HasMaxLength(Product.MAX_LEN_TITLE);
			builder.Property(e => e.Price)
				.IsRequired()
				.HasColumnName("Price");
		}
	}
}
