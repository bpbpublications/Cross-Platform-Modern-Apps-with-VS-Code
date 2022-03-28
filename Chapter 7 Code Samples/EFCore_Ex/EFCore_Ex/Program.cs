using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using EFCore_Ex.Data;
using Microsoft.Extensions.DependencyInjection;

namespace EFCore_Ex
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostapp = CreateHostBuilder(args).Build();

            CreateMusicDatabase(hostapp);

            hostapp.Run();
        }

        private static void CreateMusicDatabase(IHost hostapp)
        {
            using (var servicescope = hostapp.Services.CreateScope())
            {
                var services = servicescope.ServiceProvider;
                try
                {
                    var dbcontext = services.GetRequiredService<MusicContext>();
                    dbcontext.Database.EnsureCreated();

                }
                catch (Exception ex)
                {
                    var exlogger = services.GetRequiredService<ILogger<Program>>();
                    exlogger.LogError(ex, "Error creating Music Database");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
