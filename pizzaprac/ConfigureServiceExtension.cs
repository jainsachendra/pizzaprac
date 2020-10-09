using GraphQL;
using GraphQL.Server;
using Microsoft.Extensions.DependencyInjection;
using PizzaorderBusiness.Services;
using Pizzaordergraphqlmodel.Enums;
using Pizzaordergraphqlmodel.InputTypes;
using Pizzaordergraphqlmodel.Mutation;
using Pizzaordergraphqlmodel.Query;
using Pizzaordergraphqlmodel.Schema;
using Pizzaordergraphqlmodel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pizzaprac
{
    public static class ConfigureServiceExtension
    {
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IPizzaDetailService, PizzaDetailService>();
            services.AddTransient<IOrderDetailService, OrderDetailService>();
            // services.AddTransient<IEventService, EventService>();
        }
        public static void AddCustomGraphQLServices(this IServiceCollection services)
        {
            // GraphQL services
            services.AddScoped<IServiceProvider>(c => new FuncServiceProvider(type => c.GetRequiredService(type)));
            services.AddGraphQL(options =>
            {
                 // options.EnableMetrics = true;
                  //options.ExposeExceptions = false; // false prints message only, true will ToString
                //  options.UnhandledExceptionDelegate = context =>
                //  {
                //      Console.WriteLine("Error: " + context.OriginalException.Message);
                //  };
            })
        .AddSystemTextJson(deserializerSettings => { }, serializerSettings => { }) // For .NET Core 3+
      // .AddNewtonsoftJson(deserializerSettings => { }, serializerSettings => { })
            .AddWebSockets()
            .AddDataLoader()
            .AddGraphTypes(typeof(PizzaOrderSchema));

        }

        private static void AddGraphTypes(Type type)
        {
            throw new NotImplementedException();
        }

        public static void AddCustomGraphQLTypes(this IServiceCollection services)
        {
            services.AddSingleton<OrderDetailsType>();
            services.AddSingleton<PizzaDetialsType>();
            services.AddSingleton<ToppingsEnumType>();
            services.AddSingleton<PizzaOrderQuery>();
            services.AddSingleton<PizzaOrderSchema>();
            services.AddSingleton<OrderStatusEnumType>();
            services.AddSingleton<PizzaOrderMutation>();
            services.AddSingleton<OrderdEtailsInputType>();
            services.AddSingleton<PizzaDetailsInputType>();
        }
    }
    }
