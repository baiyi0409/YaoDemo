
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using YaoDemoApi.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json");
// Add services to the container.
builder.Services.AddControllers();
//配置数据库连接
builder.Services.AddDbContext<YaoDemoContext>(option =>
{
    var connectionString = builder.Configuration.GetConnectionString("YaoDemoConnection");
    option.UseSqlite(connectionString);
});
//配置swagger
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version= "v0.1.0",
        Title = "YaoDemoApi",
        Description = "Demo说明文档",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact 
        {
            Name = "YaoDemo",
            Email = "2740574036@qq.com",
        }
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.UseAuthorization();

app.MapControllers();

app.Run();
