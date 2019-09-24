using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PainelCipa.Models;
using PainelCipa.Data;
using PainelCipa.Data.FileManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;

namespace PainelCipa
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
            services.AddMvc(options => options.Filters.Add(new AuthorizeFilter()));
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
               {
                   options.AccessDeniedPath = "/Login/";
                   options.LoginPath = "/Login/";
                   options.LogoutPath = "/Login/";
               });
            services.AddSingleton<IConfigureOptions<CookieAuthenticationOptions>, ConfigureCookie>();

            services.AddDbContext<PainelCipaContext>(options =>
                    //options.UseSqlServer(Configuration.GetConnectionString("PainelCipaContext")));
                    options.UseMySql(Configuration.GetConnectionString("PainelCipaContext"), builder => builder.MigrationsAssembly("PainelCipa")));
            services.AddScoped<SeedingService>();
            services.AddTransient<IFileManager, FileManager>();
            services.AddDistributedMemoryCache();

            //services.AddSession(options =>
            //{
            //    options.IdleTimeout = TimeSpan.FromHours(2.0);
            //    options.Cookie.HttpOnly = true;
            //    options.Cookie.IsEssential = true;
            //});


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });

        }
    }
}
