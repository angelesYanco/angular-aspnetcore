using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using NetKubernetes.Models;

namespace NetKubernetes.Token
{
    public class JwTGenerator : IJwtGenerator
    {

        public string CreateToken(Usuario usuario)
        {
            var claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.NameId, usuario.UserName!),
                new Claim("userId", usuario.Id),
                new Claim("email", usuario.Email!)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("super clave de seguridad"));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = credentials
             };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}