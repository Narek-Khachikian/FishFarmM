using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FishFarm.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FishFarm.Services;
using static FishFarm.Services.FishFarmSupportedCulturesExtention;
using FishFarmWeb.SharedResources;


namespace FishFarmWeb
{
    public class Startup
    {
        private readonly IConfiguration _configuration;


        public Startup(IConfiguration config)
        {
            _configuration = config;
        }


        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<FishFarmDataContext>(options =>
            {
                options.UseSqlServer(_configuration.GetConnectionString("FishFarmDB"));
            });
            services.AddControllersWithViews().AddRazorRuntimeCompilation().AddViewLocalization().AddDataAnnotationsLocalization(opt =>
            {
                opt.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResource));
            });
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.FishFarmRepository();
            services.SupportedCultures();
            //services.AddSingleton<SupportedCultures>();
        }

        

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,FishFarm.Services.SupportedCultures suportedCultures)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            var localizationOptions = new RequestLocalizationOptions();
            localizationOptions.SetDefaultCulture(suportedCultures.SupportedCulture.Keys.ToArray()[0]).AddSupportedCultures(suportedCultures.SupportedCulture.Keys.ToArray()).AddSupportedUICultures(suportedCultures.SupportedCulture.Keys.ToArray());

            app.UseRequestLocalization(localizationOptions);


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
