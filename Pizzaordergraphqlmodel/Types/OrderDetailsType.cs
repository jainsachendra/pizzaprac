using Data.Entities;
using GraphQL.Types;
using PizzaorderBusiness.Services;
using Pizzaordergraphqlmodel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzaordergraphqlmodel.Types
{
    public class OrderDetailsType : ObjectGraphType<OrderDetails>
    {
        private readonly PizzaDetailService pizzaDetailsService;

        public OrderDetailsType(PizzaDetailService pizzaDetailsService)
        {
            Name = nameof(OrderDetailsType);
            Field(x => x.Id);
            Field(x => x.AddressLine1);
            Field(x => x.AddressLine2);
            Field(x => x.MobileNo);
            Field(x => x.Amount);
            Field(x => x.Date);
            Field<OrderStatusEnumType>(
                name: "orderStatus",
                resolve: context => context.Source.OrderStatus);
            this.pizzaDetailsService = pizzaDetailsService;
            Field<ListGraphType<PizzaDetialsType>>(
               name: "pizzadetail",
               resolve: context => pizzaDetailsService.GetAllPizzaDetailsForOrder(context.Source.Id));
        }
    }
}
