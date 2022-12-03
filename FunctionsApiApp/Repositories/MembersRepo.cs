namespace ExampleApi.Repositories;

public class MembersRepo
{
    public Member[] GetMembers() => new Member[]
    {
        new("Wong", true),
        new("Dr.Stephen Strange", false),
        new("the Ancient One", false),
        new("Karl Mordo", false),
        new("Baron Mordo", false),
        new("Kaecilius", false),
        new("Jonathan Pangborn", false),
        new("Daniel Drumm", false),
        new("Hamir", false),
        new("Tina Minoru", false),
        new("Sol Rama", false),
        new("Rintrah", false),
    };
}

public record Member(string Name, bool IsSourcererSupreme, string Universe="Azure Functions");
