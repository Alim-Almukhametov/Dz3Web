using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using WebMarketGB.Abstractions;
using WebMarketGB.Automapper;
using WebMarketGB.Data;
using WebMarketGB.Graph.Mutation;
using WebMarketGB.Graph.Query;
using WebMarketGB.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

  //builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var context = builder.Configuration.GetConnectionString("db");


/// ПРИ СОЗДАНИИ НОЕОБХОДИМО ДОБАВЛТЬ В СЕРВИСЫ КОНТЕКСТ, РЕПОЗИТОРИИ, МАППЕРЫ И ПР., ЧТО
/// ИСПОЛЬЗУЕТСЯ В ПРИЛОЖЕНИИ.

// Контекст ДБ также подключается как и другие сервисы. сам класс контекст уже использует
// connection string из файла конфигурации
builder.Services.AddDbContext<Context>
    (options => options.UseMySql(builder.Configuration.GetConnectionString("db"), 
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("db"))));
// интерфейс и его реализация 
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IStorageRepository, StorageReposytory>();
// маппер
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

builder.Services.AddMemoryCache();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
