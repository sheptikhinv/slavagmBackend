namespace slavagmBackend.Core.Models;

public class Skill
{
    public long Id { get; set; }
    
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? Link { get; set; }
}