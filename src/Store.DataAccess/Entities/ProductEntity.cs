using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataAccess.Entities
{
	public class ProductEntity
	{
		public Guid ProductId { get; set; }

		public string Title { get; set; } = null!;

		public decimal Price { get; set; }

		public virtual ICollection<BasketProductEntity> BasketProducts { get; set; } = new List<BasketProductEntity>();
	}
}
