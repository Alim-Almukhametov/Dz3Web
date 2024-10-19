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


/// ��� �������� ����������� �������� � ������� ��������, �����������, ������� � ��., ���
/// ������������ � ����������.

// �������� �� ����� ������������ ��� � ������ �������. ��� ����� �������� ��� ����������
// connection string �� ����� ������������
builder.Services.AddDbContext<Context>
    (options => options.UseMySql(builder.Configuration.GetConnectionString("db"), 
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("db"))));
// ��������� � ��� ���������� 
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductGroupRepository, ProductGroupRepository>();
builder.Services.AddScoped<IStorageRepository, StorageReposytory>();
// ������
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

builder.Services.AddMemoryCache();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapGraphQL();

app.Run();
