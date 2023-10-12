using Microsoft.EntityFrameworkCore;
using SistemaABC.Models;
using SistemaABC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITiposProductos, ImplTiposProductos>();
builder.Services.AddScoped<IProducto, ImplProducto>();
builder.Services.AddDbContext<DbpruebaTecnicaAngelContext>(options =>
{
  options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"),
      sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
});
builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAngularOrigins",
  builder =>
  {
    builder.WithOrigins(
                          "http://localhost:4200"
                          )
                          .AllowAnyHeader()
                          .AllowAnyMethod();
  });
});


var app = builder.Build();
app.UseCors("AllowAngularOrigins");


if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

