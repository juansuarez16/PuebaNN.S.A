using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;
using PruebaNN.S.A.Infrastructure;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using PruebaNN.S.A.Infrastructure.SeedWorks;
using PruebaNN.S.A.Application.Service.Interfaces;
using PruebaNN.S.A.Application.Service;
using Microsoft.OpenApi.Models;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Configurar el servicio de autenticación con Azure AD
//builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
//    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

builder.Services.AddControllersWithViews();
//builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Nombre de tu API", Version = "v1" });
});
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IEmpleadoService, EmpleadosService>()
                .AddScoped<ICargoService, CargoService>()
                .AddScoped<IEstadoService, EstadoService>()
                .AddScoped<IServicioService, ServicioService>()
                .AddScoped<ISolicitudServicioService, SolicitudServicioService>()
                .AddScoped<IUsuarioService, UsuarioService>()
                .AddScoped<IRolService, RolService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configurar el pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Service NN");
    // Opcional: Configurar la ruta de Swagger UI
    // c.RoutePrefix = string.Empty;
});
app.UseStaticFiles();
app.UseCors("AllowAllOrigins");
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
