using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Users.API.Mock.Shared.Services.Authentication
{
    /// <inheritdoc/>
    public class JwtAuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="_encryptionKey">Private key used for encryption of the token.</param>
        public JwtAuthenticationService(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
        }

        /// <inheritdoc/>
        public async Task<string> AuthenticateUserGetToken(string username, string password)
        {
            // HACK simulate data fetch
            await Task.Delay(300);

            if (!_Users.Any(u => u.Key == username && u.Value == password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_encryptionKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials
                (
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var jwtToken = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(jwtToken);
        }

        #region Fields
        private readonly string _encryptionKey;

        // HACK move to database
        private readonly Dictionary<string, string> _Users =
            new()
            {
                { "admin", "admin" },
                { "dev1", "dev1" },
                { "dev2", "dev2" }
            };
        #endregion
    }
}
