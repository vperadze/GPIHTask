using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace GPIHTask.Application.CompanyCqrs.Commands.CreateCompany
{
    public class CreateCompanyCommand : IRequest<Company>
    {
        public string Title { get; set; }
        public string LogoPath { get; set; }
        public string Description { get; set; }
        public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Company>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public CreateCompanyCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Company> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
            {
                Company company = null;
                using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    company = new Company();
                    company.Title = request.Title;
                    company.LogoPath = request.LogoPath;
                    company.Description = request.Description;

                    _applicationDbContext.Companies.Add(company);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    scope.Complete();
                }
                return company;
            }
        }
    }
}
