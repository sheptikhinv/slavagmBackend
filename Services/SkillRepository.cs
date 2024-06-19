using Microsoft.EntityFrameworkCore;
using slavagmBackend.Entities;

namespace slavagmBackend.Services;

public class SkillRepository : ISkillRepository
{
    private readonly DataContext _context;

    public SkillRepository(DataContext context)
    {
        _context = context;
    }


    public async Task<Skill> GetSkillByIdAsync(int id)
    {
        return await _context.Skills.Include(skill => skill.SkillChildren).FirstOrDefaultAsync(x => x.Id == id) ??
               throw new InvalidOperationException();
    }

    public async Task<int> AddSkillAsync(Skill skill)
    {
        await _context.Skills.AddAsync(skill);
        await _context.SaveChangesAsync();
        return skill.Id;
    }

    public async Task<Skill> EditSkillAsync(Skill skill)
    {
        _context.Skills.Update(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task DeleteSkillAsync(Skill skill)
    {
        _context.Skills.Remove(skill);
        await _context.SaveChangesAsync();
    }

    public async Task<SkillChild> GetChildSkillByIdAsync(int id)
    {
        return await _context.ChildSkills.FirstOrDefaultAsync(x => x.Id == id) ?? throw new InvalidOperationException();
    }

    public async Task<int> AddChildSkillAsync(SkillChild skill)
    {
        await _context.ChildSkills.AddAsync(skill);
        await _context.SaveChangesAsync();
        return skill.Id;
    }

    public async Task<SkillChild> EditChildSkillAsync(SkillChild skill)
    {
        _context.ChildSkills.Update(skill);
        await _context.SaveChangesAsync();
        return skill;
    }

    public async Task DeleteChildSkillAsync(SkillChild skill)
    {
        _context.ChildSkills.Remove(skill);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Skill>> GetAllAsync()
    {
        return await _context.Skills.Include(skill => skill.SkillChildren).ToListAsync();
    }
}