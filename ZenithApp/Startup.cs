using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorStrap;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage;
using Tewr.Blazor.FileReader;
using ZenithApp.Data;
using ZenithApp.model;
using ZenithApp.services;

namespace ZenithApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<ApplicationDbContextMaria>(options => options
               .UseMySql("Server=localhost; Database=zenith;User=root;Password=ranger14;IgnoreCommandTransaction=true",
                   mysqlOptions =>
                      mysqlOptions.ServerVersion(new ServerVersion(new Version(5, 5, 57), ServerType.MariaDb))), ServiceLifetime.Singleton);

            services.AddDbContext<ApplicationDbContextMaria>(ServiceLifetime.Transient);
            services.AddSingleton<Register>();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddBootstrapCss();
            services.AddSingleton<BasketService>();

            services.AddSingleton<ProductService>();
            services.AddSingleton<TypeProductService>();
            services.AddSingleton<Register>();
            services.AddFileReaderService(options => options.InitializeOnFirstCall = true);
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Information);
                builder.AddNLog("Nlog.config");
                builder.AddConsole();

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
