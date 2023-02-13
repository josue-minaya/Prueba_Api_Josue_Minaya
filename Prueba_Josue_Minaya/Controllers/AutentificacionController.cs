using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Prueba_Josue_Minaya.DB.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Prueba_Josue_Minaya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AutentificacionController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AutentificacionController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
	    public async Task<IActionResult> Login(Usuario usu)
        {
            var usuario = "jminaya";
            var password = "12345";

            if (usuario==usu.IdUsuario && password == usu.Contrasena)
            {
                var secretkey = _configuration.GetValue<string>("SecretKey");
                var key = Encoding.ASCII.GetBytes(secretkey);
                var claims = new ClaimsIdentity();
                claims.AddClaim(new Claim(ClaimTypes.NameIdentifier, usu.IdUsuario));

                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = claims,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var createdToken= tokenHandler.CreateToken(tokenDescription);

                string bearer=tokenHandler.WriteToken(createdToken);
                return Ok(bearer);

            }
            else
            {
                return BadRequest("Usuario y/o contraseña incorrecta");
            }
        }
    }
}
