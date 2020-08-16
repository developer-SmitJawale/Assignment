using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Assignment.Models
{
    public abstract class OrderBase
    {
        public int Number { get; set; }

        public Cart Cart { get; set; }
    }

    public class Order : OrderBase
    {
        public Order()
        {
            this.Promotions = new List<Promotion>();
        }

        public decimal NetAmount { get; set; }

        // 
        /// <summary>
        /// Design Pattern : Aggregate root pattern
        /// For validating/restricting no more than one promotions are added for same product 
        /// </summary>
        private List<Promotion> Promotions { get; set; }

        public void AddPromotion(Promotion promotion)
        {
            if(Promotions.FirstOrDefault(p=>p.ProductSku == promotion.ProductSku) == null)
            {
                this.Promotions.Add(promotion);
            }
        }

    }
}
