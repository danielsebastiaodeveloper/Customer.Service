using System.Diagnostics.CodeAnalysis;

namespace Core.Application.Wrappers;

public class Response<T>
{
    [AllowNull]
    public bool Success { get; set; }

    [AllowNull]
    public string Message { get; set; }

    [AllowNull]
    public List<string> Errors { get; set; }

    [AllowNull]
    public T Data { get; set; }

    public Response()
    {

    }

    public Response(T data, string message)
    {
        Success = true;
        Message = message;
        Data = data;
    }

    public Response(string message)
    {
        Success = false;
        Message = message;
    }
}
