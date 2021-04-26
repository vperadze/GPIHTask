using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GPIHTask.Application.ApplicationUserSqrs.Commands.CreateApplicationUser
{
    public class CreateApplicationUserCommand : IRequest<ApplicationUser>
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public class CreateApplicationUserCommandHandler : IRequestHandler<CreateApplicationUserCommand, ApplicationUser>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public CreateApplicationUserCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<ApplicationUser> Handle(CreateApplicationUserCommand request, CancellationToken cancellationToken)
            {
                ApplicationUser ApplicationUser = null;
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    ApplicationUser = new ApplicationUser();
                    ApplicationUser.UserName = request.UserName;
                    ApplicationUser.FullName = request.FullName;

                    var hasher = new PasswordHasher<IdentityUser>();
                    ApplicationUser.PasswordHash = hasher.HashPassword(null, request.Password);

                    _applicationDbContext.ApplicationUsers.Add(ApplicationUser);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    scope.Complete();
                }
                return ApplicationUser;
            }
        }
    }
}
