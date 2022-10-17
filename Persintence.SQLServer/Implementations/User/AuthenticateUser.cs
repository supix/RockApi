using System;
using DomainModel.Services.User;
using DomainModel.Services;
using Persistence.SQLServer.data;
using DomainModel.Classes.User;
using Serilog;
using DomainModel.CQRS.Queries.AuthUsers;
using DomainModel.CQRS.Queries.GetUsers;
using DomainModel.Classes;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("CompositionRoot")]
namespace Persistence.SQLServer.Implementations.User
{
    internal class AuthenticateUser: IAuthenticateUser
    {
        private readonly CIRDbContext dbContext;

        private readonly AppSettings _appSettings;

        public AuthenticateUser(IOptions<AppSettings> appSettings, CIRDbContext CIRdbContext)
        {
            this.dbContext = CIRdbContext;
            _appSettings = appSettings.Value;
        }

        public IEnumerable<AuthUsersQuery> Authenticate(string username, string password)
        {
           
            AuthUsersQuery authUsers = new AuthUsersQuery();

            Users user = dbContext.Users.
                AsNoTracking().FirstOrDefault(usr => usr.Username.Trim().ToLower() == username.Trim().ToString().ToLower());

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
            {
                throw new NotImplementedException("username or password is incorrect");
            }

            authUsers.Id = user.Id;
            authUsers.FirstName = user.FirstName;
            authUsers.LastName = user.LastName;
            authUsers.Username = user.Username;
            authUsers.Password = string.Empty;

           
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, user.Id.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // completiamo l'utenza autenticata con token e expiration date
            authUsers.Token = tokenHandler.WriteToken(token);
            authUsers.Expiration_date = DateTime.UtcNow.AddDays(30).ToString();
           
            yield return authUsers;
        }
    }
}

