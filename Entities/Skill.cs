using System.Text.Json.Serialization;

namespace slavagmBackend.Entities;

public class Skill : BaseEntity
{
    public required string Title { get; set; }
    public int Priority { get; set; }
    [JsonIgnore] 
    public Skill? Parent { get; set; }
    public List<Skill> Children { get; set; } = [];
}