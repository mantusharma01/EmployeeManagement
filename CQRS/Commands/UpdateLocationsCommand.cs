using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Commands
{
    public record UpdateLocationsCommand(int Id,Location Location):IRequest;
}
