using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Models
{
    public abstract class OrderBase
    {
        public int Number { get; set; }

        public Cart Cart { get; set; }
    }

    public class Order : OrderBase
    {

    }
}
