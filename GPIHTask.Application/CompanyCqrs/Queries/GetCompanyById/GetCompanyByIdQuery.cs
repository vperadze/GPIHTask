using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.CompanyCqrs.Queries.GetCompanyById
{
    public class GetCompanyByIdQuery : IRequest<Company>
    {
        public int Id { get; set; }

        public class GetCompanyByIdQueryHandler : IRequestHandler<GetCompanyByIdQuery, Company>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetCompanyByIdQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<Company> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
            {
                var company = await _applicationDbContext.Companies.FindAsync(request.Id);
                if (company == null)
                    throw new NotFoundException(nameof(Company), request.Id);

                return company;
            }
        }
    }
}
