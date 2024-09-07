using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SongSuggester.Application.Services.Logs;
using SongSuggester.Application.Services.Songs;

namespace SongSuggester.App
{
    public class DependencyInjection
    {
        public static IHost Register(string[] args)
        {

            var host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
            {
                services.AddScoped<ILoggerService, LoggerService>();
                services.AddScoped<ISongService, SongService>();
            })
            .Build();


            return host;
        }
    }
}
