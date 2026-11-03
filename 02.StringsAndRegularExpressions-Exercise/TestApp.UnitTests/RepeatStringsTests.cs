using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class RepeatStringsTests
{
    [Test]
    public void Test_Repeat_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] input = Array.Empty<string>();

        // Act
        string result = RepeatStrings.Repeat(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Repeat_SingleInputString_ReturnsRepeatedString()
    {
        // Arrange
        string[] words = new string[] { "Dido" };
        string expected = "DidoDidoDidoDido";

        // Act
        string result = RepeatStrings.Repeat(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Repeat_MultipleInputStrings_ReturnsConcatenatedRepeatedStrings()
    {
        // Arrange
        string[] words = new string[] { "Dido", "abc", "Honda" };
        string expected = "DidoDidoDidoDidoabcabcabcHondaHondaHondaHondaHonda";

        // Act
        string result = RepeatStrings.Repeat(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
