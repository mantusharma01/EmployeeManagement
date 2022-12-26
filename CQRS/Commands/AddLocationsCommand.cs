using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Commands
{
    public record AddLocationsCommand(Location Location):IRequest;
}
