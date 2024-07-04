namespace Store.Domain
{
	public class Basket
	{
		const string ERROR_EDIT_SEALED = "error edit basket, basket sealed";
		const string ERROR_NOT_CONTAIN_PRODUCT = "error basket sealed";

		public Basket(Guid basketId, List<Product> products)
		{
			BasketId = basketId;
		}

		public (bool IsResult, string IsError) AddProduct(Product product)
		{
			if (Sealed)
				return (false, ERROR_EDIT_SEALED);

			Products.Add(product);
			return (true, string.Empty);
		}

		public (bool isResult, string error) RemoveProduct(Guid productId)
		{
			if (Sealed)
				return (false, ERROR_EDIT_SEALED);

			Products.RemoveAll(x => x.ProductId == productId);
			return (true, string.Empty);
		}

		public (bool isResult, string error) SealTheBasket()
		{
			if (Products.Count == 0)
			{
				return (false, ERROR_NOT_CONTAIN_PRODUCT);
			}
			Sealed = true;
			return (true, string.Empty);
		}

		public (Basket basket, string error) CreateSealed(Guid basketId, List<Product> products)
		{
			Basket basket = new Basket(basketId, products);
			if (products.Count == 0)
			{
				return (basket, ERROR_NOT_CONTAIN_PRODUCT);
			}

			Sealed = true;
			return (basket, string.Empty);
		}

		public Guid BasketId { get; }
		//public string JsonProducts { get; } = string.Empty;
		public bool Sealed { get; private set; }
		private List<Product> Products { get; }
	}
}
