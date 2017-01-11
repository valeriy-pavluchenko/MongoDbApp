using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using MongoDbApp.DataAccess.Repositories;
using Microsoft.Extensions.Configuration;
using MongoDbApp.Web.Extensions;
using MongoDbApp.Web.Mappers;
using MongoDbApp.DataAccess.Abstractions;

namespace MongoDbApp.Web
{
    public class Startup
    {
        private readonly IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IConfigurationRoot>(_configuration);

            var dbEndpoint = _configuration.GetAppSettings("MongoDbEndpoint");
            var dbName = _configuration.GetAppSettings("MongoDbName");

            services.AddTransient<ICategoryRepository>(x => new CategoryRepository(dbEndpoint, dbName, "Categories"));
            services.AddTransient<IProductRepository>(x => new ProductRepository(dbEndpoint, dbName, "Products"));

            services.AddTransient<ICategoryMapper, CategoryMapper>();
            services.AddTransient<IProductMapper, ProductMapper>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
