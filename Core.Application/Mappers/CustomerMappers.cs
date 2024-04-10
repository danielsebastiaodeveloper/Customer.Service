using Core.Application.DTOs;
using Core.Application.Features.Customer.Commands.Create;
using Core.Application.Features.Customer.Commands.Update;
using Establo.Customer.Core.Domain.Pocos;

namespace Core.Application.Mappers;

/// <summary>
/// Provides mapping methods for the Customer entity and DTOs.
/// </summary>
public static class CustomerMappers
{
    /// <summary>
    /// Maps a CreateCustomerCommand to a Customer entity.
    /// </summary>
    /// <param name="command">The CreateCustomerCommand object.</param>
    /// <returns>The mapped Customer entity.</returns>
    public static Customer ToCustomer(this CreateCustomerCommand command)
    {
        return new Customer
        {
            Id = default,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            FullName = command.FullName,
            State = true
        };
    }

    /// <summary>
    /// Maps an UpdateCustomerCommand to a Customer entity.
    /// </summary>
    /// <param name="command">The UpdateCustomerCommand object.</param>
    /// <returns>The mapped Customer entity.</returns>
    public static Customer ToCustomer(this UpdateCustomerCommand command)
    {
        return new Customer
        {
            Id = command.Id,
            Email = command.Email,
            PhoneNumber = command.PhoneNumber,
            FullName = command.FullName,
            State = command.State
        };
    }

    /// <summary>
    /// Maps a Customer entity to a CustomerReadDTO.
    /// </summary>
    /// <param name="customer">The Customer entity.</param>
    /// <returns>The mapped CustomerReadDTO.</returns>
    public static CustomerReadDTO ToCustomerReadDTO(this Customer customer)
    {
        return new CustomerReadDTO
        {
            Id = customer.Id,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            FullName = customer.FullName,
            State = customer.State,
            Points = customer.Points,
            PointsTransactions = customer.PointsTransactions.ToPointsTransactionDTO()
        };
    }

    /// <summary>
    /// Maps a collection of Customer entities to a collection of CustomerReadDTOs.
    /// </summary>
    /// <param name="customers">The collection of Customer entities.</param>
    /// <returns>The mapped collection of CustomerReadDTOs.</returns>
    public static IEnumerable<CustomerReadDTO> ToReadCustomerDTO(this IEnumerable<Customer> customers)
    {
        return customers.Select(customer => new CustomerReadDTO
        {
            Id = customer.Id,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            FullName = customer.FullName,
            State = customer.State,
            Points = customer.Points,
            PointsTransactions = customer.PointsTransactions.Select(x => x.ToPointsTransactionDTO()).ToList()
        });
    }

    /// <summary>
    /// Maps a Customer entity to a CustomerReadDTO including PointsTransactions.
    /// </summary>
    /// <param name="customer">The Customer entity.</param>
    /// <returns>The mapped CustomerReadDTO.</returns>
    public static CustomerReadDTO ToCustomerDTO(this Customer customer)
    {
        return new CustomerReadDTO
        {
            Id = customer.Id,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            FullName = customer.FullName,
            State = customer.State,
            Points = customer.Points,
            PointsTransactions = customer.PointsTransactions.ToPointsTransactionDTO()
        };
    }
}
