using GraphQL.Types;
using PizzaorderBusiness.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzaordergraphqlmodel.InputTypes
{
    public class OrderdEtailsInputType:InputObjectGraphType<OrderDetailsModel>
    {
        public OrderdEtailsInputType()
        {
            Name = nameof(OrderdEtailsInputType);
            Field(x => x.Addressline1);
            Field(x => x.Addressline2,nullable:true);
            Field(x => x.MobileNo);
            Field(x => x.Amount);
            Field<ListGraphType<PizzaDetailsInputType>>("pizzaDetails");
        }
    }
}
