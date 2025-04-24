using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using slavagmBackend.API.DTOs.Cards;
using slavagmBackend.API.Mappers;
using slavagmBackend.Core.Services;

namespace slavagmBackend.API.Controllers;

[ApiController]
[Route("api/cards")]
public class CardsController(ICardService cardService) : ControllerBase
{
    private readonly ICardService _cardService = cardService;

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(typeof(List<OutputCardDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllCards()
    {
        var cards = await _cardService.GetAllAsync();
        var result = cards.Select(CardMapper.ModelToOutputCard);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(OutputCardDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCardById(long id)
    {
        var card = await _cardService.GetByIdAsync(id);
        var result = CardMapper.ModelToOutputCard(card);
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddCard([FromBody] CreateCardDto cardDto)
    {
        var card = CardMapper.CreateCardToModel(cardDto);
        await _cardService.AddAsync(card);
        return Ok(card);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCard(long id, [FromBody] UpdateCardDto cardDto)
    {
        var card = CardMapper.UpdateCardToModel(id, cardDto);
        await _cardService.UpdateAsync(card);
        return Ok(card);
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCard(long id)
    {
        await _cardService.DeleteAsync(id);
        return Ok();
    }
}