using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;
using Data;
using Data.Enum;

namespace Pizzaordergraphqlmodel.Enums
{
    public class ToppingsEnumType : EnumerationGraphType<Toppings>
    {
        public ToppingsEnumType()
        {
            Name = nameof(ToppingsEnumType);

        }
    }
}
