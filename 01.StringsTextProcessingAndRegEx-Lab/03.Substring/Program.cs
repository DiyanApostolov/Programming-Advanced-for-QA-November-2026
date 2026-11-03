
string word = Console.ReadLine();
string sentence = Console.ReadLine();

while (sentence.Contains(word))
{
    int startIndex = sentence.IndexOf(word);
    sentence = sentence.Remove(startIndex, word.Length);
}

Console.WriteLine(sentence);
