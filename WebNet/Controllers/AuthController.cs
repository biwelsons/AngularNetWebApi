using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebNet.Models;
using WebNet.DTOs;
using System.Text.RegularExpressions;

namespace WebNet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            if (!Regex.IsMatch(loginDto.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return Unauthorized(new { message = "Digite um e-mail válido." });
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            
            // 🔹 Se o e-mail não existir
            if (user == null)
            {
                return Unauthorized(new { message = "Conta não encontrada. Crie uma conta" });
            }

            // 🔹 Se a conta estiver bloqueada
            if (await _userManager.IsLockedOutAsync(user))
            {
                return Unauthorized(new { message = "Conta bloqueada por tentativas excessivas. Aguarde ou redefina sua senha." });
            }

            // 🔹 Se a senha estiver incorreta
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!result.Succeeded)
            {
                return Unauthorized(new { message = "E-mail ou senha incorretos." });
            }

            // 🔹 Se tudo estiver correto, gera o token JWT
            var token = GenerateJwtToken(user);
            return Ok(new { token });
}


        private string GenerateJwtToken(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email ?? string.Empty),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, user.Role ?? string.Empty)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
