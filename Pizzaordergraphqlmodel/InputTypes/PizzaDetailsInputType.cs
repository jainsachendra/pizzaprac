using Data.Enum;
using GraphQL.Types;
using PizzaorderBusiness.Model;
using Pizzaordergraphqlmodel.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzaordergraphqlmodel.InputTypes
{
  public  class PizzaDetailsInputType:InputObjectGraphType<PizzaDetailsModel>
    {
        public PizzaDetailsInputType()
        {
            Name = nameof(PizzaDetailsInputType);
            Field(x => x.Name);
            Field(x => x.Size);
            Field(x => x.Price);
            Field<ToppingsEnumType>("toppings");

        }
    }
}
