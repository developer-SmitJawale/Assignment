using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment.Engine
{
    public class BuyXForY : DiscountEngine
    {
        public override decimal CalculateDiscount()
        {
            var discount = 0.0M;

            var quantity = this.OrderBase.Cart.Items.FirstOrDefault(p => p.Product.Sku == this.Promotion.ProductSku).Quantity;

            var quotient = Math.DivRem(quantity, this.Promotion.Quantity, out int remainder);
            var productPrice = this.OrderBase.Cart.Items.FirstOrDefault(p => p.Product.Sku == this.Promotion.ProductSku).Product.Price;

            if(quotient > 0)
            {
                var totalPrice = (remainder > 0 ? (productPrice * remainder) : 0) + ((decimal)this.Promotion.DiscountPrice * quotient);
                discount = quantity * productPrice - totalPrice;
            }

            return discount;
        }
    }
}
