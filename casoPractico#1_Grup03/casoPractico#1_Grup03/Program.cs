using casoPractico_1_Grup03.DBContext;
//librerias o nugestusing Microsoft.EntityFr
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using MySQL.EntityFrameworkCore.Extensions;
//using Api31;




var builder = WebApplication.CreateBuilder(args);


var _connectionStrings = builder.Configuration.GetConnectionString("MySqlConnection");
builder.Services.AddDbContext<AplicationDbContext>(
           options => options.UseMySql(_connectionStrings, ServerVersion.AutoDetect(_connectionStrings))
    );




//registro de memoria o servicio web 



// Add services to the container.
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
