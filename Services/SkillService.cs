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
            Priority = skill.Priority
        };
        return await _skillRepository.AddSkillAsync(skillDb);
    }

    public async Task<Skill> EditSkillAsync(UpdateSkill skill)
    {
        var skillDb = new Skill
        {
            Id = skill.Id,
            Title = skill.Title,
            Priority = skill.Priority
        };
        return await _skillRepository.EditSkillAsync(skillDb);
    }

    public async Task DeleteSkillAsync(int id)
    {
        var skillDb = _skillRepository.GetSkillByIdAsync(id);
        await _skillRepository.DeleteSkillAsync(await skillDb);
    }

    public async Task<SkillChild> GetChildSkillByIdAsync(int id)
    {
        return await _skillRepository.GetChildSkillByIdAsync(id);
    }

    public async Task<int> AddChildSkillAsync(AddChild skill)
    {
        var parent = _skillRepository.GetSkillByIdAsync(skill.ParentId);
        var skillDb = new SkillChild
        {
            Skill = await parent,
            // ParentId = skill.ParentId,
            Title = skill.Title,
            Priority = skill.Priority
        };
        return await _skillRepository.AddChildSkillAsync(skillDb);
    }

    public async Task<SkillChild> EditChildSkillAsync(UpdateChild skill)
    {
        var parent = _skillRepository.GetSkillByIdAsync(skill.ParentId);
        var skillDb = new SkillChild
        {
            Id = skill.Id,
            Skill = await parent,
            Title = skill.Title,
            Priority = skill.Priority
        };
        return await _skillRepository.EditChildSkillAsync(skillDb);
    }

    public async Task DeleteChildSkillAsync(int id)
    {
        var skillDb = await _skillRepository.GetChildSkillByIdAsync(id);
        await _skillRepository.DeleteChildSkillAsync(skillDb);
    }

    public async Task<List<Skill>> GetAllAsync()
    {
        return await _skillRepository.GetAllAsync();
    }
}