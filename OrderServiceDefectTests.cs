using Microsoft.VisualStudio.TestTools.UnitTesting;
using Week11DefectLifeCycle.Core;

namespace Week11DefectLifeCycle.Tests
{
    [TestClass]
    public class OrderServiceDefectTests
    {
        // ---------- Part 5: defect retest tests ----------

        [TestMethod]
        public void D001_ApplyDiscount_WhenPriceIs200AndDiscountIs20_Returns160()
        {
            // Arrange
            var service = new OrderService();

            // Act
            var result = service.ApplyDiscount(200m, 20m);

            // Assert
            Assert.AreEqual(160m, result);
        }

        [TestMethod]
        public void D002_IsEligibleForFreeShipping_WhenOrderTotalIs100_ReturnsTrue()
        {
            // Arrange
            var service = new OrderService();

            // Act
            var result = service.IsEligibleForFreeShipping(100m);

            // Assert
            Assert.IsTrue(result);
        }

        // ---------- Part 6.3: regression tests ----------

        [TestMethod]
        public void ApplyDiscount_WhenDiscountIsZero_ReturnsOriginalPrice()
        {
            var service = new OrderService();

            var result = service.ApplyDiscount(100m, 0m);

            Assert.AreEqual(100m, result);
        }

        [TestMethod]
        public void ApplyDiscount_WhenDiscountIsOneHundred_ReturnsZero()
        {
            var service = new OrderService();

            var result = service.ApplyDiscount(100m, 100m);

            Assert.AreEqual(0m, result);
        }

        [TestMethod]
        public void CalculateFinalTotal_WhenDiscountedPriceIsEligibleForFreeShipping_ReturnsTotalWithoutShipping()
        {
            var service = new OrderService();

            var result = service.CalculateFinalTotal(200m, 10m, 15m);

            Assert.AreEqual(180m, result);
        }

        [TestMethod]
        public void CalculateFinalTotal_WhenDiscountedPriceIsNotEligibleForFreeShipping_AddsShipping()
        {
            var service = new OrderService();

            var result = service.CalculateFinalTotal(80m, 10m, 15m);

            Assert.AreEqual(87m, result);
        }

        // ---------- Part 10.1: invalid input tests ----------

        [TestMethod]
        public void ApplyDiscount_WhenPriceIsNegative_ThrowsArgumentException()
        {
            var service = new OrderService();

            Assert.ThrowsException<System.ArgumentException>(() =>
                service.ApplyDiscount(-1m, 10m));
        }

        [TestMethod]
        public void ApplyDiscount_WhenDiscountIsNegative_ThrowsArgumentException()
        {
            var service = new OrderService();

            Assert.ThrowsException<System.ArgumentException>(() =>
                service.ApplyDiscount(100m, -5m));
        }

        [TestMethod]
        public void ApplyDiscount_WhenDiscountIsGreaterThan100_ThrowsArgumentException()
        {
            var service = new OrderService();

            Assert.ThrowsException<System.ArgumentException>(() =>
                service.ApplyDiscount(100m, 101m));
        }

        [TestMethod]
        public void CalculateFinalTotal_WhenShippingCostIsNegative_ThrowsArgumentException()
        {
            var service = new OrderService();

            Assert.ThrowsException<System.ArgumentException>(() =>
                service.CalculateFinalTotal(100m, 10m, -5m));
        }
    }
}
