using Core.Application.Wrappers;
using Establo.Customer.Core.Domain.Pocos;
using Mexico.Developers.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace Presentation.WebApi.Midlewares;

public class ErrorHandlerMidleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMidleware(RequestDelegate next)
    {
        this._next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {

            await _next(context);
            // Midleware de response
            //...

        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>() { Success = false, Message = error.Message };

            switch (error)
            {
                case ApiException e:
                    //Custom Aplication Error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;

                case Core.Application.Exceptions.ValidationException e:
                    // Custom Application
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    break;
                case KeyNotFoundException e:
                    //Not Found Error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Message = e.Message;
                    break;
                default:
                    //unhandle Error 
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Message = error.Message;
                    break;
            }
            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);

        }
    }
}