namespace slavagmBackend.Models;

public record CreateSkill
{
    public required string Title { get; set; }
    public int Priority { get; set; } = 0;
    public int ParentId { get; set; } = 0;
}

public record UpdateSkill : CreateSkill
{
    public int Id { get; set; }
}