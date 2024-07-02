using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.CQRS.Products.Queries
{
	public class ProductVm
	{
		public Guid ProductId { get; set; }
		public string Title { get; set; }
		public decimal Price { get; set; }
	}
}
