using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.CQRS.Products.Commands
{
	public class ProductCreatorInfo
	{
		public Guid ProductId { get; set; }
		public string IsError { get; set; } = string.Empty;
	}
}
