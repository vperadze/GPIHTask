using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.ApplicationUserSqrs.Commands.DeleteApplicationUser
{
    public class DeleteApplicationUserCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteApplicationUserCommandHandler : IRequestHandler<DeleteApplicationUserCommand>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public DeleteApplicationUserCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Unit> Handle(DeleteApplicationUserCommand request, CancellationToken cancellationToken)
            {
                var ApplicationUser = await _applicationDbContext.ApplicationUsers.FindAsync(request.Id);
                if (ApplicationUser == null)
                    throw new NotFoundException(nameof(ApplicationUser), request.Id);

                _applicationDbContext.ApplicationUsers.Remove(ApplicationUser);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
