using Microsoft.EntityFrameworkCore;
using Store.Application.Abstraction;
using Store.Application.CQRS.Baskets.Commands;
using Store.Application.CQRS.Baskets.Queries;
using Store.DataAccess.Entities;
using Store.Domain;

namespace Store.DataAccess.Repositories
{
	public class BasketRepository : AbstractRepository, IBasketRepository
	{
		public BasketRepository(StoreDbContext storeDbContext) : base(storeDbContext)
		{
		}

		public async Task<Basket?> Create(Basket basket)
		{
			BasketEntity? item = await _storeDbContext.BasketEntity.FirstOrDefaultAsync(x => x.BasketId == basket.BasketId);
			if (item == null)
			{
				await _storeDbContext.BasketEntity.AddAsync(new BasketEntity()
				{
					BasketId = basket.BasketId
				});
				return basket;
			}

			return null;
		}

		/*
		public async Task<bool> TrySealed(Guid basketId)
		{
			BasketEntity? item = await _storeDbContext.BasketEntity.FirstOrDefaultAsync(x => x.BasketId == basketId);
			if (item == null)
			{
				return false;
			}
			item.Sealed = true;
			return true;
		}
		*/

		/*
		public async Task<bool> TryAddProductToBasket(Basket basket)
		{
			basket.
		}
		*/
		/*
		BasketVm
		BasketsVm
		*/
		/*
		//добавление в корзину
		//заморозка заказа 
		//все это будет в сервисе здесь только связи 
		public async Task<List<Basket>> GetAsync(CancellationToken cancellationToken, int page, int pageSize)
		{
			
			List<BasketEntity> basketEntityes = await _storeDbContext.BasketEntity
				.Skip(GetOffsetStartPosition(page, pageSize))
				.Take(pageSize)
				.ToListAsync();

			
			List<Basket> basketList = basketEntityes
				.Select(x =>
				{
					Basket b = new Basket(x.BasketId);
					foreach (var item in x.ProductEntities)
					{
						(Product product, string error) product = Product.Create(item.ProductId, item.Title, item.Price);
						if (product.error != string.Empty)
						{
							uint c = x.BasketProductEntities.FirstOrDefault(bc => bc.BasketId == x.BasketId).Count;
							b.AddBasketItem(new BasketItem(product.product, c));
						}
					}
					return b;
				})
				.ToList();

			basketEntityes.ForEach(x =>
			{
				
			});
			
			
			//return basketList;
		}

		public Task<Guid> InsertOrUpdateAsync(Basket basket, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		*/
		public async Task SaveAsync() => await _storeDbContext.SaveChangesAsync();
	}
}
