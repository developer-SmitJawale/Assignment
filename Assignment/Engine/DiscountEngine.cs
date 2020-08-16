using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Engine
{
    /// <summary>
    /// Discount Engine
    /// Implemented using strategy pattern
    /// </summary>
    public abstract class DiscountEngine
    {
        public virtual Promotion MyProperty { get; set; }

        public OrderBase OrderBase { get; set; }

        public abstract decimal CalculateDiscount();
    }
}
