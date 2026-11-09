using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.Tests;

public class PlantsTests
{
    [Test]
    public void Test_GetFastestGrowing_WithEmptyArray_ShouldReturnEmptyString()
    {
        // Arrange
        string[] plants = Array.Empty<string>();

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // TODO: finish test
    [Test]
    public void Test_GetFastestGrowing_WithSinglePlant_ShouldReturnPlant()
    {
        // Arrange
        string[] plants = new string[] { "tulip" };
        string expected = "Plants with 5 letters:" + Environment.NewLine
                          + "tulip";

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMultiplePlants_ShouldReturnGroupedPlants()
    {
        // Arrange
        string[] plants = new string[] { "daliah", "tulip", "rose", "daisy", "lotos", "iris", "lily" };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Plants with 4 letters:");
        expected.AppendLine("rose");
        expected.AppendLine("iris");
        expected.AppendLine("lily");
        expected.AppendLine("Plants with 5 letters:");
        expected.AppendLine("tulip");
        expected.AppendLine("daisy");
        expected.AppendLine("lotos");
        expected.AppendLine("Plants with 6 letters:");
        expected.AppendLine("daliah");

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_GetFastestGrowing_WithMixedCasePlants_ShouldBeCaseSensitive()
    {
        // Arrange
        string[] plants = new string[] { "daliah", "tulip", "rose", "Tulip", "lotos", "ROSE", "lily" };
        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Plants with 4 letters:");
        expected.AppendLine("rose");
        expected.AppendLine("ROSE");
        expected.AppendLine("lily");
        expected.AppendLine("Plants with 5 letters:");
        expected.AppendLine("tulip");
        expected.AppendLine("Tulip");
        expected.AppendLine("lotos");
        expected.AppendLine("Plants with 6 letters:");
        expected.AppendLine("daliah");

        // Act
        string result = Plants.GetFastestGrowing(plants);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }
}
