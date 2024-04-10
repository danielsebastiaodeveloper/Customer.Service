using System.Text.Json.Serialization;

namespace Core.Application.DTOs;

/// <summary>
/// Represents a points transaction.
/// </summary>
public class PointsTransactionDTO
{
    /// <summary>
    /// Gets or sets the ID of the transaction.
    /// </summary>
    [JsonPropertyName("Id")]
    public int Id { get; init; } = default!;

    /// <summary>
    /// Gets or sets the ID of the customer associated with the transaction.
    /// </summary>
    [JsonPropertyName("CustomerId")]
    public int CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the date of the transaction.
    /// </summary>
    [JsonPropertyName("TransactionDate")]
    public DateTime TransactionDate { get; set; }

    /// <summary>
    /// Gets or sets the number of points involved in the transaction.
    /// </summary>
    [JsonPropertyName("Points")]
    public decimal Points { get; set; }

    /// <summary>
    /// Gets or sets the description of the transaction.
    /// </summary>
    [JsonPropertyName("Description")]
    public string? Description { get; set; }
}
