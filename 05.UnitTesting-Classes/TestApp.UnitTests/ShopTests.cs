using NUnit.Framework;

using System;

using TestApp.Store;

namespace TestApp.UnitTests;

public class ShopTests
{
    private Shop _shop;

    [SetUp]
    public void SetUp()
    {
        _shop = new Shop();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndGetBoxes_ReturnsSortedBoxes()
    {
        // Arrange
        //"{serial_number} {name} {quantity} {price}"
        string[] products = { "98765 MousePad 2 8", "12345 Keyboard 5 10", "54321 Mouse 3 15" };

        string expected = $"12345{Environment.NewLine}" +
                            $"-- Keyboard - $10.00: 5{Environment.NewLine}" +
                            $"-- $50.00{Environment.NewLine}" +
                            $"54321{Environment.NewLine}" +
                            $"-- Mouse - $15.00: 3{Environment.NewLine}" +
                            $"-- $45.00{Environment.NewLine}" +
                            $"98765{Environment.NewLine}" +
                            $"-- MousePad - $8.00: 2{Environment.NewLine}" +
                            $"-- $16.00";

        // Act
        string result = _shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndGetBoxes_ReturnsEmptyString_WhenNoProductsGiven()
    {
        // Arrange
        string[] products = Array.Empty<string>();

        // Act
        string result = _shop.AddAndGetBoxes(products);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
