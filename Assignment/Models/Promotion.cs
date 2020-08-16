using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Models
{
    public class Promotion
    {
        public string Code { get; set; }

        public string ProductSku { get; set; }

        public string Type { get; set; }

        public int Quantity { get; set; }

        public decimal? DiscountPrice { get; set; }

        public decimal? DiscountPercentage { get; set; }
    }
}
