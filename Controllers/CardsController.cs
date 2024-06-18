using Microsoft.AspNetCore.Mvc;
using slavagmBackend.Entities;
using slavagmBackend.Models;
using slavagmBackend.Services;

namespace slavagmBackend.Controllers;

[ApiController]
[Route("[controller]")]
public class CardsController : ControllerBase
{
    private readonly ICardRepository _cardRepository;

    public CardsController(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var response = await _cardRepository.GetAllAsync();
        return Ok(response);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCard([FromBody] CreateCard card)
    {
        var newCard = new Card
        {
            Description = card.Descrption,
            Link = card.Link,
            Title = card.Title
        };

        var response = await _cardRepository.AddAsync(newCard);
        return Ok(response);
    }

    [HttpDelete("delete/{id:int?}")]
    public async Task<IActionResult> DeleteCard([FromRoute] int id)
    {
        var card = await _cardRepository.GetByIdAsync(id);
        await _cardRepository.DeleteAsync(card);
        return Ok();
    }

    [HttpPut("edit")]
    public async Task<IActionResult> EditCard([FromBody] EditCard card)
    {
        var cardDb = await _cardRepository.GetByIdAsync(card.Id);
        cardDb.Title = card.Title;
        cardDb.Description = card.Descrption;
        cardDb.Link = card.Link;
        var response = await _cardRepository.UpdateAsync(cardDb);
        return Ok(response);
    }
}