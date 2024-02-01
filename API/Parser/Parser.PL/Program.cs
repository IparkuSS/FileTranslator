using Parser.BLL.Infrastructure;
using Parser.DAL.Interfaces.Uow;
using Parser.DAL.Repositories.Uow;
using Parser.PL.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();
string connectionString = configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<IUnitOfWork>(_ => new UnitOfWork(connectionString));
builder.Services.AddSingleton(s => MapperConfig.Configure().CreateMapper());
builder.Services.AddBllServiceCollection();


builder.Services.AddControllers();
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

app.Run();
