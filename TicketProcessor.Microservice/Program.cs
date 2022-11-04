using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace TicketProcessor.Microservice
{
    public class Program
    {
        public static void Main(string[] args) {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, services, configuration) => 
                    configuration.ReadFrom.Configuration(context.Configuration)
                                 .ReadFrom.Services(services)
                                 .Enrich.FromLogContext()
                                 .WriteTo.Console()
                                 .WriteTo.File("logs/TicketProcessor-.txt", rollingInterval: RollingInterval.Day)
                                 .WriteTo.Seq("http://localhost:5341/"))
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
