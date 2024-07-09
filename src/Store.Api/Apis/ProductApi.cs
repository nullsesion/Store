using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.CQRS.Products.Commands;
using Store.Application.CQRS.Products.Queries;
using Store.Domain;
using Store.DomainShared;

namespace Store.Api.Apis
{
	
	public class ProductApi : IApi
	{
		public void Register(WebApplication app)
		{
			 app.MapGet("/ProductApi/v1/GetAllProducts", GetAllProducts) 
				.WithName("GetAllProducts")
				.WithTags("Getters")
				.WithOpenApi();

			app.MapPost("/ProductApi/v1/InsertOrUpdate", CreateOrUpdateProduct)
				.Produces<Guid>(StatusCodes.Status200OK)
				.WithName("InsertOrUpdate")
				.WithTags("Creators")
				.WithOpenApi();
		}

		private async Task<IResult> GetAllProducts(IMediator mediator, CancellationToken cancellationToken, int page = 1, int pageSize = 10)
		{
			DomainResponseEntity<List<Product>> result = await mediator.Send(new GetProducts() { Page = page, PageSize = pageSize }, cancellationToken);

			if(result.IsSuccess)
				return Results.Json(result);

			return Results.BadRequest(result);
		}

		private async Task<IResult> CreateOrUpdateProduct(IMediator mediator, CancellationToken cancellationToken,[FromBody] CreateOrUpdateProduct createOrUpdateProduct) 
		{
			var result = await mediator.Send(createOrUpdateProduct,cancellationToken);
			//todo: add 200 or 204
			if (result.IsSuccess)
				return Results.Json(result);

			return Results.BadRequest(result);
		}
	}
}
