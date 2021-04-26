using GPIHTask.Application.Common.Exceptions;
using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.CompanyOnMarketPriceOnMarketPriceCqrs.Queries.GetCompanyOnMarketPriceOnMarktPriceById
{
    public class GetCompanyOnMarketPriceByIdQuery : IRequest<CompanyOnMarketPriceDto>
    {
        public int Id { get; set; }

        public class GetCompanyOnMarketPriceByIdQueryHandler : IRequestHandler<GetCompanyOnMarketPriceByIdQuery, CompanyOnMarketPriceDto>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetCompanyOnMarketPriceByIdQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<CompanyOnMarketPriceDto> Handle(GetCompanyOnMarketPriceByIdQuery request, CancellationToken cancellationToken)
            {
                var companyOnMarketPrice = await _applicationDbContext.CompanyOnMarketPrices.FindAsync(request.Id);
                if (companyOnMarketPrice == null)
                    throw new NotFoundException(nameof(companyOnMarketPrice), request.Id);

                var companyOnMarketPriceDto = new CompanyOnMarketPriceDto();
                companyOnMarketPriceDto.Id = companyOnMarketPrice.Id;
                companyOnMarketPriceDto.MarketId = companyOnMarketPrice.MarketId;
                companyOnMarketPriceDto.CompanyId = companyOnMarketPrice.CompanyId;
                companyOnMarketPriceDto.Price = companyOnMarketPrice.Price;

                return companyOnMarketPriceDto;
            }
        }
    }
}
