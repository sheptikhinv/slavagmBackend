using Microsoft.EntityFrameworkCore;
using slavagmBackend.Core.Models;
using slavagmBackend.Core.Repositories;
using slavagmBackend.Infrastructure.Data;

namespace slavagmBackend.Infrastructure.Repositories;

public class CardRepository(ApplicationDbContext context) : ICardRepository
{
    public async Task<IEnumerable<Card>> GetAllAsync()
    {
        return await context.Cards.ToListAsync();
    }

    public async Task<Card?> GetByIdAsync(long id)
    {
        return await context.Cards.FindAsync(id);
    }

    public async Task AddAsync(Card entity)
    {
        await context.Cards.AddAsync(entity);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Card entity)
    {
        context.Cards.Update(entity);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Card entity)
    {
        context.Cards.Remove(entity);
        await context.SaveChangesAsync();
    }
}