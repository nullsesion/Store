using Store.DomainShared;

namespace Store.Domain
{
	public class Basket
	{
		const string ERROR_EDIT_SEALED = "error edit basket, basket sealed";
		const string ERROR_BASKET_EMPTY = "error basket empty";
		const string ERROR_GUID = "error Guid";

		public Guid BasketId { get; }
		public bool Sealed { get; private set; }
		public List<BasketItem> Position { get; private set; }

		private Basket(Guid basketId)
		{
			BasketId = basketId;
			Position = new List<BasketItem>();
		}

		public static DomainResponseEntity<Basket> Create(Guid basketId)
		{
			var entity = new DomainResponseEntity<Basket>();
			if (basketId == Guid.Empty)
				entity.ErrorDetail = ERROR_GUID;
			else
			{
				entity.IsSuccess = true;
				entity.Entity = new Basket(basketId);
			}
			return entity;
		}

		public DomainResponseEntity<Basket> AddBasketItem(BasketItem product)
		{
			if (Sealed)
				return new DomainResponseEntity<Basket>()
				{
					ErrorDetail = ERROR_EDIT_SEALED,
				};

			BasketItem? pos = Position.FirstOrDefault(x => x.Product.ProductId == product.Product.ProductId);
			if (pos == null)
			{
				Position.Add(product);
			}
			else
			{
				pos.Count = pos.Count + product.Count;
			}
			
			return new DomainResponseEntity<Basket>()
			{
				IsSuccess = true,
				Entity = this,
			};
		}

		public DomainResponseEntity<Basket> RemoveBasketPosition(Guid productId)
		{
			if (Sealed)
				return new DomainResponseEntity<Basket>()
				{
					ErrorDetail = ERROR_EDIT_SEALED,
				};

			Position
				.ToList()
				.RemoveAll(x => x.Product.ProductId == productId);

			return new DomainResponseEntity<Basket>()
			{
				IsSuccess = true,
				Entity = this,
			};
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

		public DomainResponseEntity<Basket> SetSealTheBasket()
		{
			Position = RemoveEmptyBasketItem();
			if (Position.ToList().Count == 0)
			{
				return new DomainResponseEntity<Basket>()
				{
					ErrorDetail = ERROR_BASKET_EMPTY,
				};
			}
			Sealed = true;
			return new DomainResponseEntity<Basket>()
			{
				IsSuccess = true,
				Entity = this,
			};
		}

		public List<(Guid productId, uint Count)> GetProductsPosition()
		{
			return Position
				.Select(x => (x.Product.ProductId, x.Count))
				.ToList();
		}

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
