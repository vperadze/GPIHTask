using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GPIHTask.Application.CompanyCqrs.Commands.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Company>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LogoPath { get; set; }
        public string Description { get; set; }
        public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Company>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public UpdateCompanyCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Company> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
            {
                var company = await _applicationDbContext.Companies.FindAsync(request.Id);
                if(company == null)
                    throw new NotFoundException(nameof(Company), request.Id);

                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {

                    company.Title = request.Title;
                    company.LogoPath = request.LogoPath;
                    company.Description = request.Description;

                    _applicationDbContext.Companies.Update(company);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    scope.Complete();
                }
                return company;
            }
        }
    }
}
