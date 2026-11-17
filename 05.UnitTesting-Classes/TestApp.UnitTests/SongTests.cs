using NUnit.Framework;

using System;

namespace TestApp.UnitTests;

public class SongTests
{
    private Song _song;

    [SetUp]
    public void Setup()
    {
        _song = new();
    }

    // TODO: finish test
    [Test]
    public void Test_AddAndListSongs_ReturnsAllSongs_WhenWantedListIsAll()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Jazz_Song3_3:00" };
        string typeList = "all";

        string expected = $"Song1{Environment.NewLine}" +
                          $"Song2{Environment.NewLine}" +
                          $"Song3";

        // Act
        string result = _song.AddAndListSongs(songs, typeList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsFilteredSongs_WhenWantedListIsSpecific()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Jazz_Song3_3:00", "Rock_Song4_6:15" };
        string typeList = "Rock";

        string expected = $"Song2{Environment.NewLine}" +
                          $"Song4";

        // Act
        string result = _song.AddAndListSongs(songs, typeList);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenNoSongsMatchWantedList()
    {
        // Arrange
        string[] songs = { "Pop_Song1_3:30", "Rock_Song2_4:15", "Jazz_Song3_3:00", "Rock_Song4_6:15" };
        string typeList = "Chalga";

        // Act
        string result = _song.AddAndListSongs(songs, typeList);

        // Assert
        Assert.That(result, Is.Empty);
    }

    // BONUS TEST
    [Test]
    public void Test_AddAndListSongs_ReturnsEmptyString_WhenArrayOfSongsIsEmpty()
    {
        // Arrange
        string[] songs = Array.Empty<string>();
        string typeList = "Pop";

        // Act
        string result = _song.AddAndListSongs(songs, typeList);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
