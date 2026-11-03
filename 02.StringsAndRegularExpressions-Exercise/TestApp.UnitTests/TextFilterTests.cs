using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class TextFilterTests
{
    // TODO: finish the test
    [Test]
    public void Test_Filter_WhenNoBannedWords_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string[] { "aaa", "bbb", "ccc" };
        string text = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordExists_ShouldReplaceBannedWordWithAsterisks()
    {
        // Arrange
        string[] bannedWords = new string[] { "fox", "lazy" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick brown *** jumps over the **** dog";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsAreEmpty_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = Array.Empty<string>();
        string text = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(text));
    }

    [Test]
    public void Test_Filter_WhenBannedWordsContainWhitespace_ShouldReplaceBannedWord()
    {
        // Arrange
        string[] bannedWords = new string[] { "brown fox", "lazy dog" };
        string text = "The quick brown fox jumps over the lazy dog";
        string expected = "The quick ********* jumps over the ********";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    // BONUS TESTS - NOT FOR JUDGE
    [Test]
    public void Test_Filter_WhenBannedWordExistsAndTextIsEmpty_ShouldReturnEmptyString()
    {
        // Arrange
        string[] bannedWords = new string[] { "fox", "lazy" };
        string text = "";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Filter_WhenBannedWordsExistCaseSensitive_ShouldReturnOriginalText()
    {
        // Arrange
        string[] bannedWords = new string[] { "FOX", "Dog", "LaZy" };
        string text = "The quick brown fox jumps over the lazy dog";

        // Act
        string result = TextFilter.Filter(bannedWords, text);

        // Assert
        Assert.That(result, Is.EqualTo(text));
    }
}
