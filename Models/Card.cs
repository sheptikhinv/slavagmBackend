namespace slavagmBackend.Models;

public record CreateCard
{
    public required string Title { get; set; }
    public required string Descrption { get; set; }
    public string? Link { get; set; }
}

public record EditCard : CreateCard
{
    public required int Id { get; set; }
}