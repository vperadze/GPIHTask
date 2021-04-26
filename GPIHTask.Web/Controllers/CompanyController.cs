using GPIHTask.Application.CompanyCqrs.Commands.CreateCompany;
using GPIHTask.Application.CompanyCqrs.Commands.DeleteCompany;
using GPIHTask.Application.CompanyCqrs.Commands.UpdateCompany;
using GPIHTask.Application.CompanyCqrs.Queries.GetCompanyById;
using GPIHTask.Application.CompanyCqrs.Queries.GetCompanyList;
using GPIHTask.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GPIHTask.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : BaseController
    {
        [HttpGet]
        [Route("GetList")]
        public async Task<ActionResult<List<Company>>> GetList()
        {
            return await Mediator.Send(new GetCompanyListQuery());
        }

        [HttpGet("{id}")]
        [Route("GetById/{id}")]
        public async Task<ActionResult<Company>> GetById(int id)
        {
            return await Mediator.Send(new GetCompanyByIdQuery() { Id = id });
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Company>> Create([FromBody] CreateCompanyCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Company>> Update([FromBody] UpdateCompanyCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCompanyCommand() { Id = id });
            return Ok();
        }
    }
}
