using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Application.Abstraction;
using Store.Application.CQRS.Products.Commands;
using Store.Application.CQRS.Products.Queries;
using Store.DataAccess;
using Store.DataAccess.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<IStoreDbContext,StoreDbContext>(
	options => options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(StoreDbContext)))
	); 
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddMediatR(cfg 
	=> cfg.RegisterServicesFromAssembly(typeof(IProductsRepository).Assembly)
	);//ProductsVm

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.MapGet("/Api/v1/GetAllProducts", async (int Page,int PageSize, IMediator _mediator) 
		=> await _mediator.Send(new GetProducts() { Page = Page, PageSize = PageSize })) //
.WithName("GetAllProducts")
.WithOpenApi();

app.MapPost("/Api/v1/InsertOrUpdate", async ([FromBody] CreateOrUpdateProduct createOrUpdateProduct, IMediator _mediator) =>
{
	return await _mediator.Send(createOrUpdateProduct);
})
	.WithName("InsertOrUpdate")
	.WithOpenApi(); ;


app.Run();