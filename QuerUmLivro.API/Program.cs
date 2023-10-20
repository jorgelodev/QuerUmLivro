using Microsoft.EntityFrameworkCore;
using QuerUmLivro.Infra.CrossCutting.IoC;
using QuerUmLivro.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

NativeInjectorBootStrapper.RegisterServices(builder.Services);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Configuração da Conexao com Banco
var conexao = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#endregion

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
