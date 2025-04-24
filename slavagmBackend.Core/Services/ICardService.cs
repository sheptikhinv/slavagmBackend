using slavagmBackend.Core.Models;

namespace slavagmBackend.Core.Services;

public interface ICardService
{
    public Task<Card> GetByIdAsync(long id);
    public Task<IEnumerable<Card>> GetAllAsync();
    public Task AddAsync(Card card);
    public Task UpdateAsync(Card card);
    public Task DeleteAsync(Card card);
}