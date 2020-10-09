using Data;
using Data.Entities;
using Data.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PizzaorderBusiness.Services
{
    public interface IOrderDetailService
    {
        Task<OrderDetails> Createasync(OrderDetails orderDetails);
        Task<IEnumerable<OrderDetails>> GetOrderDetailsAsync();
        Task<OrderDetails> GetOrderDetailsAsync(int orderId);
        Task<OrderDetails> UpdateStatusAsync(int orderid, OrderStatus orderStatus);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private readonly PizzaDbContext pizzaDbContext;

        public OrderDetailService(PizzaDbContext pizzaDbContext)
        {
            this.pizzaDbContext = pizzaDbContext;
        }
        public async Task<IEnumerable<OrderDetails>> GetOrderDetailsAsync()
        {
            return await pizzaDbContext.orderDetails.Where(x => x.OrderStatus == OrderStatus.Canceled).ToListAsync();
        }
        public async Task<OrderDetails> GetOrderDetailsAsync(int orderId)
        {
            return await pizzaDbContext.orderDetails.FindAsync(orderId);
        }
        public async Task<OrderDetails> Createasync(OrderDetails orderDetails)
        {
            pizzaDbContext.orderDetails.Add(orderDetails);
            await pizzaDbContext.SaveChangesAsync();
            return orderDetails;
        }
        public async Task<OrderDetails> UpdateStatusAsync(int orderid,OrderStatus orderStatus) {
            var orderdetails = await pizzaDbContext.orderDetails.FindAsync(orderid);
            if (orderdetails != null)
            {
                orderdetails.OrderStatus = orderStatus;
                await pizzaDbContext.SaveChangesAsync();
            }
            return orderdetails;
        }

    }
}
