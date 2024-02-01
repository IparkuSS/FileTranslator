using AutoMapper;
using Parser.PL.Infrastructure.MapperProfiles;

namespace Parser.PL.Infrastructure
{
    public static class MapperConfig
    {
        /// <summary>
        /// Добавляет профили в конфигурацию маппера.
        /// </summary>
        /// <returns>Конфигурация маппера.</returns>
        public static MapperConfiguration Configure()
        {
            MapperConfiguration configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<FileProfile>();

            });
            configuration.CompileMappings();

            return configuration;
        }
    }
}
