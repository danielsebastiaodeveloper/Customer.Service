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
    private readonly ILogger<CustomersController> _logger;

    public CustomersController(IMediator mediator, ILogger<CustomersController> logger)
    {
        this.mediator = mediator;
        _logger = logger;
    }

    // POST api/customers
    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomerCommand createCustomerCommand, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"Executing end-point to create a new customer with Name - {createCustomerCommand.FullName}");
        var result = await mediator.Send(createCustomerCommand, cancellationToken);
        if (!result.Success)
        {
            _logger.LogWarning($"Failed to create a new customer with Name - {createCustomerCommand.FullName} - Message: {result.Message}");
            return BadRequest(result);
        }
        _logger.LogInformation($"Successfully created a new customer with Id - {result.Data}");
        return CreatedAtRoute(nameof(GetById), new { Id = result.Data }, result);
    }

    // GET api/customers/xxx
    [HttpGet("{Id}", Name = nameof(GetById))]
    [ServiceFilter(typeof(ValidationCustomerExistsAttribute))]
    public ActionResult<Response<CustomerReadDTO>> GetById(int Id)
    {
        var customer = HttpContext.Items["entity"] as CustomerReadDTO;
        return Ok(new Response<CustomerReadDTO>()
        {
            Data = customer,
            Success = true
        });
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

