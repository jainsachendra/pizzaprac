using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Entities;
using Microsoft.VisualBasic;

namespace PizzaorderBusiness.Services
{
    public interface IPizzaDetailService
    {
       Task<PizzaDetails> GetPizzaDetailsAsync(int id);
        IEnumerable<PizzaDetails> GetAllPizzaDetailsForOrder(int orderId);
        Task<IEnumerable<PizzaDetails>> CreateBulkAsync(IEnumerable<PizzaDetails> pizzaDetails, int orderid);
        Task<int> DeletePizzaDetailAsync(int pizzaDetailsId);
    }
    public class PizzaDetailService : IPizzaDetailService
    {
        private readonly PizzaDbContext pizzaDbContext;

        public PizzaDetailService(PizzaDbContext pizzaDbContext)
        {
            this.pizzaDbContext = pizzaDbContext;
        }
        public async Task<PizzaDetails>GetPizzaDetailsAsync(int id)
        {
            return await pizzaDbContext.pizzaDetails.FindAsync(id);
        }
        public IEnumerable<PizzaDetails> GetAllPizzaDetailsForOrder(int orderId)
        {
            return pizzaDbContext.pizzaDetails.Where(x => x.OrderDetailsId == orderId).ToList();
        }
        public async Task<IEnumerable<PizzaDetails>>CreateBulkAsync(IEnumerable<PizzaDetails>pizzaDetails,int orderid)
        {
            await pizzaDbContext.pizzaDetails.AddRangeAsync(pizzaDetails);
            await pizzaDbContext.SaveChangesAsync();
            return pizzaDbContext.pizzaDetails.Where(x=>x.OrderDetailsId==orderid);
        }
        public async Task<int> DeletePizzaDetailAsync(int pizzaDetailsId)
        {
            var PizzaDetails = await pizzaDbContext.pizzaDetails.FindAsync(pizzaDetailsId);
            if (PizzaDetails != null)
            {
                int orderId = PizzaDetails.OrderDetailsId;
                pizzaDbContext.pizzaDetails.Remove(PizzaDetails);
                await pizzaDbContext.SaveChangesAsync();
                return orderId;
            }
            return 0;
        }
    }


}
