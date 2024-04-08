using System.Text.Json.Serialization;

namespace Core.Application.DTOs;

public class CustomerReadDTO
{
    [JsonPropertyName("Id")]
    public int Id { get; init; } = default!;
    [JsonPropertyName("FullName")]
    public string FullName { get; init; } = default!;
    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; } = default!;
    [JsonPropertyName("Email")]
    public string? Email { get; set; } = default!;
    [JsonPropertyName("State")]
    public bool State { get; set; }
}
