using Store.Domain;

namespace Store.Application.Abstraction;

public interface IBasketRepository
{
	public Task<Basket?> Create(Basket basket);
	Task SaveAsync();
}