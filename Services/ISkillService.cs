using slavagmBackend.Entities;
using slavagmBackend.Models;

namespace slavagmBackend.Services;

public interface ISkillService
{
    public Task<Skill> GetSkillByIdAsync(int id);
    public Task<int> AddSkillAsync(CreateSkill skill);
    public Task<Skill> EditSkillAsync(UpdateSkill skill);
    public Task DeleteSkillAsync(int id);
    public Task<SkillChild> GetChildSkillByIdAsync(int id);
    public Task<int> AddChildSkillAsync(AddChild skill);
    public Task<SkillChild> EditChildSkillAsync(UpdateChild skill);
    public Task DeleteChildSkillAsync(int id);
    public Task<List<Skill>> GetAllAsync();
}