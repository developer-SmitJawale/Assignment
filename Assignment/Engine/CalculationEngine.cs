using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment.Engine
{
    public interface ICalculationEngine
    {
        decimal CalculateNetAmount(Order order);
    }

    public class CalculationEngine : ICalculationEngine
    {
        public decimal CalculateNetAmount(Order order)
        {
            // Iterate ove all unique Promotions
            foreach (var promo in order.GetPromotions().GroupBy(p =>p.Code)
                .Select(g => g.FirstOrDefault())
                .ToList())
            {
                var engine = GetEngine(promo.Type);
                engine.Promotion = promo;
                engine.OrderBase = order;
                order.TotalDiscount += engine.CalculateDiscount();
            }

            order.NetAmount = CalculateSubtotal(order.Cart.Items);
            order.NetAmount = order.NetAmount - order.TotalDiscount;

            return order.NetAmount;
        }

        private decimal CalculateSubtotal(IList<CartItem> items)
        {
            decimal price = 0.0M;

            foreach (var item in items)
            {
                price += item.Product.Price * item.Quantity;
            }

            return price;
        }

        private DiscountEngine GetEngine(string type)
        {
            // Get the type contained in the string
            Type engineType = Type.GetType("Assignment.Engine." + type, true);

            // create instance of type
            object instance = Activator.CreateInstance(engineType);

            return (DiscountEngine)instance; 
        }
    }
}
