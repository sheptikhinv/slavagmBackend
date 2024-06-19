using Microsoft.EntityFrameworkCore;
using slavagmBackend.Entities;

namespace slavagmBackend.Extensions;

public static class SkillExtensions
{
    public static async Task LoadChildrenRecursively(this Skill skill, DataContext context)
    {
        skill.Children = await context.Skills.Where(child => child.Parent == skill).ToListAsync();

        foreach (var child in skill.Children)
        {
            await LoadChildrenRecursively(child, context);
        }
    }
}