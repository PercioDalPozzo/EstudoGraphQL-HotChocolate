using Domain.Command;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Query;
using Domain.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPessoaRepository, PessoaRepository>();
builder.Services.AddScoped<IQueryHandler<Domain.Query.GetPessoaQuery, GetPessoaQueryResponse>, GetPessoaQueryHandler>();
builder.Services.AddScoped<ICommandHandler<CreatePessoaCommand, CreatePessoaCommandResponse>, CreatePessoaCommandHandler>();
builder.Services.AddScoped<IProvisionamentoService, ProvisionamentoService>();


builder.Services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("InMemoryDb"), ServiceLifetime.Singleton);


builder.Services
    .AddScoped<GetPessoaGraphQLQueryA>() 
    .AddScoped<GetPessoaGraphQLQueryB>() 
    .AddScoped<CreatePessoaGraphQLMutation>()
    .AddGraphQLServer()
    .AddQueryType()
    .AddTypeExtension<GetPessoaGraphQLQueryA>()
    .AddTypeExtension<GetPessoaGraphQLQueryB>()
    .AddMutationType()
    .AddTypeExtension<CreatePessoaGraphQLMutation>()
    .AddType<DateTimeType>();
    ;

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider.GetRequiredService<IProvisionamentoService>();
    service.Provisionar();
}

app.MapGraphQL("/graphql");

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