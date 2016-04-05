using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ng2_kestrel_appserver
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);



            /// http://docs.asp.net/en/latest/fundamentals/static-files.html
            // need to write a middleware piece potentially and read up more here
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("index.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();

            //app.UseIISPlatformHandler();

            /*            app.UseMvc(routes =>
                         {
                            TODO: NEED Fallback routes
                            // 404 routingfor SPA
                            routes.MapRoute("spa-fallback", "{*anything}", new { controller = "Home", action = "Index" });

                         });*/
        }

        // Entry point for the application.
        //public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}
