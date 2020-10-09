using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzaordergraphqlmodel.Enums
{
    public class OrderStatusEnumType : EnumerationGraphType
    {
        public OrderStatusEnumType()
        {
            Name = "orderStatus";

            AddValue("Created", "Order was created.", 1);
            AddValue("InKitchen", "Order is preparing.", 2);
            AddValue("OnTheWay", "Order is on the way.", 3);
            AddValue("Delivered", "Order was Delivered.", 4);
            AddValue("Canceled", "Order was Canceled.", 5);
        }
    }
}
