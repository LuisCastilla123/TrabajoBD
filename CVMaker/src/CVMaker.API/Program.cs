using System.Text.Json.Serialization;
using CVMaker.Application;
using CVMaker.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Registrar servicios de la aplicación y la infraestructura.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Configurar controladores y opciones de JSON.
builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

// Configurar Swagger y definir el documento "v1".
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "CVMaker API V1",
        Version = "v1"
    });
});

var app = builder.Build();

// Habilitar Swagger únicamente en el entorno de Desarrollo.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CVMaker API V1");
        // Con RoutePrefix vacío, Swagger UI se muestra en la raíz.
        c.RoutePrefix = string.Empty;
    });
}

app.UseAuthorization();
app.MapControllers();
app.Run();