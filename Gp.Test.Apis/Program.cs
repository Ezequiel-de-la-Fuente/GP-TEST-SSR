
using Gp.Test.Interface.Mapper;
using Gp.Test.Interface.Repositories;
using Gp.Test.Mapper;
using Gp.Test.Repository;
using Gp.Test.Repository.Config;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TestContext>(test => test.UseInMemoryDatabase(databaseName: "Test"));
builder.Services.AddTransient(typeof(IPersonasRepository), typeof(PersonasRepository));
builder.Services.AddTransient(typeof(IPersonasMapper), typeof(PersonaMapper));
var app = builder.Build();
var dataTest = System.IO.File.ReadAllText(@"Test.json");
ConfigDomain.ConfigurationDomain(app.Services, dataTest);
IWebHostEnvironment environment = app.Environment;
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