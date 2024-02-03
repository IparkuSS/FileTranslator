using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Parser.BLL.Infrastructure;
using Parser.PL.Infrastructure;
using Parser.PL.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json")
    .Build();
string connectionString = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDalServiceCollection(connectionString);
builder.Services.AddBllServiceCollection();
builder.Services.AddParsingServices();
IConfigurationSection applicationSettingsConfiguration = configuration.GetSection(nameof(TranslatorSettings));
_ = builder.Services.Configure<TranslatorSettings>(applicationSettingsConfiguration);

_ = builder.Services.AddSingleton(configuration);


builder.Services.AddSingleton(s => MapperConfig.Configure().CreateMapper());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
