using Basket.API.Data;
using BuildingBlocks.Behaviors;
using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

//add services to the container
builder.Services.AddCarter();
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddMarten(opts =>
{
    opts.Connection(builder.Configuration.GetConnectionString("Database")!);
    opts.Schema.For<ShoppingCart>().Identity(x => x.UserName);
}).UseLightweightSessions();

builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddStackExchangeRedisCache((options) =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");


});

builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapCarter();
app.UseExceptionHandler(op =>
{

});

app.UseHealthChecks("/health");
app.Run();
