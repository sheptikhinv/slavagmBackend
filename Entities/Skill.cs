using System.Text.Json.Serialization;

namespace slavagmBackend.Entities;

public class Skill : BaseEntity
{
    public required string Title { get; set; }
    public int Priority { get; set; }
    public List<SkillChild> SkillChildren { get; set; }
}

public class SkillChild : BaseEntity
{
    public required string Title { get; set; }
    public int Priority { get; set; }
    [JsonIgnore] public Skill Skill { get; set; }
    public int SkillId { get; set; }
}