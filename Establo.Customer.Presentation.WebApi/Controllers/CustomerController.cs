using Microsoft.AspNetCore.Mvc;
using MediatR;
using Core.Application.DTOs;
using Core.Application.Features.Customer.Commands.Create;
using Core.Application.Features.Customer.Commands.Delete;
using Core.Application.Features.Customer.Commands.Update;
using Core.Application.Features.Customer.Queries.GetAllCustomers;
using Presentation.WebApi.ActionsFilters;

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
        return StatusCode(201, result);
    }

    // GET api/customers/xxx
    [HttpGet("{Id}", Name = "GetById")]
    [ServiceFilter(typeof(ValidationCustomerExistsAttribute))]
    public async Task<IActionResult> GetById(int Id, CancellationToken cancellationToken = default)
    {
        var task = await Task.Run(() =>
        {
            return HttpContext.Items["entity"] as CustomerReadDTO;
        });
        return Ok(task);
    }


    // PUT api/customers/xxx
    [HttpPut("{Id}")]
    [ServiceFilter(typeof(ValidationCustomerExistsAttribute))]
    public async Task<IActionResult> Put(int Id, [FromBody] UpdateCustomerCommand updateCustomerCommand, CancellationToken cancellationToken = default)
    {
        await mediator.Send(updateCustomerCommand, cancellationToken);
        return NoContent();
    }

    //DELETE api/customers/xxx
    [HttpDelete("{Id}")]
    [ServiceFilter(typeof(ValidationCustomerExistsAttribute))]
    public async Task<IActionResult> Delete(int Id, CancellationToken cancellationToken = default)
    {
        var customer = new DeleteCustomerCommand()
        {
            Id = Id
        };
        await mediator.Send(customer, cancellationToken);
        return NoContent();
    }


    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] bool state, CancellationToken cancellationToken = default)
    {
        var query = new GetAllCustomersQuery()
        {
            State = state
        };
        var result = await mediator.Send(query, cancellationToken);
        return Ok(result);
    }

}

