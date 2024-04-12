using System.Diagnostics.CodeAnalysis;

namespace Core.Application.Wrappers;

/// <summary>
/// Represents a generic response wrapper.
/// </summary>
/// <typeparam name="T">The type of the data.</typeparam>
public class Response<T>
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation was successful.
    /// </summary>
    [AllowNull]
    public bool Success { get; set; }

    /// <summary>
    /// Gets or sets the message associated with the response.
    /// </summary>
    [AllowNull]
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the list of errors associated with the response.
    /// </summary>
    [AllowNull]
    public List<string> Errors { get; set; }

    /// <summary>
    /// Gets or sets the data associated with the response.
    /// </summary>
    [AllowNull]
    public T Data { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class.
    /// </summary>
    public Response()
    {

    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class with the specified data and message.
    /// </summary>
    /// <param name="data">The data associated with the response.</param>
    /// <param name="message">The message associated with the response.</param>
    public Response(T data, string message)
    {
        Success = true;
        Message = message;
        Data = data;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Response{T}"/> class with the specified message.
    /// </summary>
    /// <param name="message">The message associated with the response.</param>
    public Response(string message)
    {
        Success = false;
        Message = message;
    }
}
