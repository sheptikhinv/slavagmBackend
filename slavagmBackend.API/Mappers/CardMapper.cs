using slavagmBackend.API.DTOs.Cards;
using slavagmBackend.Core.Models;

namespace slavagmBackend.API.Mappers;

public static class CardMapper
{
    public static Card CreateCardToModel(CreateCardDto dto) => new Card
    {
        Title = dto.Title,
        Description = dto.Description,
        Link = dto.Link,
    };

    public static Card UpdateCardToModel(long id, UpdateCardDto dto) => new Card
    {
        Id = id,
        Title = dto.Title,
        Description = dto.Description,
        Link = dto.Link,
    };

    public static OutputCardDto ModelToOutputCard(Card card) => new OutputCardDto
    {
        Id = card.Id,
        Title = card.Title,
        Description = card.Description,
        Link = card.Link,
    };
}