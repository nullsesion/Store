using MediatR;
using Store.Domain;
using Store.DomainShared;

namespace Store.Application.CQRS.Products.Commands;

public class CreateOrUpdateProduct: IRequest<DomainResponseEntity<Product>>
{
	public Guid ProductId { get; set; }
	public string Title { get; set; }
	public decimal Price { get; set; }
}