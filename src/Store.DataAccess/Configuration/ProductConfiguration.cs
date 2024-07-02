using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.DataAccess.Entities;

namespace Store.DataAccess.Configuration
{
	public class ProductConfiguration: IEntityTypeConfiguration<ProductEntity>
	{
		public void Configure(EntityTypeBuilder<ProductEntity> builder)
		{
			builder.ToTable("Product");

			builder.HasKey(e => e.ProductId)
				.HasName("product_pk")
				;

			builder.Property(e => e.ProductId)
				.ValueGeneratedNever()
				.HasColumnName("ProductId")
				;

			builder.Property(e => e.Title)
				.IsRequired()
				.HasMaxLength(255)
				.HasColumnName("Title")
				;

			builder.Property(e => e.Price)
				.IsRequired()
				.HasColumnName("Price")
				;
		}
	}
}
