using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OrderCollectorAPI.Data;
using OrderCollectorAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace OrderCollectorAPI.Services
{
    public class UserService: IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly HttpContext _httpContext;
        private readonly BaseContext _context;

        public UserService(IConfiguration configuration, BaseContext context, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContext = httpContextAccessor.HttpContext;
            _context = context;
        }

        public async Task<string> Login(Login login)
        {
            var loginUser = await _context.users.Where(o => o.Email == login.email).Include(o => o.Login).FirstOrDefaultAsync();

            if (loginUser != null)
            {
                if (ValidatePasswordMatch(loginUser.Login, login.password))
                {
                    return generateJWTToken(loginUser);
                }
                
            }
            return null;
        }

        public string GetUserEmail()
        {
            return _httpContext.User.Claims.FirstOrDefault(o => o.Type == "email").Value;
        }

        public async Task<User> GetCurrentUser()
        {
            var email = GetUserEmail();
            return await _context.users.Where(o => o.Email == email).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateNewUser(Login login)
        {
            try
            {
                var newUser = new User();
                newUser.Name = login.email.Substring(0, login.email.IndexOf("@"));
                newUser.Email = login.email;
                newUser.Login = GenerateNewUserLogin(login.password);

                await _context.users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string generateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials);

            var encodedToken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodedToken;
        }

        private bool ValidatePasswordMatch(UserLogin user, string password)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(user.Salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed == user.EncryptedPassword;
        }

        private UserLogin GenerateNewUserLogin(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            var login = new UserLogin();
            login.Salt = Convert.ToBase64String(salt);
            login.EncryptedPassword = hashed;

            return login;

        }
    }
}
