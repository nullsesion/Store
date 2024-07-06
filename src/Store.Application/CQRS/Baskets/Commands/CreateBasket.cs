using MediatR;

namespace Store.Application.CQRS.Baskets.Commands
{
	public class CreateBasket: IRequest<BasketCreatorInfo>
	{
		public Guid BasketId { get; set; }
	}
}
