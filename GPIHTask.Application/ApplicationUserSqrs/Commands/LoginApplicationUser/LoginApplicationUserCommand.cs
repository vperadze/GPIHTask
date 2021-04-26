using GPIHTask.Application.Classes;
using GPIHTask.Application.Common.Helper;
using GPIHTask.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.ApplicationUserSqrs.Commands.LoginApplicationUser
{
    public class LoginApplicationUserCommand : IRequest<string>
    {
        public string userName { get; set; }
        public string Password { get; set; }
        public class LoginApplicationUserListQueryHandler : IRequestHandler<LoginApplicationUserCommand, string>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            private readonly ApiApplicationSettings _apiAppliationSettings;

            public LoginApplicationUserListQueryHandler(IApplicationDbContext applicationDbContext, IOptions<ApiApplicationSettings> apiApplicationSettings)
            {
                _applicationDbContext = applicationDbContext;
                _apiAppliationSettings = apiApplicationSettings.Value;
            }

            public async Task<string> Handle(LoginApplicationUserCommand request, CancellationToken cancellationToken)
            {
                var token = string.Empty;

                var applicationUser = await _applicationDbContext
                    .ApplicationUsers
                    .FirstOrDefaultAsync(x => x.UserName == request.userName);
                if (applicationUser != null && HashPassword.Verify(applicationUser.PasswordHash, request.Password))
                {
                    var tokenDiscriptor = new SecurityTokenDescriptor()
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                            new Claim("UserId", applicationUser.Id)
                        }),
                        Expires = DateTime.UtcNow.AddDays(1),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_apiAppliationSettings.JwtSecret)), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var securityToken = tokenHandler.CreateToken(tokenDiscriptor);
                    token = tokenHandler.WriteToken(securityToken);
                }

                return token;
            }
        }
    }
}
