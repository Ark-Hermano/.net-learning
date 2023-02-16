using System.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using pedidos_api.Models;
using Refit;

namespace PedidosApi
{

  public class Startup
  {

    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddCors(options =>
      {
        options.AddDefaultPolicy(builder =>
        {
          builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
      });


      var connectionString = Configuration.GetConnectionString("DefaultConnection");
      services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));
      services.AddTransient<IProdutoRepository, ProdutoRepository>();
      services.AddTransient<IUsuarioRepository, UsuarioRepository>();

      services.AddControllers();

      services.AddSingleton<IPedidoApi>(RestService.For<IPedidoApi>("http://localhost:7249/"));
      services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

      app.UseCors();
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MeuProjeto v1"));
      }

      app.UseRouting();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
