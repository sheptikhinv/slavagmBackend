using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace slavagmBackend.Services;

public static class AuthOptions
{
    public static string AdminPassword;
    public static string Issuer;
    public static string Audience;
    public static TimeSpan TokenLifetime = TimeSpan.FromHours(6);
    private static string? SecurityKey { get; set; }

    public static SymmetricSecurityKey SymmetricSecurityKey
    {
        get
        {
            ArgumentNullException.ThrowIfNull(SecurityKey);

            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecurityKey));
        }
    }

    public static void MakeOptions(ConfigurationManager configuration)
    {
        AdminPassword = configuration["AdminPassword"] ?? "Default";
        Issuer = configuration["Issuer"] ?? "Default";
        Audience = configuration["Audience"] ?? "Default";
        SecurityKey = configuration["SecurityKey"] ?? "Default";
    }
}