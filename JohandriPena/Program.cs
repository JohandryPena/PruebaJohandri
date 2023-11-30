using System.Text;
using Application.Interfaces;
using Application.Mapper;
using Application.Services;
using Infrastructure;
using Infrastructure.Repository;
using Infrastructure.Validations;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);


// Register Configuration
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Token 
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration.GetSection("Jwt:Issuer").Value,
            ValidAudience = configuration.GetSection("Jwt:Issuer").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Jwt:Key").Value))
        };
    });


builder.Services.AddHttpClient();
//Add Database Service

builder.Services.AddDbContext<DeportistaDbContext>(opt => opt.UseSqlServer(
    configuration.GetConnectionString("DefaultConnection"),
    b => b.MigrationsAssembly("Cuenta.API")));

builder.Services.AddScoped<IDeportistaRepository, DeportistaRepository>();
builder.Services.AddScoped<IDeportistaService, DeportistaSerivces>();

builder.Services.AddScoped<IPesoRepository, PesoRepository>();
builder.Services.AddScoped<IPesoService, PesoSerivces>();
builder.Services.AddScoped<DeportistaMapper>();
builder.Services.AddScoped<ValidationsDeportista>();
builder.Services.AddScoped<ValidationsPeso>();

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
