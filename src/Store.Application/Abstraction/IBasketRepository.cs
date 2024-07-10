using Store.Domain;
using Store.DomainShared;

namespace Store.Application.Abstraction;

public interface IBasketRepository
{
	public Task<DomainResponseEntity<Basket>> Create(Basket basket, CancellationToken cancellationToken);
	public Task<DomainResponseEntity<Basket>> GetByID(Guid id, CancellationToken cancellationToken);
	Task SaveAsync();
}