namespace slavagmBackend.Models;

public record Auth
{
    public string Password { get; set; }
}

public record TokenResponse
{
    public string AccessToken { get; set; }
}