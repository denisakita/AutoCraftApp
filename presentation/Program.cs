using System.Reflection;
using application.Interfaces;
using infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using presentation.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

// add all providers <Generic>
var providers = Assembly.GetExecutingAssembly().GetTypes()
    .Where(type => type.GetInterfaces()
        .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IProvider<,>)));

foreach (var provider in providers)
{
    builder.Services.AddScoped(provider.GetInterfaces()
        .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IProvider<,>)), provider);
}

// add logging
builder.Logging.ClearProviders().AddConsole();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
builder.Services.AddDbContext<BContext>(opt => opt.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]));
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    if (scope.ServiceProvider.GetService<BContext>()!.Database.GetPendingMigrations().Any())
    {
        scope.ServiceProvider.GetService<BContext>()?.Database.Migrate();
    }
}

app.UseGenericErrorHandling();
app.UseCors("AllowAll");

app.MapControllers();
app.Run();