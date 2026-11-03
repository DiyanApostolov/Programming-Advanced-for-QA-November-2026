
string[] inputArray = Console.ReadLine().Split(" ");

string output = "";

foreach (var word in inputArray)
{
    for (int i = 0; i < word.Length; i++)
    {
        output += word;
    }
}

Console.WriteLine(output);
