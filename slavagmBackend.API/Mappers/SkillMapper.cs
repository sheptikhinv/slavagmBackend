using slavagmBackend.API.DTOs.Skills;
using slavagmBackend.Core.Models;

namespace slavagmBackend.API.Mappers;

public static class SkillMapper
{
    public static Skill CreateSkillToModel(CreateSkillDto dto) => new Skill
    {
        Title = dto.Title,
        Priority = dto.Priority,
        ParentId = dto.ParentId,
    };

    public static Skill UpdateSkillToModel(long id, UpdateSkillDto dto) => new Skill
    {
        Id = id,
        Title = dto.Title,
        Priority = dto.Priority,
        ParentId = dto.ParentId,
    };

    public static OutputSkillDto ModelToOutputSkill(Skill skill)
    {
        return new OutputSkillDto
        {
            Id = skill.Id,
            Title = skill.Title,
            Priority = skill.Priority,
            Children = skill.Children?.Select(ModelToOutputSkill).ToList()
        };
    }
}