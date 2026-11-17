using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    // TODO: finish test
    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        string[] input = { "Article1 Content1 Author1", "Article2 Content2 Author2", "Article3 Content3 Author3" };

        Article expected = new Article();
        expected.ArticleList.Add(new Article
        {
            Title = "Article1",
            Content = "Content1",
            Author = "Author1"
        });

        expected.ArticleList.Add(new Article
        {
            Title = "Article2",
            Content = "Content2",
            Author = "Author2"
        });

        expected.ArticleList.Add(new Article
        {
            Title = "Article3",
            Content = "Content3",
            Author = "Author3"
        });

        // Act
        Article result = _article.AddArticles(input);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));

        for (int i = 0; i < result.ArticleList.Count; i++)
        {
            Assert.That(result.ArticleList[0].Title, Is.EqualTo(expected.ArticleList[0].Title));
            Assert.That(result.ArticleList[0].Content, Is.EqualTo(expected.ArticleList[0].Content));
            Assert.That(result.ArticleList[0].Author, Is.EqualTo(expected.ArticleList[0].Author));
        }
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        string[] input = { "BFS_Something Content1 Author1", "ElonMusk_SpaceX Content2 Author2", "Article3 Content3 Author3" };
        string criteia = "title";

        StringBuilder expected = new StringBuilder();
        expected.AppendLine("Article3 - Content3: Author3");
        expected.AppendLine("BFS_Something - Content1: Author1");
        expected.AppendLine("ElonMusk_SpaceX - Content2: Author2");

        // Act
        _article = _article.AddArticles(input);
        string result = _article.GetArticleList(_article, criteia);

        // Assert
        Assert.That(result, Is.EqualTo(expected.ToString().Trim()));
    }

    [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        string[] input = { "BFS_Something Content1 Author1", "ElonMusk_SpaceX Content2 Author2", "Article3 Content3 Author3" };
        string criteia = "invalidCriteria";

        // Act
        _article = _article.AddArticles(input);
        string result = _article.GetArticleList(_article, criteia);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
