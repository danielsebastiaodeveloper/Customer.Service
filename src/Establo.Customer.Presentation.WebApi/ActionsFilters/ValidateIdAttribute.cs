using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

public class ValidateIdAttribute : IAsyncActionFilter
{
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

        if (!int.TryParse(value.ToString(), out int valor) || valor <= 0)
        {
            context.Result = new BadRequestObjectResult("Invalid id parameter");
            return;
        }
        context.HttpContext.Items.Add("Id", valor);

        await next();
    }
}
