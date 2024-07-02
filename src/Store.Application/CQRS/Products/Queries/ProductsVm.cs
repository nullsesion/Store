using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.CQRS.Products.Queries
{
	public class ProductsVm
	{
		public List<ProductVm> Products { get; set; }
	}
}
