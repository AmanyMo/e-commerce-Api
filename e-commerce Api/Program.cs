global using e_commerce_Api.Data;

global using Microsoft.EntityFrameworkCore;
global using e_commerce_Api.Models;
global using e_commerce_Api.Repositories;
global using e_commerce_Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//add service to connetion String
builder.Services.AddDbContext<ModelContext>((options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("eCommerce"));
});
//how to create obj from Iproduct service
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<ICategories, CategoriesRepository>(); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
