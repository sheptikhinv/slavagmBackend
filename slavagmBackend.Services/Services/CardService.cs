using slavagmBackend.Core.Models;
using slavagmBackend.Core.Repositories;
using slavagmBackend.Core.Services;
using slavagmBackend.Services.Exceptions;

namespace slavagmBackend.Services.Services;

public class CardService(ICardRepository cardRepository) : ICardService
{
    private readonly ICardRepository _cardRepository = cardRepository;

    public async Task<Card> GetByIdAsync(long id)
    {
        var result = await _cardRepository.GetByIdAsync(id);
        if (result is null)
        {
            throw new NotFoundException("Card not found");
        }

        return result;
    }

    public async Task<IEnumerable<Card>> GetAllAsync()
    {
        return await _cardRepository.GetAllAsync();
    }

    public async Task AddAsync(Card card)
    {
        await _cardRepository.AddAsync(card);
    }

    public async Task UpdateAsync(Card card)
    {
        await _cardRepository.UpdateAsync(card);
    }

    public async Task DeleteAsync(Card card)
    {
        await _cardRepository.DeleteAsync(card);
    }
}