using MediatR;
using Questao5.Application.Handlers;
using Questao5.Application.Handlers.Interfaces;
using Questao5.Infrastructure.Repositories;
using Questao5.Infrastructure.Repositories.Interfaces;
using Questao5.Infrastructure.Sqlite;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// sqlite
builder.Services.AddSingleton(new DatabaseConfig { Name = builder.Configuration.GetValue<string>("DatabaseName", "Data Source=database.sqlite") });
builder.Services.AddSingleton<IDatabaseBootstrap, DatabaseBootstrap>();
//Inje��o reposit�rios
builder.Services.AddSingleton<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IContaCorrenteRepository, ContaCorrenteRepository>();
builder.Services.AddSingleton<IIdempotenciaRepository, IdempotenciaRepository>();
builder.Services.AddSingleton<IMovimentoRepository, MovimentoRepository>();

//Inje��o Handles
builder.Services.AddSingleton<ICreateMovimentoHandler, CreateMovimentoHandler>();
builder.Services.AddSingleton<IFindContaCorrenteByNumeroHandler, FindContaCorrenteByNumeroHandler>();
builder.Services.AddSingleton<IFindContaCorrenteByNumeroHandler, FindContaCorrenteByNumeroHandler>();
builder.Services.AddSingleton<IFindIdempotenciaByIdHandler, FindIdempotenciaByIdHandler>();
builder.Services.AddSingleton<ICreateIdempontenciaHandler, CreateIdempontenciaHandler>();

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

// sqlite
#pragma warning disable CS8602 // Dereference of a possibly null reference.
app.Services.GetService<IDatabaseBootstrap>().Setup();
#pragma warning restore CS8602 // Dereference of a possibly null reference.

app.Run();

// Informa��es �teis:
// Tipos do Sqlite - https://www.sqlite.org/datatype3.html


