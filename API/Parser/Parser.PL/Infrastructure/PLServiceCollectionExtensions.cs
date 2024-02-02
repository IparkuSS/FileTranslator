using Microsoft.Extensions.DependencyInjection;
using Parser.PL.Services.Contracts;
using System;
using System.IO;
using Parser.PL.Services;

namespace Parser.PL.Infrastructure
{
    public static class PLServiceCollectionExtensions
    {
        public static IServiceCollection AddParsingServices(this IServiceCollection services)
        {
            _ = services.AddScoped<Func<string, IParser>>(sp =>
            {
                Func<string, IParser> factoryMethod = new Func<string, IParser>((fileExtension) =>
                {

                    switch (Path.GetExtension(fileExtension).ToLower())// проверяем какое расширение используется
                    {
                        case ".doc":
                        case ".dot":
                        case ".dotx":
                        case ".docm":
                        case ".dotm":
                        case ".rtf":
                        case ".docx":
                            return new ParserWord();
                        case ".pdf":
                            return new ParserPdf();
                        case ".txt":
                            return new ParserTxt();
                        default:
                            throw new NotImplementedException($"Неверный формат файла - {Path.GetExtension(fileExtension)}");
                    }
                });

                return factoryMethod;
            });

            return services;
        }
    }
}
