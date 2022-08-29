using GeekShopping.ProductApi.Model.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

//var connectionString = Configuration["MySQLConnection"];

builder.Services.AddDbContext<MySqlContext>(options => options.UseMySql(builder.Configuration["MySQLConnection:MySqlConnectionString"], new MySqlServerVersion(new Version(8,0,30))));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
