using slavagmBackend.Core.Models;
using slavagmBackend.Core.Repositories;
using slavagmBackend.Core.Services;
using slavagmBackend.Services.Exceptions;

namespace slavagmBackend.Services.Services;

public class SkillService(ISkillRepository skillRepository) : ISkillService
{
    private readonly ISkillRepository _skillRepository = skillRepository;

    public async Task<Skill> GetByIdAsync(long id)
    {
        var result = await _skillRepository.GetByIdAsync(id);
        if (result is null)
        {
            throw new NotFoundException("Skill not found");
        }
        
        return result;
    }

    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        return await  _skillRepository.GetAllAsync();
    }

    public async Task AddAsync(Skill skill)
    {
        await _skillRepository.AddAsync(skill);
    }

    public async Task UpdateAsync(Skill skill)
    {
        await _skillRepository.UpdateAsync(skill);
    }

    public async Task DeleteAsync(Skill skill)
    {
        await _skillRepository.DeleteAsync(skill);
    }

    public async Task<IEnumerable<Skill>> GetTopLevelAsync()
    {
        return await _skillRepository.GetTopLevelAsync();
    }
}