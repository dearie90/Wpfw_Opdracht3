using Microsoft.EntityFrameworkCore;
using EfCoreWebApi.Data;
using EfCoreWebApi.Services;
using EfCoreWebApi.DAOs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); 

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

//maakt db context
builder.Services.AddDbContext<EfCoreWebApi.Data.AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency injection voor de Service Laag
builder.Services.AddScoped<IBlogpostService, BlogpostService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
// Dependency injection voor de DAO Laag
builder.Services.AddScoped<IBlogpostDao, BlogpostDao>();
builder.Services.AddScoped<IProjectDao, ProjectDao>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers(); 

app.Run();