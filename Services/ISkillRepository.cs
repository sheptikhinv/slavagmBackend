using slavagmBackend.Entities;

namespace slavagmBackend.Services;

public interface ISkillRepository
{
    public Task<Skill> GetSkillByIdAsync(int id);
    public Task<int> AddSkillAsync(Skill skill);
    public Task<Skill> EditSkillAsync(Skill skill);
    public Task DeleteSkillAsync(Skill skill);
    public Task<SkillChild> GetChildSkillByIdAsync(int id);
    public Task<int> AddChildSkillAsync(SkillChild skill);
    public Task<SkillChild> EditChildSkillAsync(SkillChild skill);
    public Task DeleteChildSkillAsync(SkillChild skill);
    public Task<List<Skill>> GetAllAsync();
}