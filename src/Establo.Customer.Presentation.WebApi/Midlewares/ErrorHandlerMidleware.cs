using System.Net;
using System.Text.Json;
using Core.Application.Wrappers;
using Mexico.Developers.Core.Exceptions;

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
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            var responseModel = new Response<string>() { Success = false, Message = error.Message };

            switch (error)
            {
                case ApiException e:
                    // Custom Aplication Error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Message = e.Message;
                    break;

                case Core.Application.Exceptions.ValidationException e:
                    // Custom Application
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    responseModel.Errors = e.Errors;
                    break;
                case KeyNotFoundException e:
                    // Not Found Error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    responseModel.Message = e.Message;
                    break;
                default:
                    // Unhandle Error 
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Message = error.Message;
                    break;
            }
            var result = JsonSerializer.Serialize(responseModel);
            await response.WriteAsync(result);

        }
    }
}