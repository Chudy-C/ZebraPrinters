using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ZebraPrinters.Data;
using ZebraPrinters.Repositories;
using ZebraPrinters.Repositories.Contracts;
using ZebraPrinters.Services;
using ZebraPrinters.Services.Interfaces;

namespace ZebraPrinters
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ZebraPrinters", Version = "v1" });
            });

            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7246/") });

            services.AddDbContextPool<ZebraPrinterDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("UbuntuPrinterConnection"),
                ServerVersion.AutoDetect(Configuration.GetConnectionString("UbuntuPrinterConnection"))));

            services.AddScoped<IPrinterRepository, PrinterRepository>();
            services.AddScoped<IZebraService, ZebraService>();
            services.AddScoped<IPrintService, PrintService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZebraPrinters v1");
                    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                });
            }
            else
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ZebraPrinters v1");
                    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
