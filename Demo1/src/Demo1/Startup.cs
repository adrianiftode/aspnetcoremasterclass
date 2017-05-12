using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;

namespace Demo1
{
	public class Startup
	{
		public IConfigurationRoot Configuration { get; private set; }
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDirectoryBrowser();
			services.AddMvc();
			services.AddMvcCore();

			services.AddOptions();
			//services.Configure<>
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		// global.asax on steroids
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			//app.UseDeveloperExceptionPage();
			//app.UseStaticFiles();
			//app.UseDirectoryBrowser();

			app.UseMvc();
			loggerFactory.AddConsole();

			if (env.IsDevelopment())
			{
			}

			//app.Run(async (context) =>
			//{
			//	var text = $"{env.ToJson()}";
			//	await context.Response.WriteAsync(text);
			//});

			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("MyAppSettings.json");

			Configuration = builder.Build();
		}

		//public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		//{
		//	app.UseDeveloperExceptionPage();
		//}
	}

	internal static class ObjectExtensions
	{
		public static string ToJson(this object obj)
		{
			if (obj == null) return null;

			return JsonConvert.SerializeObject(obj);
		}
	}
}