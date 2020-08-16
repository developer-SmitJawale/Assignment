using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Models
{
    public class Cart
    {
        public Cart()
        {
            this.Items = new List<CartItem>();
        }

        public IList<CartItem> Items { get; set; }
    }

    public class CartItem
    {

    }
}
