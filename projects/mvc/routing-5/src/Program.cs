using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace MvcRouting
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, ILoggerFactory logger, IConfiguration configuration)
        {
            //These are three services available at constructor
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore().
                SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory logger, IConfiguration configuration)
        {
            app.UseMvc();
        }
    }

    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                <b>Hello World</b>
                <br/><br/>
                <ul>
                    <li><a href=""/"">/</a></li>
                    <li><a href=""/home"">/home</a></li>
                    <li><a href=""/home/index"">/home/index</a></li>
                    <li><a href=""/about"">/about</a></li>
                </ul>
                </body></html>",
                ContentType = "text/html"
            };
        }

        [Route("About")]
        public ActionResult About()
        {
            return new ContentResult
            {
                Content = @"
                <html><body>
                <b>About Page</b>
                <br/><br/>
                <ul>
                    <li><a href=""/"">/</a></li>
                    <li><a href=""/home"">/home</a></li>
                    <li><a href=""/home/index"">/home/index</a></li>
                </ul>
                </body></html>",
                ContentType = "text/html"
            };
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseEnvironment("Development");
    }
}