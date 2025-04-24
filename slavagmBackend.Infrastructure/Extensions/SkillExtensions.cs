using Microsoft.EntityFrameworkCore;
using slavagmBackend.Core.Models;
using slavagmBackend.Infrastructure.Data;

namespace slavagmBackend.Infrastructure.Extensions;

public static class SkillExtensions
{
    public static async Task LoadChildrenRecursively(this Skill skill, ApplicationDbContext context)
    {
        skill.Children = await context.Skills.Where(child => child.Parent == skill).ToListAsync();

        foreach (var child in skill.Children)
        {
            await LoadChildrenRecursively(child, context);
        }
    }
}