namespace Store.Domain
{
	public class Basket
	{
		const string ERROR_EDIT_SEALED = "error edit basket, basket sealed";
		const string ERROR_BASKET_EMPTY = "error basket empty";
		
		public Guid BasketId { get; }
		public bool Sealed { get; private set; }
		public List<BasketItem> Position { get; private set; }

		public Basket(Guid basketId)
		{
			BasketId = basketId;
			Position = new List<BasketItem>();
		}

		public (bool IsResult, string IsError) AddBasketItem(BasketItem product)
		{
			if (Sealed)
				return (false, ERROR_EDIT_SEALED);

			Position.Add(product);
			return (true, string.Empty);
		}

		public (bool isResult, string error) RemoveBasketPosition(Guid productId)
		{
			if (Sealed)
				return (false, ERROR_EDIT_SEALED);

			Position
				.ToList()
				.RemoveAll(x => x.Product.ProductId == productId);

			return (true, string.Empty);
		}

		public bool IncrementPosition(Guid productId)
		{
			if (Sealed)
				return false;

			BasketItem? item = Position.FirstOrDefault(x => x.Product.ProductId == productId);
			if (item != null)
			{
				item.Count++;
				return true;
			}
			return false;
		}

		public bool DecrementPosition(Guid productId)
		{
			if (Sealed)
				return false;

			BasketItem? item = Position.FirstOrDefault(x => x.Product.ProductId == productId);
			if (item != null && item.Count > 0)
			{
				item.Count--;
				return true;
			}
			return false;
		}

		public (bool IsResult, string error) SetSealTheBasket()
		{
			Position = RemoveEmptyBasketItem();
			if (Position.ToList().Count == 0)
			{
				return (false, ERROR_BASKET_EMPTY);
			}
			Sealed = true;
			return (true, string.Empty);
		}

		/*
		public (Basket basket, string error) CreateSealed(Guid basketId, IEnumerable<BasketItem> products)
		{
			Basket basket = new Basket(basketId);
			//todo: add product

			if (products.ToList().Count == 0)
			{
				return (basket, ERROR_BASKET_EMPTY);
			}

			Sealed = true;
			return (basket, string.Empty);
		}
		*/

		public decimal TotalPrice()
		{
			return Position
				.Select(x => x.Product.Price * x.Count)
				.Sum();
		}

		private List<BasketItem> RemoveEmptyBasketItem()
		{
			return Position.Where(x => x.Count > 0).ToList();
			
		}
	}
}
