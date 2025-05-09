namespace slavagmBackend.Core.Models;

public class Skill
{
    public long Id { get; set; }

    public required string Title { get; set; }
    public int Priority { get; set; }

    public long? ParentId { get; set; }
    public Skill? Parent { get; set; }
    public ICollection<Skill> Children { get; set; } = new List<Skill>();
}