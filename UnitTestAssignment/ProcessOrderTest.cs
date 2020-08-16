using Assignment.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAssignment
{
    [TestClass]
    public class ProcessOrderTest
    {
        [TestMethod]
        public void NoPromotpnOrderProcessdSuccessfully()
        {
            // Arrange
            var order = new Order();

            order.Cart = new Cart();
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 50.0M, Sku = "A" }, Quantity = 1 });
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 30.0M, Sku = "B" }, Quantity = 1 });
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 20.0M, Sku = "C" }, Quantity = 1 });

            // Act
            var engine = new CalculationEngine();

            var result = engine.CalculateNetAmount(order);

            // Assert
            Assert.AreEqual(result, 100);
        }
    }
}
