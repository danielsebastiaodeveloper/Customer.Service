using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Application.DTOs;
using Core.Application.Features.Customer.Commands.Create;
using Core.Application.Features.Customer.Commands.Delete;
using Core.Application.Features.Customer.Commands.Update;
using Core.Application.Features.Customer.Queries.GetAllCustomers;
using Presentation.WebApi.ActionsFilters;
using Core.Application.Wrappers;

namespace Presentation.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator mediator;

    public CustomersController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    // POST api/customers
    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken = default)
    {
        var result = await mediator.Send(createCustomerCommand, cancellationToken);
        return CreatedAtRoute("GetById", new { Id = result.Data }, result);
    }

    // GET api/customers/xxx
    [HttpGet("{Id}", Name = "GetById")]
    [ServiceFilter(typeof(ValidationCustomerExistsAttribute))]
    public async Task<ActionResult<Response<CustomerReadDTO>>> GetById(int Id)
    {
        if (Id <= 0)
        {
            return BadRequest();
        }

        var task = await Task.Run(() =>
        {
            var customer = HttpContext.Items["entity"] as CustomerReadDTO;
            return new Response<CustomerReadDTO>()
            {
                Data = customer,
                Success = true
            };
        });
        return Ok(task);
    }


    // PUT api/customers/xxx
    [HttpPut("{Id}")]
    [ServiceFilter(typeof(ValidationCustomerExistsAttribute))]
    public async Task<IActionResult> Put(int Id, [FromBody] UpdateCustomerCommand updateCustomerCommand, CancellationToken cancellationToken = default)
    {
        if (Id != updateCustomerCommand.Id || Id <= 0)
        {
            return BadRequest();
        }

        await mediator.Send(updateCustomerCommand, cancellationToken);
        return NoContent();
    }

    //DELETE api/customers/xxx
    [HttpDelete("{Id}")]
    [ServiceFilter(typeof(ValidationCustomerExistsAttribute))]
    public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken = default)
    {
        if (Id <= 0)
        {
            return BadRequest();
        }

        var customer = new DeleteCustomerCommand()
        {
            Id = Id
        };
        await mediator.Send(customer, cancellationToken);
        return NoContent();
    }


    [HttpGet]
    public async Task<ActionResult<Response<IEnumerable<CustomerReadDTO>>>> Get([FromQuery] bool state, CancellationToken cancellationToken = default)
    {
        var query = new GetAllCustomersQuery()
        {
            State = state
        };
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

}

