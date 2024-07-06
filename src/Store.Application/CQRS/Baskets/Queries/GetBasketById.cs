using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Store.Application.CQRS.Baskets.Queries
{
	public class GetBasketById : IRequest<BasketVm>
	{
		public Guid BasketId { get; set; }
	}
}
