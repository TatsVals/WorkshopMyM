using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace WebApp
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
            services.AddHttpContextAccessor();
            services.AddDIContainer();
            services.AddConfigHttpClient(Configuration);

            services.AddRazorPages().AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.DictionaryKeyPolicy = null;
                option.JsonSerializerOptions.PropertyNamingPolicy = null;
            }).AddRazorPagesOptions(options =>
            {
                options.Conventions
                       .ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
                options.Conventions.AuthorizeFolder("/Bitacora_Movimientos", "Acceso a Bitacoras");
                options.Conventions.AuthorizeFolder("/BitacoraIngresos", "Acceso a Bitacoras");
                options.Conventions.AuthorizeFolder("/Ordenes", "Acceso a Taller");
                options.Conventions.AuthorizeFolder("/Permisos", "Acceso");
                options.Conventions.AuthorizeFolder("/Products", "Acceso a Taller");
                options.Conventions.AuthorizeFolder("/Roles", "Acceso a Personal");
                options.Conventions.AuthorizeFolder("/Users", "Acceso a Personal");
                
            });
            services.AddAuthorization(config =>
            {
                config.AddPolicy("Acceso a Personal", policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, "Acceso a Personal"));
                config.AddPolicy("Acceso a Taller", policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, "Acceso a Taller"));
                config.AddPolicy("Acceso a Bitacoras", policyBuilder => policyBuilder.RequireClaim(ClaimTypes.Role, "Acceso a Bitacoras"));

            });
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
           {
               option.LoginPath = "/Index";
               option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
               option.AccessDeniedPath = "/Login";
                
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
            app.UseSession();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
            app.UseSession();
        }
    }
}
