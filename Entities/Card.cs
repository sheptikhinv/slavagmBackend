using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace slavagmBackend.Entities;

public class Card : BaseEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public string? Link { get; set; }
}