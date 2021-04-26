using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Common.Helper;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GPIHTask.Application.ApplicationUserSqrs.Commands.UpdateApplicationUser
{
    public class UpdateApplicationUserCommand : IRequest<ApplicationUser>
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }

        public class UpdateApplicationUserCommandHandler : IRequestHandler<UpdateApplicationUserCommand, ApplicationUser>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public UpdateApplicationUserCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<ApplicationUser> Handle(UpdateApplicationUserCommand request, CancellationToken cancellationToken)
            {
                var ApplicationUser = await _applicationDbContext.ApplicationUsers.FindAsync(request.Id);
                if (ApplicationUser == null)
                    throw new NotFoundException(nameof(ApplicationUser), request.Id);

                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    ApplicationUser.Id = request.Id;
                    ApplicationUser.UserName = request.UserName;
                    ApplicationUser.FullName = request.FullName;

                    ApplicationUser.PasswordHash = HashPassword.Hash(request.Password);

                    _applicationDbContext.ApplicationUsers.Update(ApplicationUser);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    scope.Complete();
                }
                return ApplicationUser;
            }
        }
    }
}
