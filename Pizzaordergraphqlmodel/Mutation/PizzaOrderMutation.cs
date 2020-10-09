using Data.Entities;
using Data.Enum;
using GraphQL;
using GraphQL.Types;
using PizzaorderBusiness.Model;
using PizzaorderBusiness.Services;
using Pizzaordergraphqlmodel.Enums;
using Pizzaordergraphqlmodel.InputTypes;
using Pizzaordergraphqlmodel.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Pizzaordergraphqlmodel.Mutation
{
   public class PizzaOrderMutation:ObjectGraphType
    {
        public PizzaOrderMutation(IPizzaDetailService pizzaDetailService, IOrderDetailService orderDetailService)
        {
            Name = nameof(PizzaOrderMutation);
            FieldAsync<OrderDetailsType>(
                name: "createOrder",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OrderdEtailsInputType>> { Name = "orderDetails" }),
                resolve: async context =>
                {
                    
                    var order = context.GetArgument<OrderDetailsModel>("orderDetails");

                    var orderDetails = new OrderDetails(order.Addressline1, order.Addressline2, order.MobileNo, order.Amount);
                    orderDetails = await orderDetailService.Createasync(orderDetails);

                    var pizzaDetails = order.pizzaDetails.Select(x => new PizzaDetails(x.Name, x.Toppings, x.Price, x.Size, orderDetails.Id));
                    pizzaDetails = await pizzaDetailService.CreateBulkAsync(pizzaDetails, orderDetails.Id);

                    orderDetails.PizzaDetails = pizzaDetails.ToList();
                    return orderDetails;
                });
            //
            FieldAsync<OrderDetailsType>(
                name: "updateStatus",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" },
                new QueryArgument<NonNullGraphType<OrderStatusEnumType>> { Name = "status" }
                ),
                resolve: async context =>
                 {
                     int orderId = context.GetArgument<int>("id");
                     OrderStatus orderStatus = context.GetArgument<OrderStatus>("status");
                     return await orderDetailService.UpdateStatusAsync(orderId, orderStatus);
                 }
                );
            FieldAsync<OrderDetailsType>(
                name: "deletepizzadetails",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }
                    ),
                resolve: async context =>
                {
                    int pizzadetailsid = context.GetArgument<int>("id");
                    int orderid = await pizzaDetailService.DeletePizzaDetailAsync(pizzadetailsid);
                    return await orderDetailService.GetOrderDetailsAsync(orderid);
                }
                );
        
        }
    }
}
