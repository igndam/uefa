using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UEFA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace UEFA
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<UEFAContext>(opt => opt.UseInMemoryDatabase());
            services.AddMvc();
            var connection = @"Server=(localdb)\mssqllocaldb;Database=UEFA.NewDb;Trusted_Connection=True;";
            services.AddDbContext<UEFAContext>(options => options.UseSqlServer(connection));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = "http://localhost:50151",
                RequireHttpsMetadata = false
                //ApiName = "scope.fullaccess"
            });
            app.UseStatusCodePages();
            app.UseMvc();
        }
       /* public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }*/
    }
}