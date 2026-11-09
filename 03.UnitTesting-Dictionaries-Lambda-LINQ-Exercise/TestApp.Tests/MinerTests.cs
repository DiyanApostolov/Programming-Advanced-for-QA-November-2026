using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Text;

namespace TestApp.Tests;

public class MinerTests
{
    [Test]
    public void Test_Mine_WithEmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Mine_WithMixedCaseResources_ShouldBeCaseInsensitive()
    {
        // Arrange
        string[] input = new string[] { "Gold 3", "GOLD 2", "Silver 10", "golD 3", "SILveR 20" };

        string expected = $"gold -> 8{Environment.NewLine}" +
                          $"silver -> 30";

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Mine_WithDifferentResources_ShouldReturnResourceCounts()
    {
        // Arrange
        string[] input = new string[] { "Diamond 7", "Gold 3", "GOLD 2", "Silver 10", "Copper 15", "SILveR 10" };

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("diamond -> 7");
        expected.AppendLine("gold -> 5");
        expected.AppendLine("silver -> 20");
        expected.AppendLine("copper -> 15");

        // Act
        string result = Miner.Mine(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
