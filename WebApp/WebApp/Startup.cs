using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Data.Interfaces;
using WebApp.Data.Mocks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using WebApp.Data;
using Microsoft.EntityFrameworkCore;
using WebApp.Data.Repository;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WebApp.Data;
using WebApp.Data.Models;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace WebApp
{
	public class Startup
	{
		private IConfigurationRoot _configString;
		
		public Startup(IHostingEnvironment hostEnv)
		{
			_configString = new ConfigurationBuilder().
				SetBasePath(hostEnv.ContentRootPath).
				AddJsonFile("dbsettings.json").
				Build();
		}
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			//services.AddEntityFrameworkSqlServer().AddDbContext<AppDBContext>(options => options.UseSqlServer(_configString.GetConnectionString("DefaultConnection")));
			
			services.AddRouting();
			services.AddTransient<IAllCars,CarRepository>();
			services.AddTransient<ICarsCategory, CategoryRepository>();
			services.AddTransient<IAllOrders, OrdersRepository>();
			services.AddDbContext<Data.AppContext>(options => options.UseSqlServer(_configString.GetConnectionString("DefaultConnection"))); // ?
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddScoped(sp => ShopCart.GetCart(sp));
			services.AddMvc();
			services.AddMemoryCache();
			services.AddSession();
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.LoginPath = new PathString("/Account/Login");
					options.AccessDeniedPath = new PathString("/Account/Login");
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{

			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseSession();
			//app.UseMvcWithDefaultRoute();
			app.UseMvc(routes =>
			{
				routes.MapRoute(name: "default", template: "{controller=Home}/{action=index}/{id?}");
				routes.MapRoute(name: "CategoryFilter", template: "Car/{action}/{category?}", defaults: new { Controller = "Car", action = "List" });
			});
			

			using (var scope = app.ApplicationServices.CreateScope())
			{
				Data.AppContext content = scope.ServiceProvider.GetRequiredService<Data.AppContext>();
				DBobjects.Initial(content);
			}
			
		}
	}
}
