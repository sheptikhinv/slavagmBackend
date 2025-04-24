namespace slavagmBackend.API.DTOs.Cards;

public class CreateCardDto
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? Link { get; set; }
}