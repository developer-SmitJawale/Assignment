using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
            order.NetAmount = CalculateSubtotal(order.Cart.Items);

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
    }
}
