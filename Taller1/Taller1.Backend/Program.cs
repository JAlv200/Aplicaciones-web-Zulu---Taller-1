using Microsoft.EntityFrameworkCore;
using Taller1.Backend.Data;
using Taller1.Backend.Repositories.Implementations;
using Taller1.Backend.Repositories.Interfaces;
using Taller1.Backend.UnitsOfWork.Implementations;
using Taller1.Backend.UnitsOfWork.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer("Name=LocalConnection"));
builder.Services.AddTransient<SeedDb>();

builder.Services.AddScoped(typeof(IGenericUnitOfWork<>), typeof(GenericUnitOfWork<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IEmployeesUnitOfWork, EmployeesUnitOfWork>();
builder.Services.AddScoped<IEmployeesRepository, EmployeesRepository>();

// Inyecciones antes del Build()
var app = builder.Build();

seedData(app);

void seedData(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using var scope = scopedFactory!.CreateScope();
    var service = scope.ServiceProvider.GetService<SeedDb>();
    service!.SeedAsync().Wait(); // Wait para llamar asincrono dentro de metodo sincrono
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();