using Fed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FedDbContext>
(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("FedConnectionString")
    )
);

builder.Services.AddScoped<IFoodService, FoodService>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost(
    "/feds/",
    async (FoodRequest foodRequest, IFoodService foodService) => await foodService.CreatedFood(foodRequest));

app.Run();
