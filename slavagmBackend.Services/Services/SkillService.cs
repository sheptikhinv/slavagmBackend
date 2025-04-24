using slavagmBackend.Core.Models;
using slavagmBackend.Core.Repositories;
using slavagmBackend.Core.Services;

namespace slavagmBackend.Services.Services;

public class SkillService(ISkillRepository skillRepository) : ISkillService
{
    private readonly ISkillRepository _skillRepository = skillRepository;

    public async Task<Skill> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task AddAsync(Skill skill)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Skill skill)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Skill>> GetTopLevelAsync()
    {
        throw new NotImplementedException();
    }
}