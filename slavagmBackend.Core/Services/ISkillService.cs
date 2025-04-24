using slavagmBackend.Core.Models;

namespace slavagmBackend.Core.Services;

public interface ISkillService
{
    public Task<Skill> GetByIdAsync(long id);
    public Task<IEnumerable<Skill>> GetAllAsync();
    public Task AddAsync(Skill skill);
    public Task UpdateAsync(Skill skill);
    public Task DeleteAsync(long id);
    public Task<IEnumerable<Skill>> GetTopLevelAsync();
}