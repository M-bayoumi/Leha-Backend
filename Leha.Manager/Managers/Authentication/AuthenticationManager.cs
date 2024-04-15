using Leha.Data.Entities.Identity;
using Leha.Data.Helper;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Leha.Manager.Managers.Authentication;

public class AuthenticationManager : IAuthenticationManager
{
    #region Fields
    private readonly JwtSettings _jwtSettings;

    #endregion

    #region Constructors
    public AuthenticationManager(JwtSettings jwtSettings)
    {
        _jwtSettings = jwtSettings;
    }
    #endregion

    #region Handle Functions
    public string GenerateJwtToken(AppUser user)
    {

        var signingCredentials = new SigningCredentials(
          new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
          SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user?.FullName),
            new Claim(ClaimTypes.NameIdentifier, user?.UserName),
            new Claim(ClaimTypes.Email, user?.Email),
            new Claim(ClaimTypes.Role, user?.Role),
        };

        var securityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issure,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddDays(_jwtSettings.ExpiryDays),
            claims: claims,
            signingCredentials: signingCredentials);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
    #endregion
}
