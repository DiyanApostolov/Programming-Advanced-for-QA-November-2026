using NUnit.Framework;

namespace TestApp.UnitTests;

public class EmailValidatorTests
{
    // TODO: finish the test
    [TestCase("dido@abv.bg")]
    [TestCase("Pesho-picha@gmail.com")]
    [TestCase("gosho.ot.pochivka03@yahoo.co.uk")]
    public void Test_ValidEmails_ReturnsTrue(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);

        // Assert
        Assert.That(result, Is.True);
    }

    // TODO: finish the test
    [TestCase("@abv.bg")]
    [TestCase("Pesho$#@gmail.com")]
    [TestCase("gosho03@yahoo")]
    [TestCase("gosho03yahoo.com")]
    public void Test_InvalidEmails_ReturnsFalse(string email)
    {
        // Arrange

        // Act
        bool result = EmailValidator.IsValidEmail(email);
        
        // Assert
        Assert.That(result, Is.False);
    }
}
