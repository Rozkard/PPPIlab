using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PPPILab.Models;
using PPPILab.Services;

namespace PPPILab
{
    public class Starter
    {
        public Starter(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //Метод AddScoped був обранний оскільки він забезпечує створення одного екземпляру сервісу на кожен HTTP запит.
            //Він дає можливість для збереження даних користувачів, налаштувань або інших ресурсів на сервері або в базі даних,
            //щоб вони залишалися доступними після закриття браузера або перезавантаження сторінки. 
            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IHistoryService, HistoryService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PPPILab API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "PPPILab API V1");
                });
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
