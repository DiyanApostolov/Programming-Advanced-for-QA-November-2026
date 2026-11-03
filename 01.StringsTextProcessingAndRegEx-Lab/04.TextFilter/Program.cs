
string[] bannedWords = Console.ReadLine().Split(", ");

string text = Console.ReadLine();

foreach (var word in bannedWords)
{
    string asterisks = new string('*', word.Length);

    text = text.Replace(word, asterisks);
}

Console.WriteLine(text);
