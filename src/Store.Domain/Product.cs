using Store.DomainShared;

namespace Store.Domain
{
	public class Product
	{
		public const decimal MIN_PRICE = Decimal.Zero;
		public const int MAX_LEN_TITLE = 256;
		public static readonly string ERROR_PRICE_STRING = $"the price must be greater than {MIN_PRICE}.";
		public static readonly string ERROR_TITLE_STRING = $"The title must not be empty or exceed {MAX_LEN_TITLE} characters.";

		private Product(Guid productId, string title, decimal price)
		{
			ProductId = productId;
			Title = title;
			Price = price;
		}
		public Guid ProductId { get; }
		public string Title { get; }
		public decimal Price { get; }
		public static DomainResponseEntity<Product> Create(Guid productId, string title, decimal price)
		{
			if (price < MIN_PRICE)
				return new DomainResponseEntity<Product>()
				{
					IsSuccess = false,
					ErrorDetail = ERROR_PRICE_STRING,
				};

			if (string.IsNullOrEmpty(title) || title.Length > MAX_LEN_TITLE)
				return new DomainResponseEntity<Product>()
				{
					IsSuccess = false,
					ErrorDetail = ERROR_TITLE_STRING,
				};

			return new DomainResponseEntity<Product>()
			{
				Entity = new Product(productId, title, price),
				IsSuccess = true,
			}; ;
		}
	}
}
