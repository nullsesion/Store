using Store.Domain;
using Store.DomainShared;

namespace Store.Application.Abstraction;

public interface IBasketRepository
{
	public Task<DomainResponseEntity<Basket>> Create(Basket basket);
	Task SaveAsync();
}