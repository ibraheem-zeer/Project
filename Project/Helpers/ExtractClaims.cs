using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Project.Helpers
{
    public class ExtractClaims
    {
        public static int? ExtractUserId(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);
                var userIdClaim = jwtToken.Claims.FirstOrDefault(t=>t.Type == ClaimTypes.NameIdentifier);
                if(userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId)) return userId;
                return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
