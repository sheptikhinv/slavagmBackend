using slavagmBackend.Entities;
using slavagmBackend.Models;

namespace slavagmBackend.Services;

public class SkillService : ISkillService
{
    private readonly ISkillRepository _skillRepository;

    public SkillService(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }


    public async Task<Skill> GetSkillByIdAsync(int id)
    {
        return await _skillRepository.GetSkillByIdAsync(id);
    }

    public async Task<int> AddSkillAsync(CreateSkill skill)
    {
        var skillDb = new Skill
        {
            Title = skill.Title,
            Priority = skill.Priority,
            Parent = skill.ParentId == 0 ? null : await GetSkillByIdAsync(skill.ParentId)
        };
        return await _skillRepository.AddSkillAsync(skillDb);
    }

    public async Task<Skill> EditSkillAsync(UpdateSkill skill)
    {
        var skillDb = new Skill
        {
            Id = skill.Id,
            Title = skill.Title,
            Priority = skill.Priority,
            Parent = skill.ParentId == 0 ? null : await GetSkillByIdAsync(skill.ParentId)
        };
        return await _skillRepository.EditSkillAsync(skillDb);
    }

    public async Task DeleteSkillAsync(int id)
    {
        var skillDb = _skillRepository.GetSkillByIdAsync(id);
        await _skillRepository.DeleteSkillAsync(await skillDb);
    }

    public async Task<List<Skill>> GetAllAsync()
    {
        return await _skillRepository.GetAllAsync();
    }

    public async Task<List<Skill>> GetTopLevelAsync()
    {
        return await _skillRepository.GetTopLevelAsync();
    }
}