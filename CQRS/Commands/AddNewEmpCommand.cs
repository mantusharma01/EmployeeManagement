using EmployeeManagement.Models;
using MediatR;

namespace EmployeeManagement.CQRS.Commands
{
    public record AddNewEmpCommand(Employee Employee) : IRequest;

}
