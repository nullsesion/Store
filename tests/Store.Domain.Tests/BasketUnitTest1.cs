using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Tests
{
	[TestClass]
	public class BasketUnitTest1
	{
		[TestMethod]
		public void Try_Create_BasketWithotProduct_NULL_BasketReturned()
		{
			Basket basket = new Basket(Guid.NewGuid());
			Assert.AreEqual(0, basket.Position.ToList().Count);
		}

		[TestMethod]
		public void Basket_2position_3product_2positionReturned()
		{
			Basket basket = new Basket(Guid.NewGuid());
			(Product product, string error) product1 = Product.Create(Guid.NewGuid(), "Test 1", 100);
			(Product product, string error) product2 = Product.Create(Guid.NewGuid(), "Test 2", 100);
			
			basket.AddBasketItem(new BasketItem() { Product = product1.product });
			basket.AddBasketItem(new BasketItem() { Product = product2.product, Count = 2 });
			
			Assert.AreEqual(2, basket.Position.ToList().Count);
		}

		[TestMethod]
		public void Basket_TotalPrice_2Position_3Product_By100_300Returned()
		{
			Basket basket = new Basket(Guid.NewGuid());
			(Product product, string error) product1 = Product.Create(Guid.NewGuid(), "Test 1", 100);
			(Product product, string error) product2 = Product.Create(Guid.NewGuid(), "Test 2", 100);

			basket.AddBasketItem(new BasketItem() { Product = product1.product });
			basket.AddBasketItem(new BasketItem() { Product = product2.product, Count = 2 });

			decimal totalPrice = basket.TotalPrice();
			Assert.AreEqual(300, totalPrice);
		}

		[TestMethod]
		public void Basket_Sealed_Edit_ErrorReturned()
		{
			Basket basket = new Basket(Guid.NewGuid());
			(Product product, string error) product1 = Product.Create(Guid.NewGuid(), "Test 1", 100);

			basket.AddBasketItem(new BasketItem() { Product = product1.product , Count = 0 });
			(bool isResult, string error) testSetSeal = basket.SetSealTheBasket();

			Assert.AreEqual(false, testSetSeal.isResult);
		}

		[TestMethod]
		public void Basket_Edit_After_Sealed_ErrorReturned()
		{
			Basket basket = new Basket(Guid.NewGuid());
			(Product product, string error) product1 = Product.Create(Guid.NewGuid(), "Test 1", 100);
			(Product product, string error) product2 = Product.Create(Guid.NewGuid(), "Test 2", 100);

			basket.AddBasketItem(new BasketItem() { Product = product1.product });
			(bool isResult, string error) testSetSeal = basket.SetSealTheBasket();
			(bool IsResult, string IsError) testAfterSetSeal = basket.AddBasketItem(new BasketItem() { Product = product2.product });

			Assert.AreEqual(false, testAfterSetSeal.IsResult);
		}

		[TestMethod]
		public void Basket_Product200Product2Count_Increment_After_Sealed_200Returned()
		{
			Basket basket = new Basket(Guid.NewGuid());
			Guid productGuid = Guid.NewGuid();
			(Product product, string error) product1 = Product.Create(productGuid, "Test 1", 100);

			basket.AddBasketItem(new BasketItem() { Product = product1.product,Count = 2});
			basket.SetSealTheBasket();
			basket.IncrementPosition(productGuid);

			Assert.AreEqual(200, basket.TotalPrice());
		}

		[TestMethod]
		public void Basket_Product200Product2Count_Increment__300Returned()
		{
			Basket basket = new Basket(Guid.NewGuid());
			Guid productGuid = Guid.NewGuid();
			(Product product, string error) product1 = Product.Create(productGuid, "Test 1", 100);

			basket.AddBasketItem(new BasketItem() { Product = product1.product, Count = 2 });
			basket.IncrementPosition(productGuid);

			Assert.AreEqual(300, basket.TotalPrice());
		}

		[TestMethod]
		public void Basket_Product200Product2Count_Decrement_100Returned()
		{
			Basket basket = new Basket(Guid.NewGuid());
			Guid productGuid = Guid.NewGuid();
			(Product product, string error) product1 = Product.Create(productGuid, "Test 1", 100);

			basket.AddBasketItem(new BasketItem() { Product = product1.product, Count = 2 });
			basket.DecrementPosition(productGuid);

			Assert.AreEqual(100, basket.TotalPrice());
		}
	}
}
