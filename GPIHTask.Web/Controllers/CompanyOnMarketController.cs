using GPIHTask.Application.CompanyOnMarketPriceCqrs.Queries.GetCompanyOnMarktPriceList;
using GPIHTask.Application.CompanyOnMarketPriceOnMarketPriceCqrs.Commands.UpdateCompanyOnMarketPriceOnMarketPrice;
using GPIHTask.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPIHTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyOnMarketController : BaseController
    {
        [HttpPut("{id}")]
        [Route("Update/{id}")]
        public async Task<ActionResult<CompanyOnMarketPriceDto>> Update(int id, [FromBody] UpdateCompanyOnMarketPriceCommand command)
        {
            if (id != command.Id)
                return BadRequest();
            return await Mediator.Send(command);
        }

        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<List<CompanyOnMarketPriceDto>>> GetList()
        {
            return await Mediator.Send(new GetCompanyOnMarktPriceListQuery());
        }
    }
}
