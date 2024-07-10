using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstraction;
using Store.Application.CQRS.Baskets.Commands;
using Store.Application.CQRS.Baskets.Queries;
using Store.DataAccess.Entities;
using Store.Domain;
using Store.DomainShared;

namespace Store.DataAccess.Repositories
{
	public class BasketRepository : AbstractRepository, IBasketRepository
	{
		private const string BASKET_EXIST = "Basket already exists";
		private const string BASKET_NOT_FOUND = "Basket not found";
		public BasketRepository(StoreDbContext storeDbContext) : base(storeDbContext)
		{
		}
		public async Task<DomainResponseEntity<Basket>> Create(Basket basket, CancellationToken cancellationToken)
		{
			DomainResponseEntity<Basket> domainResponseEntity = new DomainResponseEntity<Basket>();
			BasketEntity? item =
				await _storeDbContext
					.BasketEntity
					.FirstOrDefaultAsync(x => x.BasketId == basket.BasketId, cancellationToken);
			if (item == null)
			{
				await _storeDbContext.BasketEntity.AddAsync(new BasketEntity()
				{
					BasketId = basket.BasketId
				}, cancellationToken);
				domainResponseEntity.IsSuccess = true;
				domainResponseEntity.Entity = basket;
			}

			domainResponseEntity.ErrorDetail = BASKET_EXIST;
			return domainResponseEntity;
		}

		public async Task<DomainResponseEntity<Basket>> GetByID(Guid id, CancellationToken cancellationToken)
		{
			DomainResponseEntity<Basket> domainResponseEntity = new DomainResponseEntity<Basket>();
			BasketEntity? item =
				await _storeDbContext
					.BasketEntity
					.FirstOrDefaultAsync(x => x.BasketId == id, cancellationToken);
			if (item == null)
			{
				domainResponseEntity.ErrorDetail = BASKET_NOT_FOUND;
				return domainResponseEntity;
			}

			//todo: horror refact after installing ling2db
			DomainResponseEntity<Basket> basket = Basket.Create(item.BasketId);
			List<BasketProductEntity> productsFromBasket = await _storeDbContext
				.BasketProductEntities
				.Where(x => x.BasketId == item.BasketId)
				.ToListAsync()
				;

			var positions = productsFromBasket
				.Select(x => (x.ProductId, x.Count));

			//cancellationToken
			List<ProductEntity> products = await _storeDbContext
				.ProductEntities
				.Where(x =>
					positions
						.Select(c => c.ProductId)
						.Contains(x.ProductId))
				.ToListAsync();
			
			foreach (var position in positions)
			{
				ProductEntity p = products.First(x => x.ProductId == position.ProductId);
				DomainResponseEntity<Product> product = Product.Create(p.ProductId, p.Title, p.Price);

				if (product.IsSuccess)
				{
					basket
						.Entity
						.AddBasketItem(new BasketItem()
						{
							Product = product.Entity,
							Count = position.Count
						});
				}
			}
			
			return basket;
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
