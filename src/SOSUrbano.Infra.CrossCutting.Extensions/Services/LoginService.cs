using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SOSUrbano.Domain.Interfaces.Services.LoginRepository;



namespace SOSUrbano.Infra.Data.Configurations.LoginConfigurations
{
    public class LoginService(IConfiguration config) : IServiceLogin
    {

        private readonly IConfiguration _config = config;

        public string GenerateToken(Guid id, string email, string roleName)
        {
            /*
             Claims são informações que o token vai possuir. Elas ficam
            codificadas no corpo do token e ficam disponíveis para 
            utilizar caso seja necessário fazer uma consulta no banco
             */
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, roleName)
            };

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var cred = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha384);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(2),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
