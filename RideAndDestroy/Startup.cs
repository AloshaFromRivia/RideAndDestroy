using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RideAndDestroy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideAndDestroy
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ShopDbContext>();
            services.AddTransient<IRepository, ShopDbContext>();
            services.AddMvc(s=>s.EnableEndpointRouting=false);
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           app.UseDeveloperExceptionPage();
            app.UseSession();
           app.UseStaticFiles();
           app.UseRouting();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "",
                    template: "{controller=Home}/{action}/{productCategory}/{*catchall}"
                    );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/"
                    );
            }
            );
        }  
    }
}
