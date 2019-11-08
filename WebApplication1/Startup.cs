using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication1.Data;
using WebApplication1.Data.Interfaces;
using WebApplication1.Data.Models;
using WebApplication1.Data.Repository;

namespace WebApplication1 {
    public class Startup {
        private IConfigurationRoot _confString;
        
        public Startup(Microsoft.AspNetCore.Hosting.IHostingEnvironment hostEnv) {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllCars, CarRepository>(); // Позволяет соединить интерфейс и класс, который реализует этот интерфейс
            services.AddTransient<ICarsCategory, CategoryRepository>();
           // services.AddMvc(); // Подключение MVC
            //services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(p => ShopCart.GetCart(p)); // индивидуальная корзина
            services.AddMemoryCache();
            services.AddSession();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "default",
                template: "{controller=CarsController}/{action=List}/");
            });
            //app.UseMvcWithDefaultRoute();

            using (var scope = app.ApplicationServices.CreateScope()) {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DbObjects.Initial(content);
            }
        }
    }
}
