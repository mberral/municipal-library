using Microsoft.EntityFrameworkCore;
using MunicipalLibrary.Api.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Database Context Configuration
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Data Source=MunicipalLibrary.db";
builder.Services.AddDbContext<MunicipalLibraryDbContext>(options =>
    options.UseSqlite(connectionString));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFilename);

    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
