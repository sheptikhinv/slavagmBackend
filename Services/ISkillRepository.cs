using slavagmBackend.Entities;

namespace slavagmBackend.Services;

public interface ISkillRepository
{
    public Task<Skill> GetSkillByIdAsync(int id);
    public Task<int> AddSkillAsync(Skill skill);
    public Task<Skill> EditSkillAsync(Skill skill);
    public Task DeleteSkillAsync(Skill skill);
    public Task<List<Skill>> GetAllAsync();
    public Task<List<Skill>> GetTopLevelAsync();
}