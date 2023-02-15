using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace learning
{
    public class Program
    { 
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args) 
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}        