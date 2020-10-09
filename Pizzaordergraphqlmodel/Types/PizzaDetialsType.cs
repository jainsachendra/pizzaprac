using Data.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzaordergraphqlmodel.Types
{
    public class PizzaDetialsType : ObjectGraphType<PizzaDetails>
    {
        public PizzaDetialsType()
        {
            Name = nameof(PizzaDetialsType);
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.OrderDetailsId);
            Field(x => x.Price);
            Field<StringGraphType>(name: "toppings",
                resolve: context => context.Source.Toppings.ToString());

        }
    }
}
