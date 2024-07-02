using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain
{
	public class Product
	{
		public const decimal MIN_PRICE = Decimal.Zero;
		public const int MAX_LEN_TITLE = 256;
		public Product(Guid productId, string title, decimal price)
		{
			ProductId = productId;
			Title = title;
			Price = price;
		}
		public Guid ProductId { get; }
		public string Title { get; }
		public decimal Price { get; }
		public static (Product product, string error) Create(Guid productId, string title, decimal price)
		{
			if (price <= MIN_PRICE)
				return (null, $"the price must be greater than {MIN_PRICE}.");

			if (string.IsNullOrEmpty(title) || title.Length > MAX_LEN_TITLE)
				return (null, $"The title must not be empty or exceed {MAX_LEN_TITLE} characters.");

			return (new Product(productId, title, price), String.Empty);
		}
	}
}
