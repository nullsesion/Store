using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Application.CQRS.Baskets.Commands;
using Store.Application.CQRS.Baskets.Queries;
using Store.Domain;
using Store.DomainShared;

namespace Store.Api.Apis
{
	public class BasketApi: IApi
	{
		public void Register(WebApplication app)
		{
			app.MapPost("/BasketApi/v1/Create", Create)
				.Produces<Guid>(StatusCodes.Status200OK)
				.WithName("CreateBasket")
				.WithTags("Creators")
			.WithOpenApi();

			app.MapGet("/BasketApi/v1/GetAllBasket", GetAllBasket)
				.Produces<BasketsVm>(StatusCodes.Status200OK)
				.WithName("GetAllBaskets")
				.WithTags("Getters")
				.WithOpenApi();

			app.MapGet("/BasketApi/v1/GetBasketByGuid", GetBasketByGuid)
				.Produces<BasketVm>(StatusCodes.Status200OK)
				.WithName("GetBasketByGuid")
				.WithTags("Getters")
				.WithOpenApi();
		}

		private async Task<IResult> GetAllBasket(IMediator mediator, CancellationToken cancellationToken, int page = 1, int pageSize = 10 )
		{
			var result = await mediator.Send(new GetBasketsList(){Page = page,PageSize = pageSize });
			return Results.Json(result);
		}

		private async Task<IResult> GetBasketByGuid(IMediator mediator, CancellationToken cancellationToken, Guid basketId)
		{
			GetBasketById getBasketById = new GetBasketById()
			{
				BasketId = basketId
			};
			var result = await mediator.Send(getBasketById,cancellationToken);
			return Results.Json(result);
		}

		private async Task<IResult> Create(IMediator mediator, CancellationToken cancellationToken, [FromBody] CreateBasket createBasket)
		{
			DomainResponseEntity<Basket> result = await mediator.Send(createBasket, cancellationToken);
			if (result.IsSuccess)
			{
				return Results.Json(result.Entity);
			}
			return Results.BadRequest(result.ErrorDetail);
			
		}
	}
}
