namespace slavagmBackend.Core.Models;

public class Card
{
    public long Id { get; set; }
    
    public required string Title { get; set; }
    public int Priority { get; set; }
    public Skill? Parent { get; set; }
    public ICollection<Skill> Children { get; set; } = new  List<Skill>();
}