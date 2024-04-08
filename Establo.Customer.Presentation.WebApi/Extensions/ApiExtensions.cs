using Presentation.WebApi.Midlewares;

namespace Presentation.WebApi.Extensions;

public static class ApiExtensions
{
    public static void UseErrorHandlerMidleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMidleware>();
    }
}
