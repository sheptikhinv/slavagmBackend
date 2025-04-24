namespace slavagmBackend.API.DTOs.Skills;

public class OutputSkillDto
{
    public long Id { get; set; }
    public required string Title { get; set; }
    public int Priority { get; set; }
    public ICollection<OutputSkillDto>? Children { get; set; }
}