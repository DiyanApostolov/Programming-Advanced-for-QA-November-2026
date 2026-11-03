using NUnit.Framework;

using System;
using System.Linq;
using System.Text;

namespace TestApp.UnitTests;

public class ReverseConcatenateTests
{
    // TODO: finish the test
    [Test]
    public void Test_ReverseAndConcatenateStrings_EmptyInput_ReturnsEmptyString()
    {
        // Arrange
        string[] words = Array.Empty<string>();

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(words);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish the test
    [Test]
    public void Test_ReverseAndConcatenateStrings_SingleString_ReturnsSameString()
    {
        // Arrange
        string[] words = new string[] { "Hello" };
        string expected = "Hello";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_MultipleStrings_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] words = new string[] { "Pesho", "Mr.", "Hello" };
        string expected = "HelloMr.Pesho";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_NullInput_ReturnsEmptyString()
    {
        // Arrange
        string[] words = null;

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(words);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_WhitespaceInput_ReturnsConcatenatedString()
    {
        // Arrange
        string[] words = new string[] { "!", "Pesho", " ", "Mr.", " ", "Hello" };
        string expected = "Hello Mr. Pesho!";

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_ReverseAndConcatenateStrings_LargeInput_ReturnsReversedConcatenatedString()
    {
        // Arrange
        string[] words = new string[100000];

        for (int i = 0; i < 100000; i++)
        {
            words[i] = i.ToString();
        }

        StringBuilder expected = new StringBuilder();
        //string expected = ""; !!!too slow with sting!!!

        for (int i = 99999; i >= 0; i--)
        {
            expected.Append(i.ToString()); // much faster with StringBuilder

            //expected += i.ToString(); !!!too slow with sting!!!
        }

        // Act
        string result = ReverseConcatenate.ReverseAndConcatenateStrings(words);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString()));  
    }
}
