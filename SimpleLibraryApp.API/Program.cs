using System.Data;
using Microsoft.AspNetCore.Mvc;
using SimpleLibraryApp.API;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Package Configurations
builder.Services.ConfigureDapper(builder.Configuration);
builder.Services.ConfigureMediatR();
builder.Services.ConfigureFluentValidation();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureTransaction();


// DI Configurations
builder.Services.ConfigureDependencies();

// Validation Response Configuration
builder.Services.Configure<ApiBehaviorOptions>(option => {
    option.SuppressModelStateInvalidFilter = true;
});

var app = builder.Build();

// For Seed
// using (var scope = app.Services.CreateScope())
// {
//     var dbConnection = scope.ServiceProvider.GetRequiredService<IDbConnection>();
//     dbConnection.Open();
//     await Seed.Create(dbConnection);
// }

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
