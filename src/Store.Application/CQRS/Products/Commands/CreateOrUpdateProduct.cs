using MediatR;

namespace Store.Application.CQRS.Products.Commands;

public class CreateOrUpdateProduct: IRequest<Guid>
{
	public Guid ProductId { get; set; }
	public string Title { get; set; }
	public decimal Price { get; set; }
}