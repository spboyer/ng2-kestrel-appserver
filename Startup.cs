using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace ng2_kestrel_appserver
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; set; }

public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Map the #SpaSettings section to the <see cref=SpaSettings /> class
            services.Configure<SpaSettings>(Configuration.GetSection("SpaSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<SpaSettings> spaSettings)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            ConfigureRoutes(app, spaSettings.Value);

        }

        private void ConfigureRoutes(IApplicationBuilder app, SpaSettings spaSettings)
        {
            // If the route contains '.' then assume a file to be served
            // and try to serve using StaticFiles
            // if the route is spa route then let it fall through to the
            // spa index file and have it resolved by the spa application
            app.MapWhen(context => {
                var path = context.Request.Path.Value;
                return !path.Contains(".");
            },
            spa => {
                spa.Use((context, next) =>
                {
                    context.Request.Path = new PathString("/" + spaSettings.DefaultPage);
                    return next();
                });

                spa.UseStaticFiles();
            });

            // reserved for custom routes: internationalization etc.
            // var routeBuilder = new RouteBuilder(app);
            // app.UseRouter(routeBuilder.Build());
        }
    }
}
