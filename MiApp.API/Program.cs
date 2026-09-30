using MiApp.Repository.Interfaces;
using MiApp.Repository.Implementations;
using MiApp.Service.Interfaces;
using MiApp.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Configurar Servicios / Controllers
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS para Frontend
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Registrar Inyección de Dependencias (US01)
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build(); // Se define UNA SOLA VEZ

// Configurar pipeline de peticiones HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MiApp API V1");
        c.RoutePrefix = string.Empty; // <-- Agrega esta línea
    });
}
app.UseHttpsRedirection();
app.UseCors("AllowAngular");
app.UseAuthorization();
app.MapControllers();

app.Run();