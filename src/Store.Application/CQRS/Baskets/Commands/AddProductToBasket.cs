using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Baskets.Commands
{
	public class AddProductToBasket: IRequest<DomainResponseEntity<Basket>>
	{
		public Guid BasketId { get; set; }
		public Guid ProductId { get; set; }
	}
}
