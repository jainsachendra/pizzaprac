using GraphQL;
using GraphQL.Language.AST;
using GraphQL.Types;
using PizzaorderBusiness.Services;
using Pizzaordergraphqlmodel.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzaordergraphqlmodel.Query
{
    public class PizzaOrderQuery : ObjectGraphType
    {
        private readonly IPizzaDetailService pizzaDetailService;

        public PizzaOrderQuery(IOrderDetailService orderDetailService,IPizzaDetailService pizzaDetailService)
        {
            Name = nameof(PizzaOrderQuery);
            FieldAsync<ListGraphType<OrderDetailsType>>(
                name: "neworder",
                resolve: async context => await orderDetailService.GetOrderDetailsAsync());
            this.pizzaDetailService = pizzaDetailService;
            FieldAsync<PizzaDetialsType>(
                name: "Pizzadetails",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: async context => await pizzaDetailService.GetPizzaDetailsAsync(context.GetArgument<int>("id")));
            FieldAsync<OrderDetailsType>(
                     name: "orderDetails",
                     arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                     resolve: async context => await orderDetailService.GetOrderDetailsAsync(context.GetArgument<int>("id")));
        }

    }
}
