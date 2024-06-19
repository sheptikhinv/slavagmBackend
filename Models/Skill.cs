namespace slavagmBackend.Models;

public record CreateSkill
{
    public required string Title { get; set; }
    public int Priority { get; set; } = 0;
}

public record UpdateSkill : CreateSkill
{
    public int Id { get; set; }
}

public record AddChild
{
    public required int ParentId { get; set; }
    public required string Title { get; set; }
    public int Priority { get; set; } = 0;
}

public record UpdateChild : AddChild
{
    public int Id { get; set; }
}