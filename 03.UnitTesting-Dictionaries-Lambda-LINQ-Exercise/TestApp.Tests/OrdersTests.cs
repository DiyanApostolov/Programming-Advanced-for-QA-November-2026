using System;
using NUnit.Framework;

namespace TestApp.Tests;

public class OrdersTests
{
    [Test]
    public void Test_Order_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrage
        string[] input = Array.Empty<string>();

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Order_WithMultipleOrders_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] input = new string[] { "apple 1.5 1", "banana 2 2", "apple 1.99 2", "banana 1.25 1", "orange 1.98 1" };

        string expected = $"apple -> 5.97{Environment.NewLine}" +
                          $"banana -> 3.75{Environment.NewLine}" +
                          $"orange -> 1.98";

        // Act
        string result = Orders.Order(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] products = { "apple 1.9999 3", "banana 1.251232 3", "orange 0.5093 2" };

        string expected = $"apple -> 6.00{Environment.NewLine}" +
                          $"banana -> 3.75{Environment.NewLine}" +
                          $"orange -> 1.02";

        // Act
        string result = Orders.Order(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    {
        // Arrange
        string[] products = { "apple 1.5 3.5", "banana 1.50 2.85", "orange 0.99 2.18" };

        string expected = $"apple -> 5.25{Environment.NewLine}" +
                          $"banana -> 4.28{Environment.NewLine}" +
                          $"orange -> 2.16";

        // Act
        string result = Orders.Order(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    //[Test]
    //public void Test_Order_WithRoundedPrices_ShouldReturnTotalPrice()
    //{
    //    // Arrange
    //    string[] input = new string[] { "orange 1.8032 1", "apple 1.526453 3", "banana 2.2834682 5", };

    //    string expected = $"orange -> 1.80{Environment.NewLine}" +
    //                      $"apple -> 4.58{Environment.NewLine}" +
    //                      $"banana -> 11.42";

    //    // Act
    //    string result = Orders.Order(input);

    //    // Assert
    //    Assert.That(result, Is.EqualTo(expected));
    //}

    //[Test]
    //public void Test_Order_WithDecimalQuantities_ShouldReturnTotalPrice()
    //{
    //    // Arrange
    //    string[] input = new string[] { "banana 1.25 4.037", "apple 1.99 3.3", "orange 1.80 1.2" };

    //    string expected = $"banana -> 5.05{Environment.NewLine}" +
    //                      $"apple -> 6.57{Environment.NewLine}" +
    //                      "orange -> 2.16";

    //    // Act
    //    string result = Orders.Order(input);

    //    // Assert
    //    Assert.That(result, Is.EqualTo(expected));
    //}

}
