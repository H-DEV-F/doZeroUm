using Dominio.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositorio.Contexto;
using Repositorio.Repositorios;

namespace ApiBanco
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("config.json", optional: false);
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddControllers();
            var connectionString = Configuration.GetConnectionString("db_banco");
            services.AddDbContext<BancoContexto>(option =>
                                                option.UseSqlServer(connectionString, m => m.MigrationsAssembly("Repositorio")));

            #region scopeservice
            services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
            services.AddScoped<IContaRepositorio, ContaRepositorio>();
            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            #endregion

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "REST API BANCO",
                    Version = "v1",
                    Description = "REST API BANCO",
                    Contact = new OpenApiContact
                    {
                        Name = "DEV"
                    }
                });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "REST API BANCO");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
        }
    }
}
