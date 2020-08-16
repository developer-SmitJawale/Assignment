using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment.Engine
{
    public class BuyXYForZ : DiscountEngine
    {
        public override decimal CalculateDiscount()
        {
            var promotions = GetPromotions(this.Promotion.Code);

            List<int> combinations = new List<int>();
            decimal price = 0.0M;
            decimal discount = 0.0M;

            foreach (var promotion in promotions)
            {
                var cartItem = this.OrderBase.Cart.Items.FirstOrDefault(p => p.Product.Sku == promotion.ProductSku);
                var quantity = cartItem.Quantity;

                int quotient = Math.DivRem(quantity, (int)promotion.Quantity, out int remainder);

                combinations.Add(quantity);
                price += cartItem.Product.Price;
            }

            var combination = combinations.Min();

            if(combination != 0)
            {
                discount = combination * (price - (decimal)this.Promotion.DiscountPrice);
            }

            return discount;
        }

        private List<Promotion> GetPromotions(string code)
        {
            return new List<Promotion>
            {
                new Promotion { Code = "A", DiscountPrice = 130, ProductSku = "A", Quantity = 3, Type = "BuyXForY" },
                new Promotion { Code = "B", DiscountPrice = 45, ProductSku = "B", Quantity = 2, Type = "BuyXForY" },
                new Promotion { Code = "CD", DiscountPrice = 30, ProductSku = "C", Quantity = 1, Type = "BuyXYForZ" },
                new Promotion { Code = "CD", DiscountPrice = 30, ProductSku = "D", Quantity = 1, Type = "BuyXYForZ" }
            }.Where(p => p.Code == code).ToList();
        }
    }
}
