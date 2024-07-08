using System.Text;
using Store.DomainShared;

namespace Store.Domain.Tests
{
	[TestClass]
	public class ProductUnitTest1
	{
		[TestMethod]
		public void Try_Create_Product_Price0_ProductReturned()
		{
			//arrange
			decimal price = 0;

			//act
			DomainResponseEntity<Product> product = Product.Create(Guid.NewGuid(), "Test 1", price);

			//assert
			Assert.AreEqual(true, product.IsSuccess);
		}

		[TestMethod]
		public void Try_Create_Product_PriceNegative_ErrorReturned()
		{
			//arrange
			decimal price = -1;
			string errorMessage = Product.ERROR_PRICE_STRING;

			//act
			var product = Product.Create(Guid.NewGuid(), "Test 1", price);

			//assert
			Assert.AreEqual(false, product.IsSuccess);
			Assert.AreEqual(Product.ERROR_PRICE_STRING, product.ErrorDetail);
		}

		[TestMethod]
		public void Try_Create_Product_TitleGreaterMaxLen_ErrorReturned()
		{
			//arrange
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < Product.MAX_LEN_TITLE + 1; i++)
			{
				sb.Append("A");
			}
			string title = sb.ToString();

			//act
			DomainResponseEntity<Product> product = Product.Create(Guid.NewGuid(), title, Product.MIN_PRICE + 1);

			//assert
			Assert.AreEqual(false, product.IsSuccess);
			Assert.AreEqual(Product.ERROR_TITLE_STRING,product.ErrorDetail);
		}
	}
}