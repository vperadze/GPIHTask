using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.CompanyCqrs.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest
    {
        public int Id { get; set; }
        public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public DeleteCompanyCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
            {
                var Company = await _applicationDbContext.Companies.FindAsync(request.Id);
                if (Company == null)
                    throw new NotFoundException(nameof(Company), request.Id);

                _applicationDbContext.Companies.Remove(Company);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
