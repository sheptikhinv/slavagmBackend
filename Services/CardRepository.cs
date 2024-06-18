using Microsoft.EntityFrameworkCore;
using slavagmBackend.Entities;

namespace slavagmBackend.Services;

public class CardRepository : ICardRepository
{
    private readonly DataContext _context;

    public CardRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<Card?>> GetAllAsync()
    {
        return await _context.Cards.ToListAsync();
    }

    public async Task<Card?> GetByIdAsync(int id)
    {
        return await _context.Cards.FirstOrDefaultAsync(card => card != null && card.Id == id);
    }

    public async Task<int> AddAsync(Card card)
    {
        await _context.Cards.AddAsync(card);
        await _context.SaveChangesAsync();
        return card.Id;
    }

    public async Task<Card> UpdateAsync(Card card)
    {
        _context.Cards.Update(card);
        await _context.SaveChangesAsync();
        return card;
    }

    public async Task DeleteAsync(Card card)
    {
        _context.Cards.Remove(card);
        await _context.SaveChangesAsync();
    }
}