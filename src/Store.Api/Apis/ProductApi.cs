﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.CQRS.Products.Commands;
using Store.Application.CQRS.Products.Queries;

namespace Store.Api.Apis
{
	
	public class ProductApi : IApi
	{
		public void Register(WebApplication app)
		{
			 app.MapGet("/ProductApi/v1/GetAllProducts", GetAllProducts) 
				.Produces<ProductsVm>(StatusCodes.Status200OK)
				.WithName("GetAllProducts")
				.WithTags("Getters")
				.WithOpenApi();

			app.MapPost("/ProductApi/v1/InsertOrUpdate", CreateOrUpdateProduct)
				.Produces<Guid>(StatusCodes.Status200OK)
				.WithName("InsertOrUpdate")
				.WithTags("Creators")
				.WithOpenApi();
		}

		private async Task<IResult> GetAllProducts(IMediator mediator, CancellationToken cancellationToken, int Page = 1, int PageSize = 10)
		{
			var result = await mediator.Send(new GetProducts() { Page = Page, PageSize = PageSize }, cancellationToken);
			return Results.Json(result);
		}

		private async Task<IResult> CreateOrUpdateProduct(IMediator mediator, CancellationToken cancellationToken,[FromBody] CreateOrUpdateProduct createOrUpdateProduct) 
		{
			var result = await mediator.Send(createOrUpdateProduct,cancellationToken);
			if (result.IsSuccess)
				return Results.Json(result.Entity);

			return Results.BadRequest(result.ErrorDetail);
		}
	}
}
