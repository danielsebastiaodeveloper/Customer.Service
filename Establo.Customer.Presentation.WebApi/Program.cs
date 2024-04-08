using IoC;
using Presentation.WebApi.ActionsFilters;
using Presentation.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var texto = Environment.GetEnvironmentVariable("EstabloCustomerDBConnectionString");
Console.WriteLine($"Valor:{texto}");

// Add services to the container.
builder.Services.AddEstabloDependencies(configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ValidationCustomerExistsAttribute>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseErrorHandlerMidleware();

app.MapControllers();

app.Run();
