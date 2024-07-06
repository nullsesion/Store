﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.CQRS.Baskets.Commands;
using Store.Application.CQRS.Baskets.Queries;
using Store.Application.CQRS.Products.Commands;
namespace Store.Api.Apis
{
	public class BasketApi: IApi
	{
		public void Register(WebApplication app)
		{
			app.MapPost("/BasketApi/v1/Create", Create)
				.Accepts<BasketCreatorInfo>("application/json")
				.Produces<Guid>(StatusCodes.Status200OK)
				.WithName("CreateBasket")
				.WithTags("Creators")
			.WithOpenApi();

			app.MapGet("/BasketApi/v1/GetAllBasket", GetAllBasket)
				//.Accepts<Guid>("application/json")
				.Produces<BasketsVm>(StatusCodes.Status200OK)
				.WithName("GetAllBaskets")
				.WithTags("Getters")
				.WithOpenApi();

			app.MapGet("/BasketApi/v1/GetBasketByGuid", GetBasketByGuid)
				.Accepts<Guid>("application/json")
				.Produces<BasketVm>(StatusCodes.Status200OK)
				.WithName("GetBasketByGuid")
				.WithTags("Getters")
				.WithOpenApi();
		}

		private async Task<IResult> GetAllBasket(IMediator mediator, CancellationToken cancellationToken)
		{
			BasketsVm result = await mediator.Send(new GetBasketsList());
			return Results.Json(result);
		}

		private async Task<IResult> GetBasketByGuid(IMediator mediator, CancellationToken cancellationToken, Guid basketId)
		{
			GetBasketById getBasketById = new GetBasketById()
			{
				BasketId = basketId
			};
			BasketVm result = await mediator.Send(getBasketById,cancellationToken);
			return Results.Json(result);
		}

		private async Task<IResult> Create(IMediator mediator, CancellationToken cancellationToken, [FromBody] CreateBasket createBasket)
		{
			BasketCreatorInfo result = await mediator.Send(createBasket, cancellationToken);
			if (!string.IsNullOrEmpty(result.IsError))
			{
				return Results.BadRequest(result.IsError);
			}
			return Results.Json(result.BasketId);
		}
	}
}
