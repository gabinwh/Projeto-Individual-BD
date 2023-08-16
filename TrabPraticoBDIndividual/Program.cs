global using TrabPraticoBDIndividual.Data;
global using Microsoft.EntityFrameworkCore;
using TrabPraticoBDIndividual.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Database Configuration
builder.Services.AddDbContextPool<DataContext>(options =>
{
    string? connectionString = "server = localhost; port = 3306; database = projeto_db; user = root";
    options.UseMySql(connectionString,
           ServerVersion.AutoDetect(connectionString));
});
#endregion

builder.Services.AddAutoMapper(typeof(UsuarioProfile));

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
