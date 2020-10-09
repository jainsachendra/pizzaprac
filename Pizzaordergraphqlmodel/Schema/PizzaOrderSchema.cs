using Pizzaordergraphqlmodel.Mutation;
using Pizzaordergraphqlmodel.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzaordergraphqlmodel.Schema
{
    public class PizzaOrderSchema : GraphQL.Types.Schema
    {
        private readonly IServiceProvider serviceProvider;

        public PizzaOrderSchema(IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            //Services = services;
            Query = (PizzaOrderQuery)serviceProvider.GetService(typeof(PizzaOrderQuery));
            Mutation = (PizzaOrderMutation)serviceProvider.GetService(typeof(PizzaOrderMutation));
        }
    }
}
