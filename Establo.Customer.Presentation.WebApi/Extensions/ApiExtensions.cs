using Google.Api.Gax.ResourceNames;
using Google.Cloud.PubSub.V1;
using Presentation.WebApi.Midlewares;

namespace Presentation.WebApi.Extensions;

public static class ApiExtensions
{
    public static void UseErrorHandlerMidleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandlerMidleware>();
    }

    public static void TryGGP()
    {
        //PublisherServiceApiClient publisher = PublisherServiceApiClient.Create();
        //ProjectName projectName = ProjectName.FromProject("elestablo");
        //foreach (var topic in publisher.ListTopics(projectName))
        //{
        //    Console.WriteLine(topic.Name);
        //}
    }
}
