namespace slavagmBackend.API.DTOs.Skills;

public class CreateSkillDto
{
    public required string Title { get; set; }
    public int Priority { get; set; }
    public long? ParentId { get; set; }
}