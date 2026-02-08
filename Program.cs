using Microsoft.EntityFrameworkCore;
using BorrowIt.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure database connection and register database context
builder.Services.AddDbContext<BorrowItContext> (options => options.UseMySql(builder.Configuration.GetConnectionString("BorrowItConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("BorrowItConnection"))));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();