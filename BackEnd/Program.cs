using Microsoft.EntityFrameworkCore;
using SistemaABC.Models;
using SistemaABC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITiposProductos, ImplTiposProductos>();
builder.Services.AddScoped<IProducto, ImplProducto>();
// Configure Entity Framework Core
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


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();

