string input = Console.ReadLine();

string letters = "";
string digits = "";
string specialCharacters = "";

//Agd#53Dfg^&4F53

foreach (char currentSymbol in input)
{
    if (char.IsLetter(currentSymbol))
    {
        letters += currentSymbol;
    }
    else if (char.IsDigit(currentSymbol))
    {
        digits += currentSymbol;
    }
    else
    {
        specialCharacters += currentSymbol;
    }
}

Console.WriteLine(digits);
Console.WriteLine(letters);
Console.WriteLine(specialCharacters);

