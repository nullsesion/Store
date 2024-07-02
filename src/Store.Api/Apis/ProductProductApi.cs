using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.CQRS.Products.Commands;
using Store.Application.CQRS.Products.Queries;
using System.Threading;

namespace Store.Api.Apis
{
	
	public class ProductProductApi : IProductApi
	{
		public void Register(WebApplication app)
		{
			 app.MapGet("/Api/v1/GetAllProducts", GetAllProducts) 
				.Produces<ProductsVm>(StatusCodes.Status200OK)
				.WithName("GetAllProducts")
				.WithTags("Getters")
				.WithOpenApi();

			app.MapPost("/Api/v1/InsertOrUpdate", CreateOrUpdateProduct)
				.Accepts<GetProducts>("application/json")
				.Produces<Guid>(StatusCodes.Status200OK)
				.WithName("InsertOrUpdate")
				.WithTags("Creators")
				.WithOpenApi();
		}

		private async Task<ProductsVm> GetAllProducts(IMediator _mediator, CancellationToken cancellationToken, int Page = 1, int PageSize = 10)
		{
			return await _mediator.Send(new GetProducts() { Page = Page, PageSize = PageSize },cancellationToken);
		}

		private async Task<Guid> CreateOrUpdateProduct(IMediator _mediator, CancellationToken cancellationToken,[FromBody] CreateOrUpdateProduct createOrUpdateProduct) 
		{
			return await _mediator.Send(createOrUpdateProduct,cancellationToken);
		}
	}
}
