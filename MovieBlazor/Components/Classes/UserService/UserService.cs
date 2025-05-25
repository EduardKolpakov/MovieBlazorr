using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MovieBlazor.Components.Classes
{
    public class UserService : IUserService
    {
        private readonly UserContext _userContext = new();

        public UserContext CurrentUser => _userContext;

        public void UpdateFromJwt(string jwt)
        {
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(jwt);

            var claims = token.Claims;
            _userContext.name = claims.FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value
                ?? claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value
                ?? "Unknown";

            var idStr = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            _userContext.iD_User = int.TryParse(idStr, out var id) ? id : -1;

            _userContext.description = claims.FirstOrDefault(c => c.Type == "Description")?.Value ?? "";

            var roleIdStr = claims.FirstOrDefault(c => c.Type == "ID_Role")?.Value;
            _userContext.iD_Role = int.TryParse(roleIdStr, out var roleId) ? roleId : -1;
        }
    }
}
