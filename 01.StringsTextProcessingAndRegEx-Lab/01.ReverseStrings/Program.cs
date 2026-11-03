
string input = Console.ReadLine();

while(input != "end")
{
    char[] wordInChars = input.ToCharArray();

    wordInChars = wordInChars.Reverse().ToArray();

    string reversedWord = string.Join("", wordInChars);

    Console.WriteLine(string.Join(" = ", input, reversedWord));

    input = Console.ReadLine();
}
