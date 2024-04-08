using Core.Application.Features.Customer.Queries.GetCustomerById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Presentation.WebApi.ActionsFilters;

public class ValidationCustomerExistsAttribute : IAsyncActionFilter
{
    private readonly IMediator mediator;

    public ValidationCustomerExistsAttribute(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.TryGetValue("Id", out object? value))
        {
            context.Result = new BadRequestObjectResult("Bad id parameter");
            return;
        }

        if (value is null)
        {
            context.Result = new BadRequestObjectResult("Id parameter cannot be null");
            return;
        }

        int.TryParse(value.ToString(), out int valor);

        var customer = new GetCustomerByIdQuery() { Id = valor };

        var result = await mediator.Send(customer);

        if (result.Data == null)
        {
            throw new KeyNotFoundException($"Customer with Id = {value} not found");
        }

        context.HttpContext.Items.Add("entity", result.Data);

        await next();
    }
}
