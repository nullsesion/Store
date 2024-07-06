using Microsoft.EntityFrameworkCore;
using Store.Api.Apis;
using Store.Application.Abstraction;
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
	);


builder.Services.AddTransient<IApi, ProductApi>();
builder.Services.AddTransient<IApi, BasketApi>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) 
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

var apis = app.Services.GetServices<IApi>();
foreach (var api in apis)
{
	if (api is null) throw new InvalidProgramException("ProductApi not found");
	api.Register(app);
}

app.Run();