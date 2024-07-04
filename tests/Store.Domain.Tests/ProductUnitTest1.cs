using System.Diagnostics;
using System.Text;

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
			(Product product, string error) product = Product.Create(Guid.NewGuid(), "Test 1", price);

			//assert
			Assert.AreEqual(string.Empty,product.error);
		}

		[TestMethod]
		public void Try_Create_Product_PriceNegative_ErrorReturned()
		{
			//arrange
			decimal price = -1;
			string errorMessage = Product.ERROR_PRICE_STRING;

			//act
			(Product product, string error) product = Product.Create(Guid.NewGuid(), "Test 1", price);

			//assert
			Assert.AreEqual(Product.ERROR_PRICE_STRING, product.error);
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
			(Product product, string error) product = Product.Create(Guid.NewGuid(), title, Product.MIN_PRICE + 1);

			//assert
			Assert.AreEqual(Product.ERROR_TITLE_STRING,product.error);
		}
	}
}