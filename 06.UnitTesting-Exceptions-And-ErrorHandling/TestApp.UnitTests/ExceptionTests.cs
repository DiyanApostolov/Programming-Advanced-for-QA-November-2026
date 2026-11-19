using NUnit.Framework;

using System;
using System.Collections.Generic;

namespace TestApp.UnitTests;

public class ExceptionTests
{
    private Exceptions _exceptions = null!;

    [SetUp]
    public void SetUp()
    {
        this._exceptions = new();
    }

    [Test]
    public void Test_Reverse_ValidString_ReturnsReversedString()
    {
        // Arrange
        string input = "Hello";
        string expected = "olleH";

        // Act
        string result = _exceptions.ArgumentNullReverse(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Reverse_NullString_ThrowsArgumentNullException()
    {
        // Arrange
        string input = null;

        // Act & Assert
        // OLD SYNTAX
        Assert.Throws<ArgumentNullException>(() => _exceptions.ArgumentNullReverse(input));

        // NEW SYNTAX
        Assert.That(() => _exceptions.ArgumentNullReverse(input), Throws.ArgumentNullException);
    }

    [Test]
    public void Test_CalculateDiscount_ValidInput_ReturnsDiscountedPrice()
    {
        // Arrrange
        decimal price = 200;
        decimal discount = 10;
        decimal expected = 180;

        // Act
        decimal result = _exceptions.ArgumentCalculateDiscount(price, discount);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_CalculateDiscount_NegativeDiscount_ThrowsArgumentException()
    {
        // Arrange
        decimal price = 200;
        decimal discount = -10;
        string exectedMessage = "Discount must be between 0 and 100. (Parameter 'discount')";

        // Act & Assert - NEW SYNTAX
        Assert.That(() => _exceptions.ArgumentCalculateDiscount(price, discount), Throws.ArgumentException);

        try
        {
            _exceptions.ArgumentCalculateDiscount(price, discount);
        }
        catch(ArgumentException ex)
        {
            Assert.That(ex.Message, Is.EqualTo(exectedMessage));
        }
    }

    [Test]
    public void Test_CalculateDiscount_DiscountOver100_ThrowsArgumentException()
    {
        // Arrange
        decimal price = 200.0m;
        decimal discount = 110.0m;
        string exectedMessage = "Discount must be between 0 and 100. (Parameter 'discount')";

        // Act & Assert - OLD SYNTAX
        ArgumentException ex = Assert.Throws<ArgumentException>(() => _exceptions.ArgumentCalculateDiscount(price, discount));

        Assert.That(ex.Message, Is.EqualTo(exectedMessage));
    }

    [Test]
    public void Test_GetElement_ValidIndex_ReturnsElement()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = 2;
        int expected = 30;

        // Act
        int result = _exceptions.IndexOutOfRangeGetElement(array, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElement_IndexLessThanZero_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = -2;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(array, index), Throws.TypeOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexEqualToArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = array.Length;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(array, index), Throws.TypeOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElement_IndexGreaterThanArrayLength_ThrowsIndexOutOfRangeException()
    {
        // Arrange
        int[] array = { 10, 20, 30, 40, 50 };
        int index = 10;

        // Act & Assert
        Assert.That(() => _exceptions.IndexOutOfRangeGetElement(array, index), Throws.TypeOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_PerformSecureOperation_UserLoggedIn_ReturnsUserLoggedInMessage()
    {
        // Arrange
        bool input = true;
        string expected = "User logged in.";

        // Act
        string result = _exceptions.InvalidOperationPerformSecureOperation(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_PerformSecureOperation_UserNotLoggedIn_ThrowsInvalidOperationException()
    {
        // Arrange
        bool input = false;

        // Act & Assert
        Assert.That(() => _exceptions.InvalidOperationPerformSecureOperation(input), Throws.TypeOf<InvalidOperationException>());
    }

    [Test]
    public void Test_ParseInt_ValidInput_ReturnsParsedInteger()
    {
        // Arrange
        string input = "42";
        int expected = 42;

        // Act
        int result = _exceptions.FormatExceptionParseInt(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase("5a")]
    [TestCase("5.5")]
    [TestCase("five")]
    public void Test_ParseInt_InvalidInput_ThrowsFormatException(string input)
    {
        // Arrange

        // Act & Assert
        Assert.That(() => _exceptions.FormatExceptionParseInt(input), Throws.TypeOf<FormatException>());
    }

    [Test]
    public void Test_FindValueByKey_KeyExistsInDictionary_ReturnsValue()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>();
        input.Add("one", 1);
        input.Add("two", 2);
        input.Add("three", 3);
        input.Add("four", 4);

        string key = "two";
        int expected = 2;

        // Act
        int result = _exceptions.KeyNotFoundFindValueByKey(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_FindValueByKey_KeyDoesNotExistInDictionary_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, int> input = new Dictionary<string, int>();
        input.Add("one", 1);
        input.Add("two", 2);
        input.Add("three", 3);
        input.Add("four", 4);

        string key = "five";

        // Act & Assert 
        Assert.That(() => _exceptions.KeyNotFoundFindValueByKey(input, key), Throws.TypeOf<KeyNotFoundException>());
    }

    [Test]
    public void Test_AddNumbers_NoOverflow_ReturnsSum()
    {
        // Arrange
        int x = 5;
        int y = 7;
        int expected = 12;

        // Act
        int result = _exceptions.OverflowAddNumbers(x, y);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddNumbers_PositiveOverflow_ThrowsOverflowException()
    {
        // Arrange
        int x = int.MaxValue;
        int y = 1;

        // Act & Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(x, y), Throws.TypeOf<OverflowException>());
    }

    [Test]
    public void Test_AddNumbers_NegativeOverflow_ThrowsOverflowException()
    {
        // Arrange
        int x = int.MinValue;
        int y = -1;

        // Act & Assert
        Assert.That(() => _exceptions.OverflowAddNumbers(x, y), Throws.TypeOf<OverflowException>());
    }

    [Test]
    public void Test_DivideNumbers_ValidDivision_ReturnsQuotient()
    {
        // Arrange
        int dividend = 13;
        int divisor = 4;
        int expected = 3;

        // Act
        int result = _exceptions.DivideByZeroDivideNumbers(dividend, divisor);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_DivideNumbers_DivideByZero_ThrowsDivideByZeroException()
    {
        // Arrange
        int dividend = 13;
        int divisor = 0;

        // Act & Assert
        Assert.That(() => _exceptions.DivideByZeroDivideNumbers(dividend, divisor), Throws.TypeOf<DivideByZeroException>());
    }

    [Test]
    public void Test_SumCollectionElements_ValidCollectionAndIndex_ReturnsSum()
    {
        // Arrange
        int[] input = { 1, 2, 3, 4, 5 };
        int index = 2;
        int expected = 15;

        // Act
        int result = _exceptions.SumCollectionElements(input, index);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_SumCollectionElements_NullCollection_ThrowsArgumentNullException()
    {
        // Arrange
        int[] input = null;
        int index = 2;

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(input, index), Throws.ArgumentNullException);
    }

    [TestCase(-5)]
    [TestCase(5)]
    [TestCase(10)]
    public void Test_SumCollectionElements_IndexOutOfRange_ThrowsIndexOutOfRangeException(int index)
    {
        // Arrange
        int[] input = { 1, 2, 3, 4, 5 };

        // Act & Assert
        Assert.That(() => _exceptions.SumCollectionElements(input, index), Throws.TypeOf<IndexOutOfRangeException>());
    }

    [Test]
    public void Test_GetElementAsNumber_ValidKey_ReturnsParsedNumber()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input.Add("one", "1");
        input.Add("two", "2");
        input.Add("three", "3");
        input.Add("four", "4");

        string key = "four";
        int expected = 4;

        // Act
        int result = _exceptions.GetElementAsNumber(input, key);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetElementAsNumber_KeyNotFound_ThrowsKeyNotFoundException()
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input.Add("one", "1");
        input.Add("two", "2");
        input.Add("three", "3");
        input.Add("four", "4");

        string key = "six";

        // Act & Assert
        Assert.That(() => _exceptions.GetElementAsNumber(input, key), Throws.TypeOf<KeyNotFoundException>());

    }

    [TestCase("one")]
    [TestCase("two")]
    [TestCase("three")]
    public void Test_GetElementAsNumber_InvalidFormat_ThrowsFormatException(string key)
    {
        // Arrange
        Dictionary<string, string> input = new Dictionary<string, string>();
        input.Add("one", "1a");
        input.Add("two", "2.2");
        input.Add("three", "tri");
        input.Add("four", "4");

        // Act & Assert
        Assert.That(() => _exceptions.GetElementAsNumber(input, key), Throws.TypeOf<FormatException>());
    }
}
