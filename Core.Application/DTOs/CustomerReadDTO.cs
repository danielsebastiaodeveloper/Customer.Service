using Core.Domain.Pocos;
using System.Text.Json.Serialization;

namespace Core.Application.DTOs;

public class CustomerReadDTO
{
    /// <summary>
    /// Gets or sets the customer ID.
    /// </summary>
    [JsonPropertyName("Id")]
    public int Id { get; init; } = default!;

    /// <summary>
    /// Gets or sets the customer's full name.
    /// </summary>
    [JsonPropertyName("FullName")]
    public string FullName { get; init; } = default!;

    /// <summary>
    /// Gets or sets the customer's phone number.
    /// </summary>
    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber { get; set; } = default!;

    /// <summary>
    /// Gets or sets the customer's email address.
    /// </summary>
    [JsonPropertyName("Email")]
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the state of the customer.
    /// </summary>
    [JsonPropertyName("State")]
    public bool State { get; set; }

    /// <summary>
    /// Gets or sets the state of the customer.
    /// </summary>
    [JsonPropertyName("Points")]
    public decimal Points { get; set; }

    /// <summary>
    /// Gets or sets the list of points transactions for the customer.
    /// </summary>
    [JsonPropertyName("PointsTransactions")]
    public ICollection<PointsTransactionDTO> PointsTransactions { get; set; } = new List<PointsTransactionDTO>();
}
