using Microsoft.EntityFrameworkCore;
using MunicipalLibrary.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Database Context Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=MunicipalLibrary.db";
builder.Services.AddDbContext<MunicipalLibraryDbContext>(options =>
    options.UseSqlite(connectionString));

// Add services to the container.
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

app.Run();
