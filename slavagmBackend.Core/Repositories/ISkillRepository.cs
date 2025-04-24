using slavagmBackend.Core.Models;

namespace slavagmBackend.Core.Repositories;

public interface ISkillRepository : IGenericRepository<Skill>
{
    public Task<IEnumerable<Skill>> GetTopLevelAsync();
}