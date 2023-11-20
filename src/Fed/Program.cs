using Fed;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FedDbContext>
(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("FedConnectionString")
    )
);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
