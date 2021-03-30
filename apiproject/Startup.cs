
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Text;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Serialization;
using Data;
using Baseurl;
namespace apiproject
{
    public class Startup
    {    
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
               
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   services.AddDbContext<EcommerContext>(options=>options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
              services.AddControllers()
        .AddNewtonsoftJson(options => 
        options.SerializerSettings.ContractResolver=new CamelCasePropertyNamesContractResolver());
            services.AddHttpContextAccessor();
            services.AddSingleton<IrulService>(o=>
            {
            var ancessor=o.GetRequiredService<IHttpContextAccessor>();
            var request=ancessor.HttpContext.Request;
            var uri=string.Concat(request.Scheme,"://",request.Host.ToUriComponent());
            return new urlService(uri);
            }
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
