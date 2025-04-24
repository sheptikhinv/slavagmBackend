namespace slavagmBackend.API.DTOs.Skills;

public class UpdateSkillDto
{
    public required string Title { get; set; }
    public int Priority { get; set; }
    public long? ParentId { get; set; }
}