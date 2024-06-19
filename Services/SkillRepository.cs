using Microsoft.EntityFrameworkCore;
using slavagmBackend.Entities;
using slavagmBackend.Extensions;

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
        return await _context.Skills.Include(skill => skill.Children).FirstOrDefaultAsync(x => x.Id == id) ??
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

    public async Task<List<Skill>> GetAllAsync()
    {
        return await _context.Skills.Include(skill => skill.Children).ToListAsync();
    }

    public async Task<List<Skill>> GetTopLevelAsync()
    {
        var topLevelSkills = await _context.Skills.Where(skill => skill.Parent == null)
            .ToListAsync();

        foreach (var skill in topLevelSkills)
        {
            await skill.LoadChildrenRecursively(_context);
        }

        return topLevelSkills;
    }
}   