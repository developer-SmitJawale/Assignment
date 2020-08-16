using Assignment.Engine;
using Assignment.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestAssignment
{
    [TestClass]
    public class ProcessOrderTest
    {
        [TestMethod, TestCategory("smoke")]
        public void NoPromotionOrderProcessdSuccessfully()
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

        [TestMethod, TestCategory("smoke")]
        public void WithSingleProductPromotionOrderProcessdSuccessfully()
        {
            // Arrange
            var order = new Order();

            order.Cart = new Cart();
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 50.0M, Sku = "A" }, Quantity = 5 });
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 30.0M, Sku = "B" }, Quantity = 5 });
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 20.0M, Sku = "C" }, Quantity = 1 });

            order.AddPromotion(new Promotion { Code = "A", DiscountPrice = 130, ProductSku = "A", Quantity = 3, Type = "BuyXForY" });
            order.AddPromotion(new Promotion { Code = "B", DiscountPrice = 45, ProductSku = "B", Quantity = 2, Type = "BuyXForY" });

            // Act
            var engine = new CalculationEngine();

            var result = engine.CalculateNetAmount(order);

            // Assert
            Assert.AreEqual(result, 370);
        }

        [TestMethod, TestCategory("smoke")]
        public void WithCombinationProductPromotionOrderProcessdSuccessfully()
        {
            // Arrange
            var order = new Order();

            order.Cart = new Cart();
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 50.0M, Sku = "A" }, Quantity = 3 });
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 30.0M, Sku = "B" }, Quantity = 5 });
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 20.0M, Sku = "C" }, Quantity = 1 });
            order.Cart.Items.Add(new CartItem { Product = new Product { Price = 15.0M, Sku = "D" }, Quantity = 1 });

            order.AddPromotion(new Promotion { Code = "A", DiscountPrice = 130, ProductSku = "A", Quantity = 3, Type = "BuyXForY" });
            order.AddPromotion(new Promotion { Code = "B", DiscountPrice = 45, ProductSku = "B", Quantity = 2, Type = "BuyXForY" });
            order.AddPromotion(new Promotion { Code = "CD", DiscountPrice = 30, ProductSku = "C", Quantity = 1, Type = "BuyXYForZ" });
            order.AddPromotion(new Promotion { Code = "CD", DiscountPrice = 30, ProductSku = "D", Quantity = 1, Type = "BuyXYForZ" });

            // Act
            var engine = new CalculationEngine();

            var result = engine.CalculateNetAmount(order);

            // Assert
            Assert.AreEqual(result, 280);
        }

    }
}
