
List<Team> premierLeague = new List<Team>();

int n = int.Parse(Console.ReadLine());

for (int i = 0; i < n; i++)
{
    string[] teamInfo = Console.ReadLine().Split('-');
    string creator = teamInfo[0];
    string teamName = teamInfo[1];

    if (premierLeague.Any(t => t.Name == teamName))
    {
        Console.WriteLine($"Team {teamName} was already created!");
    }
    else if (premierLeague.Any(t => t.Creator == creator))
    {
        Console.WriteLine($"{creator} cannot create another team!");
    }
    else
    {
        Team currentTeam = new Team(teamName, creator);
        premierLeague.Add(currentTeam);

        Console.WriteLine($"Team {teamName} has been created by {creator}!");
    }
}

while (true)
{
    string[] input = Console.ReadLine().Split("->");

    if (input[0] == "end of assignment")
        break;

    string user = input[0];
    string teamName = input[1];

    if (!premierLeague.Any(t => t.Name == teamName))
    {
        Console.WriteLine($"Team {teamName} does not exist!");
    }
    else if (premierLeague.Any(t => t.Members.Contains(user) || t.Creator == user))
    {
        Console.WriteLine($"Member {user} cannot join team {teamName}!");
    }
    else
    {
        // take team bt refference
        Team currentTeam = premierLeague.First(t => t.Name == teamName);

        // add user by refference
        currentTeam.Members.Add(user); 
    }
}

foreach (Team team in premierLeague
                            .Where(t => t.Members.Count > 0)
                            .OrderByDescending(t => t.Members.Count)
                            .ThenBy(t => t.Name))
{
    Console.WriteLine(team.Name);
    Console.WriteLine($"- {team.Creator}");

    foreach (var member in team.Members.OrderBy(m => m))
    {
        Console.WriteLine($"-- {member}");
    }
}

Console.WriteLine("Teams to disband:");

foreach (Team team in premierLeague
                            .Where(t => t.Members.Count == 0)
                            .OrderBy(t => t.Name))
{
    Console.WriteLine(team.Name);
}

class Team
{
    public Team(string teamName, string creator)
    {
        Name = teamName;
        Creator = creator;
        Members = new List<string>();
    }

    public string Name { get; set; }

    public string Creator { get; set; }

    public List<string> Members { get; set; } 
}