using GPIHTask.Application.Interfaces;
using GPIHTask.Domain.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GPIHTask.Application.CompanyOnMarketPriceCqrs.Queries.GetCompanyOnMarktPriceList
{
    public class GetCompanyOnMarktPriceListQuery : IRequest<List<CompanyOnMarketPriceDto>>
    {
        public class GetCompanyOnMarktPriceListQueryHandler : IRequestHandler<GetCompanyOnMarktPriceListQuery, List<CompanyOnMarketPriceDto>>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public GetCompanyOnMarktPriceListQueryHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public async Task<List<CompanyOnMarketPriceDto>> Handle(GetCompanyOnMarktPriceListQuery request, CancellationToken cancellationToken)
            {
                List<CompanyOnMarketPriceDto> companyOnMarketPriceDtos = new List<CompanyOnMarketPriceDto>();
                var companyOnMarketPrices = await _applicationDbContext
                    .CompanyOnMarketPrices
                    .Include(x => x.Company)
                    .Include(x => x.Market)
                    .ToListAsync();

                foreach (var companyOnMarketPrice in companyOnMarketPrices)
                {
                    var companyOnMarketPriceDto = new CompanyOnMarketPriceDto();
                    companyOnMarketPriceDto.Id = companyOnMarketPrice.Id;
                    companyOnMarketPriceDto.CompanyId = companyOnMarketPrice.CompanyId;
                    companyOnMarketPriceDto.CompanyTitle = companyOnMarketPrice.Company.Title;
                    companyOnMarketPriceDto.MarketId = companyOnMarketPrice.MarketId;
                    companyOnMarketPriceDto.MarketTitle = companyOnMarketPrice.Market.Title;
                    companyOnMarketPriceDto.Price = companyOnMarketPrice.Price;

                    companyOnMarketPriceDtos.Add(companyOnMarketPriceDto);
                }

                return companyOnMarketPriceDtos;
            }
        }
    }
}
