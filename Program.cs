using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore;
using BorrowIt.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure database connection and register database context
builder.Services.AddDbContext<BorrowItContext>(options => options.UseMySql(builder.Configuration.GetConnectionString("BorrowItConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("BorrowItConnection"))));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// --- Konfigurasi JWT Bearer ---
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
        };
    });

// --- Konfigurasi Cors ---
builder.Services.AddCors(options =>
{
    options.AddPolicy("BorrowItPolicy", policy =>
    {
        // Izinkan URL Frontend React kamu
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.MapOpenApi();
//     app.UseSwaggerUi(options =>
//     {
//         options.DocumentPath = "/openapi/v1.json";
//     });
// }

app.UseHttpsRedirection();

app.UseCors("BorrowItPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();