using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using QuerUmLivro.Infra.CrossCuttin.Mapper;
using QuerUmLivro.Infra.CrossCutting.IoC;
using QuerUmLivro.Infra.Data.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

NativeInjectorBootStrapper.RegisterServices(builder.Services);

NativeMapperBootStrapper.RegisterServices(builder.Services);


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    //CONFIGURANDO ARQUIVO DE DOCUMENTAÇAO DO SUMMARY
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "QuerUmLivro.API", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

#region Configuração da Conexao com Banco

//var conexao = builder.Configuration.GetConnectionString("DefaultConnection");

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
