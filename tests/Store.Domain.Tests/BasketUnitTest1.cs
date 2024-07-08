using Store.DomainShared;

namespace Store.Domain.Tests
{
	[TestClass]
	public class BasketUnitTest1
	{
		[TestMethod]
		public void Try_Create_BasketWithotProduct_NULL_BasketReturned()
		{
			DomainResponseEntity<Basket> basket = Basket.Create(Guid.NewGuid());
			Assert.AreEqual(true, basket.IsSuccess);
			if (basket.Entity != null) 
				Assert.AreEqual(0, basket.Entity.Position.ToList().Count);
			else
				Assert.Fail();
		}
		
		[TestMethod]
		public void Basket_2position_3product_2positionReturned()
		{
			DomainResponseEntity<Basket> basket = Basket.Create(Guid.NewGuid());
			var product1 = Product.Create(Guid.NewGuid(), "Test 1", 100);
			var product2 = Product.Create(Guid.NewGuid(), "Test 2", 100);

			if (basket.Entity != null)
			{
				basket.Entity.AddBasketItem(new BasketItem() { Product = product1.Entity });
				basket.Entity.AddBasketItem(new BasketItem() { Product = product2.Entity, Count = 2 });

				Assert.AreEqual(2, basket.Entity.Position.ToList().Count);
			}
			else
				Assert.Fail();
		}

		[TestMethod]
		public void Basket_TotalPrice_2Position_3Product_By100_300Returned()
		{
			var basket = Basket.Create(Guid.NewGuid());
			var product1 = Product.Create(Guid.NewGuid(), "Test 1", 100);
			var product2 = Product.Create(Guid.NewGuid(), "Test 2", 100);
			if (basket.Entity != null)
			{
				basket.Entity.AddBasketItem(new BasketItem() { Product = product1.Entity });
				basket.Entity.AddBasketItem(new BasketItem() { Product = product2.Entity, Count = 2 });

				decimal totalPrice = basket.Entity.TotalPrice();
				Assert.AreEqual(300, totalPrice);
			}
			else
				Assert.Fail();
		}

		[TestMethod]
		public void Basket_Sealed_Edit_ErrorReturned()
		{
			var basket = Basket.Create(Guid.NewGuid());
			var product1 = Product.Create(Guid.NewGuid(), "Test 1", 100);

			if (basket.Entity != null)
			{
				basket.Entity.AddBasketItem(new BasketItem() { Product = product1.Entity, Count = 0 });
				var testSetSeal = basket.Entity.SetSealTheBasket();
				Assert.AreEqual(false, testSetSeal.IsSuccess);
			}
			else
				Assert.Fail();
		}

		[TestMethod]
		public void Basket_Edit_After_Sealed_ErrorReturned()
		{
			var basket = Basket.Create(Guid.NewGuid());
			var product1 = Product.Create(Guid.NewGuid(), "Test 1", 100);
			var product2 = Product.Create(Guid.NewGuid(), "Test 2", 100);

			if (basket.Entity != null)
			{
				basket.Entity.AddBasketItem(new BasketItem() { Product = product1.Entity });
				var testSetSeal = basket.Entity.SetSealTheBasket();
				var testAfterSetSeal = basket.Entity.AddBasketItem(new BasketItem() { Product = product2.Entity });

				Assert.AreEqual(false, testAfterSetSeal.IsSuccess);
			}
			else
				Assert.Fail();
		}

		[TestMethod]
		public void Basket_Product200Product2Count_Increment_After_Sealed_200Returned()
		{
			var basket = Basket.Create(Guid.NewGuid());
			Guid productGuid = Guid.NewGuid();
			var product1 = Product.Create(productGuid, "Test 1", 100);

			if (basket.Entity != null)
			{
				basket.Entity.AddBasketItem(new BasketItem() { Product = product1.Entity, Count = 2 });
				basket.Entity.SetSealTheBasket();
				basket.Entity.IncrementPosition(productGuid);

				Assert.AreEqual(200, basket.Entity.TotalPrice());
			}
			else
				Assert.Fail();
		}

		[TestMethod]
		public void Basket_Product200Product2Count_Increment__300Returned()
		{
			var basket = Basket.Create(Guid.NewGuid());
			Guid productGuid = Guid.NewGuid();
			var product1 = Product.Create(productGuid, "Test 1", 100);

			if (basket.Entity != null)
			{
				basket.Entity.AddBasketItem(new BasketItem() { Product = product1.Entity, Count = 2 });
				basket.Entity.IncrementPosition(productGuid);

				Assert.AreEqual(300, basket.Entity.TotalPrice());
			}
			else
				Assert.Fail();
		}

		[TestMethod]
		public void Basket_Product200Product2Count_Decrement_100Returned()
		{
			var basket = Basket.Create(Guid.NewGuid());
			Guid productGuid = Guid.NewGuid();
			var product1 = Product.Create(productGuid, "Test 1", 100);

			if (basket.Entity != null)
			{
				basket.Entity.AddBasketItem(new BasketItem() { Product = product1.Entity, Count = 2 });
				basket.Entity.DecrementPosition(productGuid);

				Assert.AreEqual(100, basket.Entity.TotalPrice());
			}
			else
				Assert.Fail();
		}


		[TestMethod]
		public void Add_2Product_ProductCount2Returned()
		{
			//arrange
			var basket = Basket.Create(Guid.NewGuid());
			Guid productGuid = Guid.NewGuid();
			var product1 = Product.Create(productGuid, "Test 1", 100);
			var product2 = Product.Create(productGuid, "Test 1", 100);

			//act
			if (basket.Entity != null)
			{
				basket.Entity.AddBasketItem(new BasketItem() { Product = product1.Entity, Count = 2 });
				basket.Entity.AddBasketItem(new BasketItem() { Product = product2.Entity, Count = 2 });

				uint act = basket.Entity
					.GetProductsPosition()
					.First(x => x.productId == productGuid)
					.Count;
				//assert
				uint exp = 4;
				Assert.AreEqual(exp, act);
			}
			else
				Assert.Fail();
		}
	}
}
