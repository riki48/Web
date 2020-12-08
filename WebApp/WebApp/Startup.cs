
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
			services.AddDbContext<AppDBContext>(options => options.UseSqlServer(_configString.GetConnectionString("DefaultConnection")));
			services.AddRouting();
			services.AddTransient<IAllCars,CarRepository>();
			services.AddTransient<ICarsCategory, CategoryRepository>();
			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{

			app.UseDeveloperExceptionPage();
			app.UseStatusCodePages();
			app.UseStaticFiles();
			app.UseMvcWithDefaultRoute();


			using (var scope = app.ApplicationServices.CreateScope())
			{
				AppDBContext content = scope.ServiceProvider.GetRequiredService<AppDBContext>();
				DBObjects.Initial(content);
			}
			
		}
	}
}
