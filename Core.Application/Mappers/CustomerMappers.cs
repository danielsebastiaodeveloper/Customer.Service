using Core.Application.DTOs;
using Core.Application.Features.Customer.Commands.Create;
using Core.Application.Features.Customer.Commands.Update;
using Establo.Customer.Core.Domain.Pocos;

namespace Core.Application.Mappers;

public static class CustomerMappers
{
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

    public static CustomerReadDTO ToCustomerReadDTO(this Customer customer)
    {
        return new CustomerReadDTO
        {
            Id = customer.Id,
            Email = customer.Email,
            PhoneNumber = customer.PhoneNumber,
            FullName = customer.FullName,
            State = customer.State
        };
    }

    public static IEnumerable<CustomerReadDTO> ToReadCustomerDTO(this IEnumerable<Customer> customers)
    {
        var listDto = customers.Select(x => new CustomerReadDTO
        {
            Id = x.Id,
            Email = x.Email,
            PhoneNumber = x.PhoneNumber,
            FullName = x.FullName,
            State = x.State
        });
        return listDto;
    }
}
