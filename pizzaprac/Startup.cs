using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Data;
using Microsoft.EntityFrameworkCore;
using GraphQL.Server.Ui.Playground;
using Pizzaordergraphqlmodel.Schema;
using GraphQL.Server;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using PizzaorderBusiness.Services;

namespace pizzaprac
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
        {
            // For Async IO Operations
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });
            services.AddControllers();
            services.AddDbContext<PizzaDbContext>(Options => Options.UseSqlServer(Configuration.GetConnectionString("Default")
                ), contextLifetime: ServiceLifetime.Singleton);
            services.AddCustomService();
            services.AddCustomGraphQLServices();
            services.AddCustomGraphQLTypes();
            services.AddSingleton<PizzaDetailService>();
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
            app.UseWebSockets();
            app.UseGraphQL<PizzaOrderSchema>();
            app.UseGraphQLWebSockets<PizzaOrderSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions() { GraphQLEndPoint = "/PracticeArea", Path = "/ui/Playground" });
        }
    }
}
