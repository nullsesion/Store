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
		public static readonly string ERROR_PRICE_STRING = $"the price must be greater than {MIN_PRICE}.";
		public static readonly string ERROR_TITLE_STRING = $"The title must not be empty or exceed {MAX_LEN_TITLE} characters.";

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
			if (price < MIN_PRICE)
				return (null, ERROR_PRICE_STRING);

			if (string.IsNullOrEmpty(title) || title.Length > MAX_LEN_TITLE)
				return (null, ERROR_TITLE_STRING);

			return (new Product(productId, title, price), String.Empty);
		}
	}
}
