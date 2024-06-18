using slavagmBackend.Entities;

namespace slavagmBackend.Services;

public interface ICardRepository
{
    public Task<List<Card>> GetAllAsync();
    public Task<Card> GetByIdAsync(int id);
    public Task<int> AddAsync(Card card);
    public Task<Card> UpdateAsync(Card card);
    public Task DeleteAsync(Card card);
}