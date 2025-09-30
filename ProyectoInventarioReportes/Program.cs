using Microsoft.EntityFrameworkCore;
using ProyectoInventarioReportes.Data;
using ProyectoInventarioReportes.Data.Repository;
using ProyectoInventarioReportes.Data.Repository.IRepository;
using ProyectoInventarioReportes.Services;
using ProyectoInventarioReportes.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Servicios
builder.Services.AddScoped<IMovimientoInventarioRepository, MovimientoInventarioRepository>();
builder.Services.AddScoped<IExistenciasService, ExistenciasService>();
builder.Services.AddScoped<IReporteRepository, ReporteRepository>();

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("ConexionSQL") ?? throw new InvalidOperationException("Conexión no encontrada");
builder.Services.AddDbContext<ApplicationDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
    });
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
