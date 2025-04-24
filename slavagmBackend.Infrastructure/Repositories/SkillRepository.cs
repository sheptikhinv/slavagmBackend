using Microsoft.EntityFrameworkCore;
using slavagmBackend.Core.Models;
using slavagmBackend.Core.Repositories;
using slavagmBackend.Infrastructure.Data;
using slavagmBackend.Infrastructure.Extensions;

namespace slavagmBackend.Infrastructure.Repositories;

public class SkillRepository : ISkillRepository
{
    private readonly ApplicationDbContext _context;

    public SkillRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Skill>> GetAllAsync()
    {
        return await _context.Skills.Include(s => s.Children).ToListAsync();
    }

    public async Task<Skill?> GetByIdAsync(long id)
    {
        return await _context.Skills.Include(s => s.Children).FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task AddAsync(Skill entity)
    {
        await _context.Skills.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Skill entity)
    {
        _context.Skills.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Skill entity)
    {
        _context.Skills.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Skill>> GetTopLevelAsync()
    {
        var topLevelSkills = await _context.Skills.Where(skill => skill.Parent == null).ToListAsync();

        foreach (var skill in topLevelSkills)
        {
            await skill.LoadChildrenRecursively(_context);
        }

        return topLevelSkills;
    }
}