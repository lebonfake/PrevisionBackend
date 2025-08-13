using Microsoft.EntityFrameworkCore;
using PrevisionBackend.Data;
using PrevisionBackend.Repositories;
using PrevisionBackend.Repositories;
using PrevisionBackend.Service;
using PrevisionBackend.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:3000") 
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials()); // (cookies, HTTP authentication)

    
});

// Register all Repositories (concrete classes)
builder.Services.AddScoped<UserRepository>(); // Existing
builder.Services.AddScoped<ValidateurRepository>(); // Existing
builder.Services.AddScoped<FluxRepository>(); // For Flux creation
builder.Services.AddScoped<PermissionPrevRepository>(); // For Flux creation

// Register all Services (concrete classes)
builder.Services.AddScoped<UserService>(); // Existing
builder.Services.AddScoped<ValidateurService>(); // Existing
builder.Services.AddScoped<FluxService>(); // For Flux creation
builder.Services.AddScoped<PermissionPrevService>();



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
    app.UseCors("AllowSpecificOrigin");
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
