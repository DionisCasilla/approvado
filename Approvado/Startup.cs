using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using Approvado.Models;
using Microsoft.EntityFrameworkCore;
using Approvado.Services;

namespace Approvado
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuración de la base de datos
          string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DbA46041ApprovadoContext>(options => options.UseSqlServer(connectionString));

            // Configuración de MVC y otras características
            // services.AddControllersWithViews()÷;
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Approvado Api", Version = "v1" });
            });


            // Registrar tus servicios personalizados aquí
              services.AddScoped<IEmpresaService, EmpresaService>();
              services.AddScoped<EmpresaService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Approvado Api V1");
                });
            
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

          app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseDeveloperExceptionPage(); // Debería estar al final
        }
    }
}
