using NUnit.Framework;

using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Tests;

public class CountCharactersTests
{
    [Test]
    public void Test_Count_WithEmptyList_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new();

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_Count_WithNoCharacters_ShouldReturnEmptyString()
    {
        // Arrange
        List<string> input = new List<string>() { "", "", "" };

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Count_WithSingleCharacter_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "a" };
        string expected = "a -> 1";

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Count_WithMultipleCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "Dido", "dad", "hi" };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("D -> 1");
        expected.AppendLine("i -> 2");
        expected.AppendLine("d -> 3");
        expected.AppendLine("o -> 1");
        expected.AppendLine("a -> 1");
        expected.AppendLine("h -> 1");

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_Count_WithSpecialCharacters_ShouldReturnCountString()
    {
        // Arrange
        List<string> input = new List<string>() { "D1do#", "#$_" };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("D -> 1");
        expected.AppendLine("1 -> 1");
        expected.AppendLine("d -> 1");
        expected.AppendLine("o -> 1");
        expected.AppendLine("# -> 2");
        expected.AppendLine("$ -> 1");
        expected.AppendLine("_ -> 1");

        // Act
        string result = CountCharacters.Count(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
