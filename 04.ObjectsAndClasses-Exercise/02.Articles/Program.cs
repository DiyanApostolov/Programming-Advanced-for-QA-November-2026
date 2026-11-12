
string[] articleInfo = Console.ReadLine().Split(", ");

Article article = new Article(articleInfo[0], articleInfo[1], articleInfo[2]);

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] cmdArg = Console.ReadLine().Split(": ");
    string command = cmdArg[0];
    string argument = cmdArg[1];

    if (command == "Edit")
    {
        article.Edit(argument);
    }
    else if (command == "ChangeAuthor")
    {
        article.ChangeAuthor(argument);
    }
    else if (command == "Rename")
    {
        article.Rename(argument);
    }
}

Console.WriteLine(article.ToString());

class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }

    public string Title { get; private set; }

    public string Content { get; private set; }

    public string Author { get; private set; }

    public void Edit(string newContent)
    {
        Content = newContent;
    }

    public void ChangeAuthor(string newAuthor)
    {
        Author = newAuthor;
    }

    public void Rename(string newTitle)
    {
        Title = newTitle;
    }

    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}
