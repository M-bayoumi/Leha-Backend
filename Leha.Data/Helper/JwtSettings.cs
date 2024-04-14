namespace Leha.Data.Helper;

public class JwtSettings
{
    public string Secret { get; set; } = null!;
    public string Issure { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int ExpiryDays { get; set; }
    public bool ValidateLifeTime { get; set; }
    public bool ValidateIssure { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateIssureSigningKey { get; set; }
    public bool ValidateLifetime { get; set; }

}
